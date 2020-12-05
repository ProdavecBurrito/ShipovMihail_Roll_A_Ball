using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class PlayerBallInitializator
    {
        private PlayerBall _playerBall;

        internal PlayerBall GetPlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var loadPlayerBall = Resources.Load<PlayerBall>("Player");
                    _playerBall = Object.Instantiate(loadPlayerBall);
                }

                return _playerBall;
            }
        }
    }
}
