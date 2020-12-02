using System.Collections.Generic;

namespace ShipovMihail_Roll_A_Boll
{
    internal sealed class PlayerEffects : IUpdate
    {
        public PlayerEffects()
        {
            if (this == null)
            {

            }
        }

        private Timer _timer;
        public List<Timer> Timers = new List<Timer>();
        private PlayerBall _player;

        internal PlayerEffects GetPlayerEffects
        {
            get
            {
                return this;
            }
        }

        public void UpdateTick()
        {
            if (Timers.Count != 0)
            {
                for (int i = 0; i < Timers.Count; i++)
                {
                    Timers[i].IsTimeOver();
                    if (!Timers[i].IsOn)
                    {
                        StopEffect(Timers[i]);
                        i = 0;
                    }
                }
            }
        }

        public void BustSpeed(float time)
        {
            AddTimer();
            _timer.Init(time);
            _player.CurrentSpeed = _player.CurrentSpeed * 2.0f;
        }

        public void ReduceSpeed(float time)
        {
            AddTimer();
            _timer.Init(time);
            _player.CurrentSpeed = _player.CurrentSpeed / 2.0f;
        }

        public void AddTimer()
        {
            _timer = new Timer();
            Timers.Add(_timer);
        }

        public void StopEffect(Timer timer)
        {
            timer.Reset();
            Timers.Remove(timer);
            _player.CurrentSpeed = _player.NormalSpeed;
        }
    }
}
