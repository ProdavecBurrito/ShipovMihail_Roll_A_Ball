using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            var objects = new ListInteractableObject();

            for (int i = 0; i < objects.Count; i++)
            {
                print($"{objects[i]}");
            }
        }


    }
}
