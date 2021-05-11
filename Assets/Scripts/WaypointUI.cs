using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WaypointUI : MonoBehaviour
{
    public GameObject[] waypoints;
    int numPoints;

    private void OnDrawGizmos()
    {
        DrawGizmos(false);
    }
    private void OnDrawGizmosSelected()
    {
        DrawGizmos(true);
    }
    private void DrawGizmos(bool selected)
    {
        numPoints = waypoints.Length;
        if (numPoints > 1)
        {
            Gizmos.color = selected ? Color.yellow : new Color(1, 1, 0, 0.5f);
            Vector3 prev = waypoints[0].transform.position;
            for (int i = 1; i < numPoints; i++)
            {
                Vector3 next = waypoints[i].transform.position;
                Gizmos.DrawLine(prev, next);
                prev = next;
            }
            Gizmos.DrawLine(prev, waypoints[0].transform.position);

        }
    }
}
