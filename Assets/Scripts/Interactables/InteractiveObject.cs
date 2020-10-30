using UnityEngine;
using System;
using Random = UnityEngine.Random;

namespace ShipovMihail_Roll_A_Boll
{
    public abstract class InteractiveObject : MonoBehaviour, IInteracteble, IComparable<InteractiveObject>
    {

        protected Color _color;
        public bool IsInteractable { get; } = true;

        private void OnTriggerEnter(Collider other)
        {
            if(!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            Destroy(gameObject);
        }

        protected abstract void Interaction();

        public int CompareTo(InteractiveObject other)
        {
            return name.CompareTo(other.name);
        }

        public void Action()
        {
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

    }
}
