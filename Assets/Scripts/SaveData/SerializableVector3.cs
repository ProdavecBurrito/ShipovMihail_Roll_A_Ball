using UnityEngine;
using System;

namespace ShipovMihail_Roll_A_Boll
{
    [Serializable]
    public struct SerializableVector3
    {
        public float X;
        public float Y;
        public float Z;

        public SerializableVector3(float valueX, float valueY, float valueZ)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
        }

        public static implicit operator Vector3(SerializableVector3 vector3)
        {
            return new Vector3(vector3.X, vector3.Y, vector3.Z);
        }

        public static implicit operator SerializableVector3(Vector3 vector3)
        {
            return new SerializableVector3(vector3.x, vector3.y, vector3.z);
        }

        public override string ToString()
        {
            return $" (X = {X} Y = {Y} Z = {Z})";
        }
    }
}


