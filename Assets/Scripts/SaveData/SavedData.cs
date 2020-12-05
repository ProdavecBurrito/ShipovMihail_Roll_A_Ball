using System;

namespace ShipovMihail_Roll_A_Boll
{
    [Serializable]
    internal class SavedData
    {
        public string Name;
        public bool IsEnable;
        public SerializableVector3 Position;

        public override string ToString() => $"Name {Name} Position {Position} IsVisible {IsEnable}";

    }
}
