using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace ShipovMihail_Roll_A_Boll
{
    public class GameController : MonoBehaviour, IDisposable
    {
        private ObjectsInitializator _objectsInitializator;

        //private PlayerEffects _playerEffects;
        //private PlayerBall _playerBall;
        //private CameraController _cameraController;
        //private ListIUpdateObjects _updatingObjects;
        //private DisplayEndGame _displayEndGame;
        //private DisplayWinGame _displayWin;
        //private DisplayScore _displayScore;
        //private InputController _inputController;
        //private References _reference;
        //private List<GoodBonusController> _goodBonuses;
        //private List<BadBonusController> _badBonuses;
        //private List<GameObject> _savingObjects;
        //private int _totalScoreObjects;

        //private float _currentScore;

        private void Awake()
        {
            _objectsInitializator = new ObjectsInitializator();

            //    _updatingObjects = new ListIUpdateObjects();

            //    _reference = new References();

            //    _playerBall = _reference.GetPlayerBall;
            //    _displayEndGame = new DisplayEndGame(_reference.EndGame);
            //    _displayWin = new DisplayWinGame(_reference.WinGame);
            //    _displayScore = new DisplayScore(_reference.Score);
            //    _playerEffects = _playerBall.GetComponent<PlayerEffects>();
            //    _goodBonuses = _reference.GetGoodBonuses;
            //    _badBonuses = _reference.GetBadBonus;
            //    _savingObjects = new List<GameObject>();
            //    _cameraController = new CameraController(_playerBall.transform, _reference.GetMainCamera.transform, _reference.GetCameraAnimator);

            foreach (var item in _goodBonuses)
            {
                _updatingObjects.AddUpdateObject(item);
                _totalScoreObjects++;
                item.BonusChange += AddScore;
                item.BonusChange += _cameraController.ShakeCamera;
            }

            foreach (var item in _badBonuses)
            {
                _updatingObjects.AddUpdateObject(item);
                item.CaughtPlayer += CaughtPlayer;
                item.CaughtPlayer += _displayEndGame.GameOver;
            }
            for (int i = 0; i < _updatingObjects.Count; i++)
            {
                if (_updatingObjects[i] is InteractiveObject interactiveObject)
                {
                    _savingObjects.Add(interactiveObject.gameObject);
                }
            }

            _savingObjects.Add(_playerBall.gameObject);

            _inputController = new InputController(_savingObjects, _playerBall);

            _updatingObjects.AddUpdateObject(_cameraController);
            _updatingObjects.AddUpdateObject(_inputController);

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void Update()
        {
            for (int i = 0; i < _objectsInitializator.UpdatingObjects.Count; i++)
            {
                if (_objectsInitializator.UpdatingObjects[i] == null)
                {
                    continue;
                }

                if (_objectsInitializator.UpdatingObjects[i] is GoodBonusController goodBonusController)
                {
                    if (!goodBonusController.IsInteractable)
                    {
                        _objectsInitializator.UpdatingObjects.RemoveUpdatingObject(goodBonusController);
                        _objectsInitializator.TotalScoreObjects--;
                        Destroy(goodBonusController);
                        continue;
                    }
                }
                _objectsInitializator.UpdatingObjects[i].UpdateTick();
            }

            if (_objectsInitializator.PlayerEffects.Timers.Count != 0)
            {
                _objectsInitializator.PlayerEffects.UpdateTick();
            }

            if (_objectsInitializator.TotalScoreObjects < 1)
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
            for (int i = 0; i < _objectsInitializator.UpdatingObjects.Count; i++)
            {
                if (_objectsInitializator.UpdatingObjects[i] is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer -= _objectsInitializator.CaughtPlayer;
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
