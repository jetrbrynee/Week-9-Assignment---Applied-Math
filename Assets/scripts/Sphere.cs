using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public Material sphereMaterial;
    public float sphereRadius = 2.0f;
    public int latitudeSegments = 20;
    public int longitudeSegments = 20;

    private void OnPostRender()
    {
        DrawSphere();
    }

    public void OnDrawGizmos()
    {
        DrawSphere();
    }

    public void DrawSphere()
    {
       

        GL.PushMatrix();
        GL.Begin(GL.LINES);
        sphereMaterial.SetPass(0);

        DrawSphereShape(transform.position, sphereRadius, latitudeSegments, longitudeSegments);

        GL.End();
        GL.PopMatrix();
    }

    private void DrawSphereShape(Vector3 center, float radius, int latSegments, int longSegments)
    {
        for (int lat = 0; lat <= latSegments; lat++)
        {
            float theta = Mathf.PI * lat / latSegments;
            float sinTheta = Mathf.Sin(theta);
            float cosTheta = Mathf.Cos(theta);

            for (int lon = 0; lon <= longSegments; lon++)
            {
                float phi = 2 * Mathf.PI * lon / longSegments;
                float sinPhi = Mathf.Sin(phi);
                float cosPhi = Mathf.Cos(phi);

                float x = center.x + radius * sinTheta * cosPhi;
                float y = center.y + radius * cosTheta;
                float z = center.z + radius * sinTheta * sinPhi;

                GL.Vertex(new Vector3(x, y, z));
            }
        }

        for (int lon = 0; lon <= longSegments; lon++)
        {
            float phi = 2 * Mathf.PI * lon / longSegments;
            float sinPhi = Mathf.Sin(phi);
            float cosPhi = Mathf.Cos(phi);

            for (int lat = 0; lat <= latSegments; lat++)
            {
                float theta = Mathf.PI * lat / latSegments;
                float sinTheta = Mathf.Sin(theta);
                float cosTheta = Mathf.Cos(theta);

                float x = center.x + radius * sinTheta * cosPhi;
                float y = center.y + radius * cosTheta;
                float z = center.z + radius * sinTheta * sinPhi;

                GL.Vertex(new Vector3(x, y, z));
            }
        }
    }
}
