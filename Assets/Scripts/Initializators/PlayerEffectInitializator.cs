namespace ShipovMihail_Roll_A_Boll
{
    public class PlayerEffectInitializator
    {
        private PlayerEffects _playerEffects;

        internal PlayerEffects GetPlayerEffects
        {
            get
            {
                if (_playerEffects == null)
                {
                    _playerEffects = new PlayerEffects();
                }

                return _playerEffects;
            }
        }
    }
}
