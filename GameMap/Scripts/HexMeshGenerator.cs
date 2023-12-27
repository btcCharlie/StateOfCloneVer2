using Godot;
using System.Collections.Generic;

namespace StateOfClone.GameMap
{
    public class HexMeshGenerator
    {
        private List<Vector3> vertices;
        private List<Vector3> normals;
        private List<int> triangles;

        public HexMeshGenerator()
        {
            vertices = new();
            normals = new();
            triangles = new();
        }

        public void Clear()
        {
            vertices?.Clear();
            normals?.Clear();
            triangles?.Clear();
        }

        public void GenerateCellFull(Vector3 origin)
        {
            float deltaZ = 0.5f * HexMetrics.midCorner;
            Vector3[] vertexCornersInner = new Vector3[7];

            // north, northeast, southeast, south, southwest, northwest, 
            // north (again for looping)
            vertexCornersInner[0] =
                origin + new Vector3(0, 0, HexMetrics.midCorner);
            vertexCornersInner[1] =
                origin + new Vector3(HexMetrics.midSide, 0, deltaZ);
            vertexCornersInner[2] =
                origin + new Vector3(HexMetrics.midSide, 0, -deltaZ);
            vertexCornersInner[3] =
                origin + new Vector3(0, 0, -HexMetrics.midCorner);
            vertexCornersInner[4] =
                origin + new Vector3(-HexMetrics.midSide, 0, deltaZ);
            vertexCornersInner[5] =
                origin + new Vector3(-HexMetrics.midSide, 0, -deltaZ);
            vertexCornersInner[6] = vertexCornersInner[0];

            Vector3 first = vertexCornersInner[0];
            Vector3 second;
            for (int dir = 0; dir < 6; dir++)
            {
                second = vertexCornersInner[dir + 1];
                GenerateTriangle(origin, first, second);
                first = second;
            }
        }

        public void GenerateCellMiddle(Vector3 origin)
        {
            float deltaZ = 0.5f * HexMetrics.hexSizeCorner;
            Vector3[] vertexCornersBuffer = new Vector3[7];

            // north, northeast, southeast, south, southwest, northwest, 
            // north (again for looping)
            vertexCornersBuffer[0] =
                origin + new Vector3(0, 0, HexMetrics.hexSizeCorner);
            vertexCornersBuffer[1] =
                origin + new Vector3(HexMetrics.hexSizeSide, 0, deltaZ);
            vertexCornersBuffer[2] =
                origin + new Vector3(HexMetrics.hexSizeSide, 0, -deltaZ);
            vertexCornersBuffer[3] =
                origin + new Vector3(0, 0, -HexMetrics.hexSizeCorner);
            vertexCornersBuffer[4] =
                origin + new Vector3(-HexMetrics.hexSizeSide, 0, deltaZ);
            vertexCornersBuffer[5] =
                origin + new Vector3(-HexMetrics.hexSizeSide, 0, -deltaZ);
            vertexCornersBuffer[6] = vertexCornersBuffer[0];

            Vector3 first = vertexCornersBuffer[0];
            Vector3 second;
            for (int dir = 0; dir < 6; dir++)
            {
                second = vertexCornersBuffer[dir + 1];
                GenerateTriangle(origin, first, second);
                first = second;
            }
        }

        private void GenerateTriangle(
            Vector3 bottomVert, Vector3 topLeftVert, Vector3 topRightVert
            )
        {
            int triangleIdx = vertices.Count;

            vertices.Add(bottomVert);       // 0
            vertices.Add(topLeftVert);      // 1
            vertices.Add(topRightVert);     // 2

            triangles.Add(triangleIdx);
            triangles.Add(triangleIdx + 1);
            triangles.Add(triangleIdx + 2);
        }

        private void GenerateQuad(
            Vector3 bottomLeftVert, Vector3 topLeftVert,
            Vector3 topRightVert, Vector3 bottomRightVert
            )
        {
            int triangleIdx = vertices.Count;

            vertices.Add(bottomLeftVert);
            vertices.Add(topLeftVert);
            vertices.Add(topRightVert);
            vertices.Add(bottomRightVert);

            triangles.Add(triangleIdx);     // 0
            triangles.Add(triangleIdx + 1); // 1
            triangles.Add(triangleIdx + 2); // 2

            triangles.Add(triangleIdx);     // 0
            triangles.Add(triangleIdx + 2); // 2
            triangles.Add(triangleIdx + 3); // 3
        }
    }
}