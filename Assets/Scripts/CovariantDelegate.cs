namespace ShipovMihail_Roll_A_Boll
{
    internal class CovariantDelegate
    {
        public delegate T CovarDelegate<out T>();

        public CovariantDelegate()
        {
            CovarDelegate<InteractiveObject> covarDelegate = Create;
        }

        internal InteractiveObject Create()
        {
            return new GoodBonusController();
        }
    }
}
