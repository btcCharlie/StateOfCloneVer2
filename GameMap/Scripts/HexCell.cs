using Godot;
using System;
using System.CodeDom.Compiler;

namespace StateOfClone
{
    public class HexCell
    {
        private Vector3 _position;
        public HexCoordinates Coordinates { get; private set; }
        public int Height { get; private set; }

        public HexCell(HexCoordinates coordinates, Vector3 position, int height)
        {
            Coordinates = coordinates;
            _position = position;
            Height = height;
        }

    }
}