using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class MainCameraInitializator
    {
        private Camera _mainCamera;

        public Camera GetMainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }

                return _mainCamera;
            }
        }
    }
}
