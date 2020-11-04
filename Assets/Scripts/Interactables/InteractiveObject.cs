﻿using UnityEngine;


namespace ShipovMihail_Roll_A_Boll
{
    public abstract class InteractiveObject : MonoBehaviour, IInteracteble, IUpdate
    {

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

        public abstract void UpdateTick();

        private void Start()
        {
            IsInteractable = true;
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

    }
}
