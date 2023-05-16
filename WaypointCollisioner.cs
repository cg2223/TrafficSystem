using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCollisioner : MonoBehaviour
{ 
    public List<Transform> waypoints;
    public float speed = 10f;
    public float stoppingDistance = 1f;
    private int currentWaypoint = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) <stoppingDistance)
        {
            if (currentWaypoint == waypoints.Count -1)
                {

                currentWaypoint = 0;
                 }

            else
            {
                currentWaypoint++;
            }

        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
    }

    public void StopAtwaypoint()
    {
        currentWaypoint--;
        speed = 0;
    }

    public void ResumeMovement()
    {
        speed = 10f;
    }



}
