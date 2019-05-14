using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMesh : MonoBehaviour
{
    Mesh mesh;
    
    public float degreeIncrements = 5.0f;
    public float rayLength = 50.0f;
    public float cutAwayDistance = 2.0f;

    float targetAngle = 45.0f;
    float stepCount;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void LateUpdate()
    {
        RayCaster();
    }

    void RayCaster()
    {
        List<Vector3> hitPoints = new List<Vector3>();

        RaycastHit hit;

        stepCount = 2 * (45 / degreeIncrements) + 2;    

        for (int i = 0; i < stepCount - 1; i++)
        {
            targetAngle = ((45 - degreeIncrements * i) * Mathf.Deg2Rad);

            var dir = transform.TransformDirection(Mathf.Sin(targetAngle), 0, Mathf.Cos(targetAngle));

            if (Physics.Raycast(transform.position, dir * rayLength, out hit))
            {
                Debug.DrawRay(transform.position, dir * rayLength, Color.red);
                hitPoints.Add(hit.point);
            }
            else
            {
                Debug.DrawRay(transform.position, dir * rayLength, Color.blue);
                hitPoints.Add(transform.position + dir * rayLength);
            }
            
        }

        int vertexCount = hitPoints.Count + 1;
        Vector3[] verticies = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        verticies[0] = Vector3.zero;

        for (int i = 0; i < vertexCount - 1; i++)
        {
            verticies[i + 1] = transform.InverseTransformPoint(hitPoints[i]) + Vector3.forward * cutAwayDistance;

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
