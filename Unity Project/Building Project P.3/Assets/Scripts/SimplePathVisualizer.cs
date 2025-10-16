/*This script handles some visualization aspects of the navigation path rendered created between the player and the destination*/
using UnityEngine;
using UnityEngine.AI;

public class SimplePathVisualizer : MonoBehaviour
{
    public NavMeshAgent agent;
    public LineRenderer lineRenderer;
    public float heightOffset = 0.1f;

    /*The 'Update()' function checkes whether or not a path has been created, and only then raises the path create by the given 'heightOffset'
    for a better visualization for the user*/
    void Update()
    {
        if (agent != null && agent.hasPath)
        {
            var corners = agent.path.corners;
            lineRenderer.positionCount = corners.Length;

            for (int i = 0; i < corners.Length; i++)
            {
                Vector3 raisedCorner = corners[i];
                raisedCorner.y += heightOffset;
                lineRenderer.SetPosition(i, raisedCorner);
            }
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }
}
