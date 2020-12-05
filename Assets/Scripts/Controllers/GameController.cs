using UnityEngine;
using System;
using UnityEngine.SceneManagement;

namespace ShipovMihail_Roll_A_Boll
{
    internal class GameController : MonoBehaviour, IDisposable
    {
        private ObjectsInitializator _objectsInitializator;
        private float _currentScore;

        private void Awake()
        {
            _objectsInitializator = new ObjectsInitializator();

            for (int i = 0; i < _objectsInitializator.UpdatingObjects.Count; i++)
            {
                if (_objectsInitializator.UpdatingObjects[i] is IAwake startingObject)
                {
                    startingObject.AwakeTick();
                }
            }

            foreach(var item in _objectsInitializator.ReduceSpeed)
            {
                item.ReduceSpeed += _objectsInitializator.PlayerEffects.ReduceSpeed;
            }

            foreach (var item in _objectsInitializator.SpeedBonus)
            {
                item.BustSpeed += _objectsInitializator.PlayerEffects.BustSpeed;
            }

            foreach (var item in _objectsInitializator.GoodBonuses)
            {
                item.BonusChange += AddScore;
                item.BonusChange += _objectsInitializator.CameraController.ShakeCamera;
            }

            foreach (var item in _objectsInitializator.BadBonuses)
            {
                item.CaughtPlayer += CaughtPlayer;
                item.CaughtPlayer += _objectsInitializator.DisplayEndGame.GameOver;
            }

            _objectsInitializator.Reference.RestartButton.onClick.AddListener(RestartGame);
            _objectsInitializator.Reference.RestartButton.gameObject.SetActive(false);

            Debug.Log($"Kek3" + _objectsInitializator.GoodBonuses.Count);
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

                if (_objectsInitializator.UpdatingObjects[i] is ReduceSpeedController reduceSpeed)
                {
                    if (!reduceSpeed.IsInteractable)
                    {
                        _objectsInitializator.UpdatingObjects.RemoveUpdatingObject(reduceSpeed);
                        _objectsInitializator.TotalScoreObjects--;
                        Destroy(reduceSpeed);
                        continue;
                    }
                }

                if (_objectsInitializator.UpdatingObjects[i] is SpeedBonusController speedBonus)
                {
                    if (!speedBonus.IsInteractable)
                    {
                        _objectsInitializator.UpdatingObjects.RemoveUpdatingObject(speedBonus);
                        _objectsInitializator.TotalScoreObjects--;
                        Destroy(speedBonus);
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
            _objectsInitializator.Reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddScore(float value)
        {
            _currentScore += value;
            _objectsInitializator.DisplayScore.Display(_currentScore / _objectsInitializator.TotalScoreObjects);
        }

        public void Dispose()
        {
            for (int i = 0; i < _objectsInitializator.UpdatingObjects.Count; i++)
            {
                if (_objectsInitializator.UpdatingObjects[i] is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer -= CaughtPlayer;
                    badBonus.CaughtPlayer -= _objectsInitializator.DisplayEndGame.GameOver;
                }

                if (_objectsInitializator.UpdatingObjects[i] is GoodBonusController goodBonus)
                {
                    goodBonus.BonusChange -= AddScore;
                }

                if (_objectsInitializator.UpdatingObjects[i] is SpeedBonusController speedBonus)
                {
                    speedBonus.BustSpeed -= _objectsInitializator.PlayerEffects.BustSpeed;
                }

                if (_objectsInitializator.UpdatingObjects[i] is ReduceSpeedController reduceSpeedController)
                {
                    reduceSpeedController.ReduceSpeed -= _objectsInitializator.PlayerEffects.ReduceSpeed;
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
            _objectsInitializator.DisplayWin.СongratulationWinText(_currentScore);
            _objectsInitializator.Reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
