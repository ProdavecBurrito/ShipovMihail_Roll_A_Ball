using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    class BadBonusController : BadBonusBase
    {

        public delegate void CaughtPlayerChange(string objectName, Color color);
        public event CaughtPlayerChange CaughtPlayer = delegate (string value, Color color) { };

        private void Start()
        {
            _material = GetComponent<Renderer>().material;
            _flyHight = Random.Range(0.5f, 1.5f);
            _rotationSpeed = Random.Range(15.0f, 60.0f);
        }

        protected override void Interaction()
        {
            CaughtPlayer.Invoke(gameObject.name, _color);
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
            if (IsInteractable)
            {
                Flicker();
                Fly();
                Rotation();
            }
        }

        public override void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
