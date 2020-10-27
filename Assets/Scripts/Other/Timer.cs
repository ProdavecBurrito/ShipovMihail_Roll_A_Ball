using static UnityEngine.Debug;
using UnityEngine;
using System;

namespace ShipovMihail_Roll_A_Boll
{
    public class Timer : IUpdate
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

        public void UpdateTick()
        {
            IsTimeOver();
        }

        public void IsTimeOver()
        {
            Log(CurrentTime);
            if (IsOn)
            {
                Log(CurrentTime);
                if (CurrentTime < EndTime)
                {
                    Log(CurrentTime);
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
