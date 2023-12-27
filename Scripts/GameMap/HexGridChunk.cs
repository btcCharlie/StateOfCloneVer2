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
        }

        private void GenerateCell(ref List<Vector3> vertices, ref List<int> triangles)
        {
            float deltaZ = 0.5f * HexMetrics.HexSize;
            Vector3 origin = _startPosition;

            Vector3[] vertexCornersBuffer = new Vector3[7];

            // north, northeast, southeast, south, southwest, northwest, 
            // north (again for looping)
            vertexCornersBuffer[0] =
                _startPosition + new Vector3(0, 0, HexMetrics.HexSize);
            vertexCornersBuffer[1] =
                _startPosition + new Vector3(HexMetrics.HexSizeInner, 0, deltaZ);
            vertexCornersBuffer[2] =
                _startPosition + new Vector3(HexMetrics.HexSizeInner, 0, -deltaZ);
            vertexCornersBuffer[3] =
                _startPosition + new Vector3(0, 0, -HexMetrics.HexSize);
            vertexCornersBuffer[4] =
                _startPosition + new Vector3(-HexMetrics.HexSizeInner, 0, deltaZ);
            vertexCornersBuffer[5] =
                _startPosition + new Vector3(-HexMetrics.HexSizeInner, 0, -deltaZ);
            vertexCornersBuffer[6] = vertexCornersBuffer[0];

            // List<Vector3> vertices = new();
            // List<int> triangles = new();

            int triangleIdx = vertices.Count;
            for (int dir = 0; dir <= 5; dir++)
            {
                vertices.Add(origin);
                vertices.Add(vertexCornersBuffer[dir]);
                vertices.Add(vertexCornersBuffer[dir + 1]);

                triangles.Add(triangleIdx);
                triangles.Add(triangleIdx + 1);
                triangles.Add(triangleIdx + 2);
                triangleIdx += 3;
            }
        }
    }
}