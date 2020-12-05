using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class NewTest : MonoBehaviour
    {
        public int Count = 10;
        public int Offset = 1;
        public GameObject TestObject;

        public float Test;
        private Transform _root;

        private void Start()
        {
            CreateObject();
        }

        public void CreateObject()
        {
            _root = new GameObject("Main").transform;
            for (var i = 1; i <= Count; i++)
            {
                Instantiate(TestObject, new Vector3(0, Offset * i, 0),
                   Quaternion.identity, _root);
            }
        }

        public void AddComponent()
        {
            gameObject.AddComponent<Rigidbody>();
            gameObject.AddComponent<MeshRenderer>();
            gameObject.AddComponent<BoxCollider>();
        }

        public void RemoveComponent()
        {
            DestroyImmediate(GetComponent<Rigidbody>());
            DestroyImmediate(GetComponent<MeshRenderer>());
            DestroyImmediate(GetComponent<BoxCollider>());
        }
    }
}
