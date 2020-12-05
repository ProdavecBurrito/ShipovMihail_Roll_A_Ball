using UnityEngine;


namespace ShipovMihail_Roll_A_Boll
{
    internal abstract class InteractiveObject : MonoBehaviour, IInteracteble, IUpdate, ISaving, IAwake
    {
        [SerializeField] private bool _isAllowScaling;
        [SerializeField] private float _activeDis;

        protected Color _color;
        private bool _isInteractable;
        public bool IsInteractable
        {
            get => _isInteractable;
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;            
            }
        }

        public virtual void AwakeTick()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            IsInteractable = false;
            Interaction();
        }

        protected abstract void Interaction();

        public abstract void UpdateTick();

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "Doggi.jpg", _isAllowScaling);
        }

        private void OnDrawGizmosSelected()
        {
#if UNITY_EDITOR
            if (IsInteractable)
            {
                var flat = new Vector3(_activeDis, 0, _activeDis);
                Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, flat);
                Gizmos.DrawWireSphere(Vector3.zero, 5);
            }
#endif
        }

    }
}
