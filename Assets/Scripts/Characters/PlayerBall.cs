namespace ShipovMihail_Roll_A_Boll
{
    internal class PlayerBall : Player
    {
        private void Update()
        {
            Jump();
        }

        private void FixedUpdate()
        {
            Move();
        }
    }
}
