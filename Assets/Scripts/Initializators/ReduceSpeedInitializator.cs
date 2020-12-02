using System.Collections.Generic;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public class ReduceSpeedInitializator
    {
        private List<ReduceSpeedController> _reduceSpeed;

        internal List<ReduceSpeedController> GetReduceSpeedBonuses
        {
            get
            {
                if (_reduceSpeed == null)
                {
                    _reduceSpeed = new List<ReduceSpeedController>();
                    var reduceSpeedBonusObject = Resources.Load<GameObject>("ReduceSpeedBonus");
                    var reduceSpeedBonusInst = Object.Instantiate(reduceSpeedBonusObject);
                    var reduceSpeedBonusDivider = reduceSpeedBonusInst.GetComponentsInChildren<ReduceSpeedController>();
                    for (int i = 0; i < reduceSpeedBonusDivider.Length; i++)
                    {
                        _reduceSpeed.Add(reduceSpeedBonusDivider[i]);
                    }
                }

                return _reduceSpeed;
            }
        }
    }
}
