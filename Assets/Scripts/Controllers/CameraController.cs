using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal sealed class CameraController : MonoBehaviour
    {
        #region Fields

        private Player _player;
        private Vector3 _offset;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _player = FindObjectOfType<Player>();
            _offset = transform.position - _player.transform.position;
        }

        private void FixedUpdate()
        {
            transform.position = _player.transform.position + _offset;
        }

        #endregion
    }
}
