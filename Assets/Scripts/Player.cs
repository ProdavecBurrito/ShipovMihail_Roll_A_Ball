using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class Player : MonoBehaviour
    {
        #region Fields

        public InputManager _inputManager;
        public Rigidbody _rigidbody; 
        public float Speed = 3.0f;

        private Vector3 _movement;
        private float _moveHorizontal;
        private float _moveVertical;

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
            _moveHorizontal = _inputManager.X;
            _moveVertical = _inputManager.Y;

            _movement = new Vector3(_moveHorizontal, 0.0f, _moveVertical);
            _rigidbody.AddForce(_movement * Speed);
        }

        #endregion
    }
}
