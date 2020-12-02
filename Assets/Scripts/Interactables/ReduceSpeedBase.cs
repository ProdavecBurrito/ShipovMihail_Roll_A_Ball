using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal abstract class ReduceSpeedBase : InteractiveObject, IFly, IRotation, IFlicker
    {
        protected float _flyHight;
        protected float _rotationSpeed;
        protected Material _material;
        protected PlayerEffects _playerEffects;
        private float boostTime = 5.0f;

        public float BoostTime { get => boostTime; private set => boostTime = value; }

        public abstract void Fly();

        public abstract void Rotation();

        public abstract void Flicker();
    }
}
