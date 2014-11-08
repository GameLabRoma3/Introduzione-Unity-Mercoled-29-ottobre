using UnityEngine;
using System.Collections;

public class sea : MonoBehaviour
{
    public float scale = 0.6f;
    public float speed = 1.0f;
    public float noiseStrength = 2.0f;
    private Vector3[] baseHeight;

    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        if (baseHeight == null)
            baseHeight = mesh.vertices;

        var vertices = new Vector3[baseHeight.Length];
        for (var i = 0; i < vertices.Length; i++)
        {
            var vertex = baseHeight[i];
            vertex.z += Mathf.Sin(Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
            vertex.z += Mathf.PerlinNoise(baseHeight[i].x + 0.2f, baseHeight[i].y + Mathf.Sin(Time.time * 0.1f)) * noiseStrength;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
