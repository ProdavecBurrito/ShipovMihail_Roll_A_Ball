using System.Collections.Generic;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public class GoodBonusesInitializator
    {
        private List<GoodBonusController> _goodBonuses;

        internal List<GoodBonusController> GetGoodBonuses
        {
            get
            {
                if (_goodBonuses == null)
                {
                    _goodBonuses = new List<GoodBonusController>();
                    var goodBonusObject = Resources.Load<GameObject>("GoodBonus");
                    var goodBonusInst = Object.Instantiate(goodBonusObject);
                    var goodBonusDivider = goodBonusInst.GetComponentsInChildren<GoodBonusController>();
                    foreach (var item in goodBonusDivider)
                    {
                        _goodBonuses.Add(item);
                    }
                }

                return _goodBonuses;
            }
        }
    }
}
