using System;

namespace ShipovMihail_Roll_A_Boll
{
    internal class ValueException : Exception
    {
        public float Value { get; }
        public string Text { get; }
        public ValueException(string text, float value)
        {
            Value = value;
            Text = text;
        }
    }
}
