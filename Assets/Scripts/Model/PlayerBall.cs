using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class PlayerBall : PlayerBase
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * CurrentSpeed);
        }

        public override void Jump(bool isJump)
        {
            if (isJump)
            {
                _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
    }
}
