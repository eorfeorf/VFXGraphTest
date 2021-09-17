using System;
using UnityEngine;
using UnityEngine.VFX;

public class VFX05 : MonoBehaviour
{
    [SerializeField] private MeshFilter meshFilter;

    private VisualEffect visualEffect;
    private GraphicsBuffer positionBuffer;

    private Vector3[] vertices;

    private void Start()
    {
        var vc = meshFilter.mesh.vertexCount;
        positionBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, vc, 3 * sizeof(float));
        visualEffect = GetComponent<VisualEffect>();
        
        vertices = new Vector3[meshFilter.mesh.vertices.Length];
    }

    private void OnDestroy()
    {
        positionBuffer?.Dispose();
        positionBuffer = null;
    }

    private void Update()
    {
        meshFilter.mesh.vertices.CopyTo(vertices, 0);
        
        positionBuffer.SetData(vertices);
        visualEffect.SetGraphicsBuffer("PositionBuffer", positionBuffer);
        // compute.SetFloat("Time", Time.time);
        // compute.SetBuffer(0, "PointBuffer", buffer);
        // compute.Dispatch(0, 8, 8, 1);
    }
}