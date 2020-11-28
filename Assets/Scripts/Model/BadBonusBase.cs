using System;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    abstract class BadBonusBase : InteractiveObject, IFly, IFlicker, IRotation, IDisposable
    {
        protected Material _material;
        protected float _flyHight;
        protected float _rotationSpeed;

        public abstract void Fly();

        public abstract void Flicker();

        public abstract void Dispose();

        public abstract void Rotation();
    }
}
