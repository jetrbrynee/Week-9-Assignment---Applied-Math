using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    public Material pyramidMaterial;
    public float pyramidHeight = 4.0f;
    public float pyramidBaseWidth = 4.0f;
    public Vector3 pyramidCenter = new Vector3(0, 0, 0);

    private void OnPostRender()
    {
        DrawPyramid();
    }

    public void OnDrawGizmos()
    {
        DrawPyramid();
    }

    public void DrawPyramid()
    {
       

        GL.PushMatrix();
        GL.Begin(GL.LINES);
        pyramidMaterial.SetPass(0);

        DrawPyramidShape(pyramidCenter, pyramidHeight, pyramidBaseWidth);

        GL.End();
        GL.PopMatrix();
    }

    private void DrawPyramidShape(Vector3 center, float height, float baseWidth)
    {
        // Calculate half of the base width
        float halfBaseWidth = baseWidth * 0.5f;

        // Define the pyramid's vertices
        Vector3 apex = center + new Vector3(0, height * 0.5f, 0);
        Vector3 frontLeft = center + new Vector3(-halfBaseWidth, -height * 0.5f, -halfBaseWidth);
        Vector3 frontRight = center + new Vector3(halfBaseWidth, -height * 0.5f, -halfBaseWidth);
        Vector3 backLeft = center + new Vector3(-halfBaseWidth, -height * 0.5f, halfBaseWidth);
        Vector3 backRight = center + new Vector3(halfBaseWidth, -height * 0.5f, halfBaseWidth);

        // Draw base edges
        DrawLine(center, frontLeft);
        DrawLine(center, frontRight);
        DrawLine(center, backLeft);
        DrawLine(center, backRight);

        // Draw front and back faces
        DrawLine(frontLeft, frontRight);
        DrawLine(frontRight, backRight);
        DrawLine(backRight, backLeft);
        DrawLine(backLeft, frontLeft);

        // Connect the corners of the base to the apex
        DrawLine(frontLeft, apex);
        DrawLine(frontRight, apex);
        DrawLine(backLeft, apex);
        DrawLine(backRight, apex);
    }

    private void DrawLine(Vector3 start, Vector3 end)
    {
        GL.Vertex(start);
        GL.Vertex(end);
    }
}
