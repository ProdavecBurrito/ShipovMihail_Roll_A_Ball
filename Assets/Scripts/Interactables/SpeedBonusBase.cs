using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal abstract class SpeedBonusBase : InteractiveObject, IFly, IRotation, IFlicker
    {
        protected PlayerEffects _playerEffects;
        protected float _flyHight;
        protected float _rotationSpeed;
        protected Material _material;
        protected float _boostTime = 5.0f;

        public abstract void Fly();

        public abstract void Flicker();

        public abstract void Rotation();
    }
}
