using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal abstract class ReduceSpeedBase : InteractiveObject, IFly, IRotation, IFlicker
    {
        protected float _flyHight;
        protected float _rotationSpeed;
        protected Material _material;
        protected PlayerEffects _playerEffects;
        protected float _boostTime = 5.0f;

        public abstract void Fly();

        public abstract void Rotation();

        public abstract void Flicker();
    }
}
