using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class PlayerInputController : IUpdate
    {
        private PlayerBall _playerBall;

        public PlayerInputController(PlayerBall playerBall)
        {
            _playerBall = playerBall;
        }

        public void UpdateTick()
        {
            _playerBall.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _playerBall.Jump(Input.GetButtonDown("Jump"));
        }
    }
}
