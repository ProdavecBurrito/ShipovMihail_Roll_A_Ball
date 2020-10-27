﻿using System.Collections.Generic;

namespace ShipovMihail_Roll_A_Boll
{
    internal class GoodBonusComparer : IComparer<GoodBonus>
    {
        public int Compare(GoodBonus x, GoodBonus y)
        {
            if (x.Point > y.Point)
            {
                return 1;
            }
            
            if (x.Point < y.Point)
            {
                return -1;
            }
            return 0;
        }
    }
}
