﻿using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class ReduceSpeedController : ReduceSpeedBase
    {
        public delegate void ReduceSpeedBonus(float time);
        public event ReduceSpeedBonus ReduceSpeed = delegate (float time) { };

        public override void AwakeTick()
        {
            base.AwakeTick();
            _flyHight = Random.Range(1f, 2f);
            _rotationSpeed = Random.Range(5f, 180f);
            _material = GetComponent<Renderer>().material;
        }

        protected override void Interaction()
        {
            ReduceSpeed.Invoke(BoostTime);
        }

        public override void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _flyHight), transform.position.z);
        }

        public override void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        public override void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _rotationSpeed), Space.World);
        }

        public override void UpdateTick()
        {
            Flicker();
            Fly();
            Rotation();
        }
    }
}
