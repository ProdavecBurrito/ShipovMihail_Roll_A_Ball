﻿using System;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public abstract class GoodBonusBase : InteractiveObject, IFly, IFlicker, IUpdate, IDisposable
    {

        public float Point = 1;

        protected Material _material;
        protected float _flyHight;

        public abstract void Fly();

        public abstract void Flicker();

        public abstract void Dispose();
    }
}
