using UnityEngine;
using System;
using static UnityEngine.Debug;
using UnityEngine.UI;

namespace ShipovMihail_Roll_A_Boll
{
    public class GameController : MonoBehaviour, IDisposable
    {
        public Text GameOverText;
        private CameraController _cameraController;
        private ListInteractableObject _interactiveObjects;
        private PlayerEffects _playerEffects;
        private DisplayEndGame _displayEndGame;
        private DisplayScore _displayScore;

        private void Awake()
        {
            _cameraController = FindObjectOfType<CameraController>();
            _displayScore = new DisplayScore();
            _displayEndGame = new DisplayEndGame(GameOverText);
            _playerEffects = FindObjectOfType<PlayerEffects>();
            _interactiveObjects = new ListInteractableObject();

            foreach (var item in _interactiveObjects)
            {
                if (item is BadBonus badBonus)
                {
                    badBonus.CaughtPlayer += _displayEndGame.GameOver;
                    badBonus.CaughtPlayer += CaughtPlayer;
                }

                if (item is GoodBonus goodBonus)
                {
                    goodBonus.BonusChange += _displayScore.Display;
                    goodBonus.BonusChange += _cameraController.ShakeCamera;
                }
            }
        }

        private void Update()
        {
            for (int i = 0; i < _interactiveObjects.Count; i++)
            {
                var interactiveOnject = _interactiveObjects[i];

                if (interactiveOnject == null)
                {
                    continue;
                }
                if (interactiveOnject is IUpdate updateTick)
                {
                    updateTick.UpdateTick();
                }
            }
            if (_playerEffects.Timers.Count != 0)
            {
                Log(_playerEffects.Timers.Count);
                _playerEffects.UpdateTick();
            }
        }

        private void CaughtPlayer(object value, CaughtPlayerEventArgs args)
        {
            Time.timeScale = 0.0f;
        }

        public void Dispose()
        {
            foreach (var item in _interactiveObjects)
            {
                if (item is InteractiveObject interactiveObject)
                {
                    if (item is BadBonus badBonus)
                    {
                        badBonus.CaughtPlayer -= CaughtPlayer;
                        badBonus.CaughtPlayer -= _displayEndGame.GameOver;
                    }
                    if (item is GoodBonus goodBonus)
                    {
                        goodBonus.BonusChange -= _displayScore.Display;
                        goodBonus.BonusChange -= _cameraController.ShakeCamera;
                    }
                    Destroy(interactiveObject.gameObject);
                }
            }
        }
    }
}
