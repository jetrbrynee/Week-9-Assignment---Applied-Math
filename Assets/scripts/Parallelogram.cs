using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallelogram : MonoBehaviour
{
    public float parallelogramWidth = 4.0f; 
    public float parallelogramHeight = 4.0f; 
    public float slantAngle = 30.0f; 
    public Vector3 parallelogramCenter = new Vector3(0, 0, 0); // Set the center position of the parallelogram 
    public Material parallelogramMaterial; 
    private void OnPostRender()
    {
        DrawParallelogram();
    }

    public void OnDrawGizmos()
    {
        DrawParallelogram();
    }

    public void DrawParallelogram()
    {
       

        GL.PushMatrix();
        GL.Begin(GL.LINES);
        parallelogramMaterial.SetPass(0);

        
        DrawParallelogramShape(parallelogramCenter, parallelogramWidth, parallelogramHeight, slantAngle);

        GL.End();
        GL.PopMatrix();
    }

    private void DrawParallelogramShape(Vector3 center, float width, float height, float angle)
    {
        // Calculate half of the width and height
        float halfWidth = width * 0.5f;
        float halfHeight = height * 0.5f;

        // Convert angle to radians
        float radianAngle = angle * Mathf.Deg2Rad;

        // For  Parallelogram's vertices with slant
        Vector3 bottomLeft = center + new Vector3(-halfWidth, -halfHeight, 0);
        Vector3 bottomRight = center + new Vector3(halfWidth, -halfHeight, 0);
        Vector3 topLeft = center + new Vector3(-halfWidth * Mathf.Cos(radianAngle), halfHeight * Mathf.Sin(radianAngle), 0);
        Vector3 topRight = center + new Vector3(halfWidth * Mathf.Cos(radianAngle), halfHeight * Mathf.Sin(radianAngle), 0);

        // Draw the edges of the parallelogram
        GL.Vertex(bottomLeft);
        GL.Vertex(bottomRight);
        GL.Vertex(bottomRight);
        GL.Vertex(topRight);
        GL.Vertex(topRight);
        GL.Vertex(topLeft);
        GL.Vertex(topLeft);
        GL.Vertex(bottomLeft);
    }
}
