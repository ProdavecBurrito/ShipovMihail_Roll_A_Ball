using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class Player : MonoBehaviour
    {
        #region Fields

        public InputManager _inputManager;
        public Rigidbody _rigidbody; 
        public float Speed = 3.0f;
        public float JumpForce = 20.0f;

        private Vector3 _movement;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _inputManager = GetComponent<InputManager>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        #endregion


        #region Methods

        protected void Move()
        {
            _movement = new Vector3(_inputManager.X, 0.0f, _inputManager.Y);
            _rigidbody.AddForce(_movement * Speed);
        }

        protected void Jump()
        {
            if (_inputManager.CheckThatPressJump())
            {
                _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }

        #endregion
    }
}
