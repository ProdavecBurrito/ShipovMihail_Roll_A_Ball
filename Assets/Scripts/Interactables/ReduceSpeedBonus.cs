﻿using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    class ReduceSpeedBonus : InteractiveObject, IFly, IRotation, IFlicker, IUpdate
    {
        private float _flyHight;
        private float _rotationSpeed;
        private Material _material;
        private PlayerEffects _playerEffects;
        private float _boostTime = 5.0f;

        private void Start()
        {
            _flyHight = Random.Range(1f, 2f);
            _rotationSpeed = Random.Range(5f, 180f);
            _material = GetComponent<Renderer>().material;
            _playerEffects = FindObjectOfType<PlayerEffects>();
        }

        protected override void Interaction()
        {
            _playerEffects.ReduceSpeed(_boostTime);
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _flyHight), transform.position.z);

        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _rotationSpeed), Space.World);
        }

        public void UpdateTick()
        {
            Flicker();
            Fly();
            Rotation();
        }
    }
}
