using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class CameraAnimatorInitializator
    {
        private Animator _cameraAnimator;

        public Animator GetCameraAnimator
        {
            get
            {
                if(_cameraAnimator == null)
                {
                    _cameraAnimator = Camera.main.GetComponent<Animator>();
                }

                return _cameraAnimator;
            }
        }
    }
}
