using static UnityEngine.Debug;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class Timer
    {
        public float CurrentTime { get; private set; }
        public float EndTime { get; set; }
        public bool IsOn;

        public void Init(float time)
        {
            EndTime = time;
            IsOn = true;
        }

        public void Reset()
        {
            CurrentTime = 0.0f;
            IsOn = false;
        }

        public void IsTimeOver()
        {
            if (IsOn)
            {
                if (CurrentTime < EndTime)
                {
                    CurrentTime += Time.deltaTime;
                }
                else
                {
                    Reset();
                }
            }
        }
    }
}
