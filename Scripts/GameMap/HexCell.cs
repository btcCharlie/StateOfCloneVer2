using Godot;
using System;
using System.CodeDom.Compiler;

namespace StateOfClone
{
    public class HexCell
    {
        private float _size;
        private Vector3 _position;
        public HexCoordinates Coordinates { get; private set; }

        public HexCell(float size, HexCoordinates coordinates, Vector3 position)
        {
            _size = size;
            _position = position;
            Coordinates = coordinates;
        }

        public void GenerateGeometry()
        {

        }
    }
}