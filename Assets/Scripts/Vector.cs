namespace ShipovMihail_Roll_A_Boll
{
    public class Vector
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static explicit operator Vector(double x) => new Vector(x, x);
    }
}
