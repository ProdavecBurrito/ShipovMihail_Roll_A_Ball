using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal sealed class InputManager : MonoBehaviour
    {
        #region Fields

        private float _x;
        private float _y;
        private KeyCode _jumpButton = KeyCode.Space;

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


        #region Methods

        public bool CheckThatPressJump()
        {
            return Input.GetKeyDown(_jumpButton);
        }

        #endregion
    }
}
