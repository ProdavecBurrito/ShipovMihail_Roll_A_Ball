using System;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal sealed class CaughtPlayerEventArgs : EventArgs
    {
        public Color Color { get; }

        public CaughtPlayerEventArgs(Color color)
        {
            Color = color;
        }
    }
}
