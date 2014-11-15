using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class WaterWaves : MonoBehaviour
{
    [Tooltip("The Scale of the waves")]
    [Range(0, 10)]
    public float Scale = 0.6f;
    [Tooltip("The waves' speed")]
    [Range(0, 10)]
    public float Speed = 1.0f;

    //private variables
    private Vector3[] baseHeight;
    private Mesh mesh;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        baseHeight = mesh.vertices;
    }

    void Update()
    {
        Vector3[] vertices = new Vector3[baseHeight.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.z += Mathf.Sin(Time.time * Speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * Scale;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
