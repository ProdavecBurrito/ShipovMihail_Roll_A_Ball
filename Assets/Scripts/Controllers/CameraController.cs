using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal sealed class CameraController : MonoBehaviour
    {
        #region Fields

        private Animator _animator;
        private Player _player;
        private Vector3 _offset;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _player = FindObjectOfType<Player>();
            _offset = transform.position - _player.transform.position;
        }

        private void FixedUpdate()
        {
            transform.position = _player.transform.position + _offset;
        }

        public void ShakeCamera(float value)
        {
            _animator.SetTrigger("Shake");
        }

        #endregion
    }
}
