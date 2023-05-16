using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TrafficSystemObjects : MonoBehaviour
{
    public List<Transform> waypoints;
    public bool stopAtRailroadGate;

    private int currentWaypoint = 0;
    private bool waitingForGate = false;

    void Update()
    {
        if (currentWaypoint < waypoints.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, Time.deltaTime * 5);

            if (stopAtRailroadGate && waypoints[currentWaypoint].tag == "RailroadGate" && !waitingForGate)
            {
                waitingForGate = true;
                StartCoroutine(StopAtGate());
            }

            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
            {
                currentWaypoint++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator StopAtGate()
    {
        while (true)
        {
            if (!waitingForGate)
            {
                yield break;
            }

            yield return new WaitForSeconds(0.1f);

            if (waypoints[currentWaypoint].tag == "RailroadGate" && waypoints[currentWaypoint].GetComponent<RailroadGate>().isDown)
            {
                waitingForGate = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            currentWaypoint--;
        }
    }
}

public class RailroadGate : MonoBehaviour
{
    public bool isDown = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            isDown = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            isDown = false;
        }
    }
}