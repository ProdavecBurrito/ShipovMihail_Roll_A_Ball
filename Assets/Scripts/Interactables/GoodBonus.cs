using UnityEngine;
using static UnityEngine.Debug;
using System;
using Random = UnityEngine.Random;

namespace ShipovMihail_Roll_A_Boll
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker, IUpdate, IDisposable
    {
        public int Point;

        private DisplayScore _displayScore;
        private Material _material;
        private float _flyHight;

        private void Awake()
        {
            _displayScore = new DisplayScore();
        }

        private void Start()
        {
            _material = GetComponent<Renderer>().material;
            _flyHight = Random.Range(1.0f, 2.0f);
        }

        protected override void Interaction()
        {
            _displayScore.Display(Point);
        }

        public void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _flyHight), transform.position.z);

        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        public void UpdateTick()
        {
            Fly();
            Flicker();
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
