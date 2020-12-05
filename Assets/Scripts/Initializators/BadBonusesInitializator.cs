using System.Collections.Generic;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class BadBonusesInitializator
    {
        private List<BadBonusController> _badBonuses;

        internal List<BadBonusController> GetBadBonus
        {
            get
            {
                if (_badBonuses == null)
                {
                    _badBonuses = new List<BadBonusController>();
                    var badBonusObject = Resources.Load<GameObject>("BadBonus");
                    var badBonusInst = Object.Instantiate(badBonusObject);
                    var badBonusDivider = badBonusInst.GetComponentsInChildren<BadBonusController>();
                    foreach (var item in badBonusDivider)
                    {
                        _badBonuses.Add(item);
                    }
                }

                return _badBonuses;
            }
        }
    }
}
