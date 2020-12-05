using System.Collections.Generic;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class SpeedBonusInitializator
    {
        private List<SpeedBonusController> _speedBonus;

        internal List<SpeedBonusController> GetSpeedBonus
        {
            get
            {
                if (_speedBonus == null)
                {
                    _speedBonus = new List<SpeedBonusController>();
                    var speedBonusObject = Resources.Load<GameObject>("SpeedBonus");
                    var speedBonusInst = Object.Instantiate(speedBonusObject);
                    var speedBonusDivider = speedBonusInst.GetComponentsInChildren<SpeedBonusController>();
                    foreach (var item in speedBonusDivider)
                    {
                        _speedBonus.Add(item);
                    }
                }

                return _speedBonus;
            }
        }
    }
}
