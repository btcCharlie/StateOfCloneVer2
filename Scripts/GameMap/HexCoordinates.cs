using Godot;
using System;

namespace StateOfClone
{
    public struct HexCoordinates
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public readonly int Z
        {
            get { return -X - Y; }
        }

        public HexCoordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public HexCoordinates(int x, int y, int z)
        {
            if (x + y != -z)
            {
                throw new ArgumentException(
                    $"Hex coordinates must sum to 0! ({x}; {y}; {z})"
                    );
            }

            X = x;
            Y = y;
        }
    }
}