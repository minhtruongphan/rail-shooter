using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WaypointMover : MonoBehaviour
{
    public GameObject[] waypoints;
    public float rotSpeed;
    public float speed;

    int current = 0;
    float WPradius = 1f;


    void Update()
    {
        MoveWaypoint();
    }

    private void MoveWaypoint()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        RotateWaypoints();
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, speed * Time.deltaTime);
    }

    private void RotateWaypoints()
    {
        Vector3 targetDirection = waypoints[current].transform.position - transform.position;
        float stepSize = rotSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, stepSize);
    }




}
