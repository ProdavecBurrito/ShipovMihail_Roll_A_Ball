using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    // Поидее, накдо бы камеру тоже разбить на классы
    internal sealed class CameraController : IUpdate
    {
        private Animator _animator;
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;

        public CameraController (Transform player, Transform mainCamera, Animator cameraAnimator)
        {
            _player = player;
            _mainCamera = mainCamera;
            _animator = cameraAnimator;
            _mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.transform.position;
        }

        public void UpdateTick()
        {
            _mainCamera.position = _player.transform.position + _offset;
        }

        public void ShakeCamera(float value)
        {
            _animator.SetTrigger("Shake");
        }
    }
}
