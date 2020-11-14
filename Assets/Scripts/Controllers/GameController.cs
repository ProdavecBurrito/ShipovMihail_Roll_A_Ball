using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace ShipovMihail_Roll_A_Boll
{
    public class GameController : MonoBehaviour, IDisposable
    {

        private PlayerEffects _playerEffects;
        private PlayerBall _playerBall;
        private CameraController _cameraController;
        private ListIUpdateObjects _updatingObjects;
        private DisplayEndGame _displayEndGame;
        private DisplayWinGame _displayWin;
        private DisplayScore _displayScore;
        private InputController _inputController;
        private References _reference;
        private List<GoodBonusController> _goodBonuses;
        private List<SavedData> _savingObjects;
        private List<InteractiveObject> _loadingObjects;
        private int _totalScoreObjects;

        private float _currentScore;

        private void Awake()
        {
            _updatingObjects = new ListIUpdateObjects();

            _reference = new References();

            _playerBall = _reference.GetPlayerBall;
            _cameraController = new CameraController(_playerBall.transform, _reference.GetMainCamera.transform, _reference.GetCameraAnimator);
            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayWin = new DisplayWinGame(_reference.WinGame);
            _displayScore = new DisplayScore(_reference.Score);
            _playerEffects = FindObjectOfType<PlayerEffects>();
            _goodBonuses = _reference.GetGoodBonuses;
            _loadingObjects = new List<InteractiveObject>();
            _savingObjects = new List<SavedData>();

            _updatingObjects.AddUpdateObject(_cameraController);
            _updatingObjects.AddUpdateObject(_inputController);

            foreach (var item in _goodBonuses)
            {
                _updatingObjects.AddUpdateObject(item);
                _totalScoreObjects++;
                item.BonusChange += AddScore;
                item.BonusChange += _cameraController.ShakeCamera;
            }

            for (int i = 0; i < _updatingObjects.Count; i++)
            {
                if (_updatingObjects[i] is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                }

                if (_updatingObjects[i] is InteractiveObject interactiveObj)
                {
                    _savingObjects.Add(new SavedData()

                    {
                        Name = interactiveObj.name,
                        Position = interactiveObj.transform.position,
                        IsEnable = interactiveObj.gameObject.activeSelf
                    });

                    _loadingObjects.Add(interactiveObj);
                }
            }

            _inputController = new InputController(_savingObjects, _loadingObjects, _playerBall);

            _updatingObjects.AddUpdateObject(_inputController);

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            for (int i = 0; i < _updatingObjects.Count; i++)
            {
                if (_updatingObjects[i] == null)
                {
                    continue;
                }

                if (_updatingObjects[i] is GoodBonusController goodBonusController)
                {
                    if (!goodBonusController.IsInteractable)
                    {
                        _updatingObjects.RemoveUpdatingObject(goodBonusController);
                        _totalScoreObjects--;
                        Destroy(goodBonusController);
                        continue;
                    }
                }
                _updatingObjects[i].UpdateTick();
            }

            if (_playerEffects.Timers.Count != 0)
            {
                _playerEffects.UpdateTick();
            }

            if (_totalScoreObjects < 1)
            {
                WinGame();
            }
        }

        private void CaughtPlayer(string value, Color args)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddScore(float value)
        {
            _currentScore += value;
            _displayScore.Display(_currentScore / _totalScoreObjects);
        }

        public void Dispose()
        {
            for (int i = 0; i < _updatingObjects.Count; i++)
            {
                if (_updatingObjects[i] is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer -= CaughtPlayer;
                    badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                }

                if (_updatingObjects[i] is GoodBonusController goodBonus)
                {
                    goodBonus.BonusChange -= AddScore;
                }
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }

        private void WinGame()
        {
            _displayWin.СongratulationWinText(_currentScore);
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
