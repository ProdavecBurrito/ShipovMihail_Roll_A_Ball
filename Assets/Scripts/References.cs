using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public class References
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private Animator _cameraAnimator;

        internal PlayerBall GetPlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var loadingPlayer = Resources.Load<PlayerBall>("Player");
                    _playerBall = loadingPlayer;
                }

                return _playerBall;
            }
        }

        internal Camera GetMainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                    _cameraAnimator = _mainCamera.GetComponent<Animator>();
                }

                return _mainCamera;
            }
        }

        public Animator GetCameraAnimator
        {
            get
            {
                if (_cameraAnimator == null && _mainCamera != null)
                {
                    _cameraAnimator = _mainCamera.GetComponent<Animator>();
                }

                return _cameraAnimator;
            }
        }
    }
}
