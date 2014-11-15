using System;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
public class WaterWavesWithAngle : MonoBehaviour
{
    [Tooltip("The Scale of the waves")]
    [Range(0, 10)]
    public float Scale = 0.6f;
    [Tooltip("The waves' speed")]
    [Range(0, 10)]
    public float Speed = 1.0f;

    [Tooltip("The waves' angle in degree")]
    [Range(0, 360)]
    public float Angle = 90;
    public float Frequency = 1.8f;

    //private variables
    private float angoloRadianti;
    private Vector3[] baseHeight;
    private Mesh mesh;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        baseHeight = mesh.vertices;
    }

    void Update()
    {
        angoloRadianti = Mathf.Deg2Rad * Angle;//(Angle * Mathf.PI) / 180f;        
        Vector3[] vertices = new Vector3[baseHeight.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.z += Mathf.Sin((Time.time * Speed +
                                    vertex.x * Mathf.Sin(angoloRadianti) +
                                    vertex.y * Mathf.Cos(angoloRadianti)) * Frequency) * Scale;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
