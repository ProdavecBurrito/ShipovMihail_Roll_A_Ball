using UnityEngine;
using System;

namespace ShipovMihail_Roll_A_Boll
{
    internal class Player : MonoBehaviour, IDisposable
    {
        #region Fields

        public float NormalSpeed = 5.0f;
        public float CurrentSpeed = 5.0f;
        public float JumpForce = 5.0f;

        private InputManager _inputManager;
        private Rigidbody _rigidbody;
        private Vector3 _movement;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _inputManager = GetComponent<InputManager>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {

        }

        #endregion


        #region Methods

        protected void Move()
        {
            _movement = new Vector3(_inputManager.X, 0.0f, _inputManager.Y);
            _rigidbody.AddForce(_movement * CurrentSpeed);
        }

        protected void Jump()
        {
            if (_inputManager.CheckThatPressJump())
            {
                _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}
