using UnityEngine;
using System;

namespace ShipovMihail_Roll_A_Boll
{
    public class GameController : MonoBehaviour, IDisposable
    {
        private CameraController _cameraController;
        private ListIUpdateObjects _updatingObjects;
        private DisplayEndGame _displayEndGame;
        private DisplayScore _displayScore;
        private float _currentScore;

        private void Awake()
        {
            _updatingObjects = new ListIUpdateObjects();

            var reference = new References();

            _cameraController = new CameraController(reference.GetPlayerBall.transform, reference.GetMainCamera.transform, reference.GetCameraAnimator);
            _displayEndGame = new DisplayEndGame();
            _displayScore = new DisplayScore();

            _updatingObjects.AddUpdateObject(_cameraController);

            for (int i = 0; i < _updatingObjects.Count; i++)
            {
                if (_updatingObjects[i] is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += CaughtPlayer;
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                }

                if (_updatingObjects[i] is GoodBonus goodBonus)
                {
                    goodBonus.BonusChange += AddScore;
                    goodBonus.BonusChange += _cameraController.ShakeCamera;
                }
            }
        }

        private void Update()
        {
            for (int i = 0; i < _updatingObjects.Count; i++)
            {
                if (_updatingObjects[i] == null)
                {
                    continue;
                }
                _updatingObjects[i].UpdateTick();
            }
        }

        private void CaughtPlayer(string value, Color args)
        {
            Time.timeScale = 0.0f;
        }

        private void AddScore(float value)
        {
            _currentScore += value;
            _displayScore.Display(_currentScore);
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

                if (_updatingObjects[i] is GoodBonus goodBonus)
                {
                    goodBonus.BonusChange -= AddScore;
                }
            }
        }

    }
}
