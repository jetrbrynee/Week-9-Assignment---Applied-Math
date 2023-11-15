using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public float cylinderRadius = 2.0f; // Set the radius of the cylinder
    public float cylinderHeight = 4.0f; // Set the height of the cylinder
    public int cylinderSegments = 12; // Set the number of segments for the cylinder
    public float baseScaleX = 1.5f; // Set the X scale factor for the base
    public float upperScaleX = 1.0f; // Set the X scale factor for the upper part
    public Vector3 cylinderCenter = new Vector3(0, 0, 0); // Set the center position of the cylinder
    public Material cylinderMaterial;

    private void OnPostRender()
    {
        DrawCylinder();
    }

    public void OnDrawGizmos()
    {
        DrawCylinder();
    }

    public void DrawCylinder()
    {
        GL.PushMatrix();
        GL.Begin(GL.LINES);
        cylinderMaterial.SetPass(0);

        DrawCylinderShape(cylinderCenter, cylinderRadius, cylinderHeight, cylinderSegments, baseScaleX, upperScaleX);

        GL.End();
        GL.PopMatrix();
    }

    private void DrawCylinderShape(Vector3 center, float radius, float height, int segments, float baseScaleX, float upperScaleX)
    {
        // Calculate the angle between segments
        float angleIncrement = 2.0f * Mathf.PI / segments;

        
        for (int i = 0; i < segments; i++)
        {
            float angle1 = i * angleIncrement;
            float angle2 = (i + 1) * angleIncrement;

            Vector3 point1 = center + new Vector3(baseScaleX * radius * Mathf.Cos(angle1), 0, radius * Mathf.Sin(angle1));
            Vector3 point2 = center + new Vector3(baseScaleX * radius * Mathf.Cos(angle2), 0, radius * Mathf.Sin(angle2));

            GL.Vertex(point1);
            GL.Vertex(point2);

            
            GL.Vertex(point1);
            GL.Vertex(center + new Vector3(0, 0, 0)); 
        }

       
        Vector3 upperBaseCenter = center + new Vector3(0, height, 0);

        for (int i = 0; i < segments; i++)
        {
            float angle1 = i * angleIncrement;
            float angle2 = (i + 1) * angleIncrement;

            Vector3 point1 = upperBaseCenter + new Vector3(upperScaleX * radius * Mathf.Cos(angle1), 0, radius * Mathf.Sin(angle1));
            Vector3 point2 = upperBaseCenter + new Vector3(upperScaleX * radius * Mathf.Cos(angle2), 0, radius * Mathf.Sin(angle2));

            GL.Vertex(point1);
            GL.Vertex(point2);

           
            GL.Vertex(point1);
            GL.Vertex(upperBaseCenter);
        }

        // Draw the vertical lines connecting the bases and forming the cylinder sides
        for (int i = 0; i < segments; i++)
        {
            float angle = i * angleIncrement;
            Vector3 point1 = center + new Vector3(baseScaleX * radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));
            Vector3 point2 = upperBaseCenter + new Vector3(upperScaleX * radius * Mathf.Cos(angle), 0, radius * Mathf.Sin(angle));

            GL.Vertex(point1);
            GL.Vertex(point2);
        }
    }
}
