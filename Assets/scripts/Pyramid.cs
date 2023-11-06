using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    public float pyramidHeight = 4.0f; // Set the height of the pyramid
    public float pyramidBaseWidth = 4.0f; // Set the width of the pyramid's base
    public Vector3 pyramidCenter = new Vector3(0, 0, 0); // Set the center position of the pyramid
    public Material pyramidMaterial; // Assign the material in the Unity Inspector

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
        if (pyramidMaterial == null)
        {
            Debug.LogError("You need to add a material");
            return;
        }

        GL.PushMatrix();
        GL.Begin(GL.LINES);
        pyramidMaterial.SetPass(0);

        // Implement code to draw a pyramid here.
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
        GL.Vertex(frontLeft);
        GL.Vertex(frontRight);
        GL.Vertex(frontRight);
        GL.Vertex(backRight);
        GL.Vertex(backRight);
        GL.Vertex(backLeft);
        GL.Vertex(backLeft);
        GL.Vertex(frontLeft);

        // Draw front and back faces
        GL.Vertex(apex);
        GL.Vertex(frontLeft);
        GL.Vertex(apex);
        GL.Vertex(frontRight);
        GL.Vertex(apex);
        GL.Vertex(backLeft);
        GL.Vertex(apex);
        GL.Vertex(backRight);

        GL.End();
    }
}
