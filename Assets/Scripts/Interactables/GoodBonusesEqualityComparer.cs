using System.Collections.Generic;

namespace ShipovMihail_Roll_A_Boll
{
    public sealed class GoodBonusesEqualityComparer : IEqualityComparer<GoodBonus>
    {
        public bool Equals(GoodBonus a, GoodBonus y) => a.Point == y.Point;

        public int GetHashCode(GoodBonus bonus) => bonus.Point.GetHashCode();
    }
}
