using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class FieldRenderer : MonoBehaviour
{   
    [SerializeField]
    private Vector3 fieldOffset;

    private int fieldHeight = Screen.height/100;
    private int fieldWidth = Screen.width/100;
    
    private Vector3[] vertices = new Vector3[4];
    private int[] triangles = new int[6];

    private void Start()
    {
        GenerateMesh();
    }

    private void GenerateMesh()
    {
        fieldOffset = new Vector3(-fieldWidth / 2, 0, -fieldHeight / 2);

        vertices[0] = new Vector3(0, 0, 0) + fieldOffset;
        vertices[1] = new Vector3(0, 0, fieldHeight) + fieldOffset;
        vertices[2] = new Vector3(fieldWidth, 0, 0) + fieldOffset;
        vertices[3] = new Vector3(fieldWidth, 0, fieldHeight) + fieldOffset;

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
