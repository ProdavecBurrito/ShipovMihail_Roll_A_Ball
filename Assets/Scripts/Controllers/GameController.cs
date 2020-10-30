using UnityEngine;
using System;
using static UnityEngine.Debug;

namespace ShipovMihail_Roll_A_Boll
{
    public class GameController : MonoBehaviour, IDisposable
    {

        private InteractiveObject[] _interactiveObjects;
        private PlayerEffects _playerEffects;

        private void Awake()
        {
            _playerEffects = FindObjectOfType<PlayerEffects>();
            _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        }

        private void Update()
        {
            for (int i = 0; i < _interactiveObjects.Length; i++)
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

        public void Dispose()
        {
            foreach (var item in _interactiveObjects)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
