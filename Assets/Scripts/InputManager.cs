using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public class InputManager : MonoBehaviour
    {
        #region Fields

        private float _x;
        private float _y;

        #endregion


        #region Properties

        public float X => _x;
        public float Y => _y;

        #endregion


        #region UnityMethods

        private void Update()
        {
            _x = Input.GetAxis("Horizontal");
            _y = Input.GetAxis("Vertical");
        }

        #endregion
    }
}
