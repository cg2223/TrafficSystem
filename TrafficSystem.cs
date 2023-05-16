using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSystem : MonoBehaviour
{
    public float speed = 5f;
    public float stoppingDistance = 1f;
    public bool stop = false;
    private int currentWaypointIndex;
    private List<Transform> waypoints;
    private Transform currentWaypoint;
                                                        
    private void Start()
    {
        currentWaypointIndex = 0;
        waypoints = new List<Transform>();
        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            waypoints.Add(waypoint.transform);
        }
        currentWaypoint = waypoints[currentWaypointIndex];
    }
    void Update()
    {
        if (!stop)
        {
            Move();
        }
    }
    private void Move ()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, step);       
        if (Vector3.Distance(transform.position, currentWaypoint.position) < stoppingDistance)
        {
            if (currentWaypointIndex == waypoints.Count -1 )
            {
                Destroy(gameObject);
            }
            else
            {
                currentWaypointIndex++;
                currentWaypoint = waypoints[currentWaypointIndex];

            }
        }
    }
    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Stop"))
        {
            stop = true;

        }

            else if (other.gameObject.CompareTag("Go"))

        {

            stop = false;
        }
    }
}
