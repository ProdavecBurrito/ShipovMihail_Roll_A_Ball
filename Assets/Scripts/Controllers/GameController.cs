using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public class GameController : MonoBehaviour
    {

        private InteractiveObject[] _interactiveObjects;

        private void Awake()
        {
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
        }
    }
}
