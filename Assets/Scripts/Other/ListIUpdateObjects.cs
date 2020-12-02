using System.Collections.Generic;

namespace ShipovMihail_Roll_A_Boll
{
    class ListIUpdateObjects
    {
        private List<IUpdate> _interactiveObjects;

        public void RemoveUpdatingObject(IUpdate interactiveObject)
        {
            _interactiveObjects.Remove(interactiveObject);
        }

        public IUpdate this[int index]
        {
            get => _interactiveObjects[index];
            private set => _interactiveObjects[index] = value;
        }

        public void AddUpdateObject(IUpdate interactiveObject)
        {
            if (_interactiveObjects == null)
            {
                _interactiveObjects = new List<IUpdate>();
            }
            _interactiveObjects.Add(interactiveObject);
        }

        public int Count => _interactiveObjects.Count;

        public int Current => _interactiveObjects.Count - 1;

    }
}
