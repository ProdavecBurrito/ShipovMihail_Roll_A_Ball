using UnityEngine;
using System;


namespace ShipovMihail_Roll_A_Boll
{
    public abstract class InteractiveObject : MonoBehaviour, IInteracteble, IComparable<InteractiveObject>
    {
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
    }
}
