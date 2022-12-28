using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class ObstacleRenderer : MonoBehaviour
{

    private const int fieldHeight = 10;
    private const int fieldWidth = 10;

    private const float blockHeight = 1;
    private const float blockWidth = 1;
    
    private int[,] Blocks = new int [fieldWidth, fieldHeight];
    private List<Vector3> vertices = new List<Vector3>();
    private List<int> triangles = new List<int>();

    private void Start()
    {
        Mesh mesh = new Mesh();

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        for (int i = 0; i < fieldWidth; i++)
        {
            for (int j = 0; j < fieldHeight; j++)
            {
                if (i + j % 2 == 0)
                {
                    CreateObstacle(new Vector3Int(i, j, 0));
                }
            }
        }

        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void CreateObstacle(Vector3Int obstaclePosition)
    {
        vertices.Add(new Vector3(0, 0, 0) + obstaclePosition);
        vertices.Add(new Vector3(0, blockHeight, 0) + obstaclePosition);
        vertices.Add(new Vector3(blockWidth, 0, 0) + obstaclePosition);
        vertices.Add(new Vector3(blockWidth, blockHeight, 0) + obstaclePosition);

        AddSquare();
    }

    private void AddSquare()
    {
        triangles.Add(triangles.Count - 4);
        triangles.Add(triangles.Count - 3);
        triangles.Add(triangles.Count - 2);

        triangles.Add(triangles.Count - 3);
        triangles.Add(triangles.Count - 1);
        triangles.Add(triangles.Count - 2);
    }
}
