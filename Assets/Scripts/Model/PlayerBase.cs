using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public abstract class PlayerBase : MonoBehaviour
    {

        public float NormalSpeed = 5.0f;
        public float CurrentSpeed = 0;
        public float JumpForce = 5.0f;

        public abstract void Move(float x, float y, float z);

        public abstract void Jump(bool value);
    }
}
