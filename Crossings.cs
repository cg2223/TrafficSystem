using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossings : MonoBehaviour
{ 
    public List<Transform> waypoints;
    public float speed = 10f;
    public float stoppingDistance = 1f;
    private int currentWaypoint =0;

    // Start is called before the first frame update
    void Start()
    {
        // Agent position to the position of the first waypoint
        transform.position = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        //see if agent has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < stoppingDistance)
        {
            //if the car has reached the last waypoint
            if (currentWaypoint == waypoints.Count - 1)
            {
                currentWaypoint = 0; 
            }
            //otherwise, move to the next 
            else
            {
                currentWaypoint++;
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

            
        }

      

    }

    // Move the car method to stop the car at the current waypoint
    public void StopWaypoint()
    {
        //Set the current waypoint to the last 
        currentWaypoint--;

        speed = 0;
    }

    public void ResumeMovement()
    {
        speed = 10f;
    }



}
