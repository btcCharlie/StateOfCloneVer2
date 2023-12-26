using Godot;

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
        }

        private void GenerateCell()
        {

        }
    }
}