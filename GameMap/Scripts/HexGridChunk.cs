using Godot;
using System.Collections.Generic;

namespace StateOfClone.GameMap
{
    public class HexGridChunk
    {
        private Vector3 _startPosition;

        public int Width { get; private set; }
        public int Height { get; private set; }

        private HexCell[] cells;

        public HexGridChunk(int width, int height, Vector3 start)
        {
            Width = width;
            Height = height;
            _startPosition = start;
            cells = new HexCell[width * height];
        }

        public void CreateChunk()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Height; z++)
                {
                    HexCoordinates coordinates = HexCoordinates.FromGridPosition(x, z);
                    HexCell newCell = new(coordinates, )
                }
            }
        }


    }
}