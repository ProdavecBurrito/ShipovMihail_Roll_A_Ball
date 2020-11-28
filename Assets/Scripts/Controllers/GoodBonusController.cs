using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class GoodBonusController : GoodBonusBase
    {
        public delegate void BonusChangeValue(float value);
        public event BonusChangeValue BonusChange = delegate (float val) { };

        public override void AwakeTick()
        {
            _material = GetComponent<Renderer>().material;
            _flyHight = Random.Range(1.0f, 2.0f);
        }

        protected override void Interaction()
        {
            BonusChange.Invoke(Point);
        }

        public override void Fly()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, _flyHight), transform.position.z);
        }

        public override void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1.0f));
        }

        public override void UpdateTick()
        {
            if (IsInteractable)
            {
                Fly();
                Flicker();
            }
        }

        public override void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
