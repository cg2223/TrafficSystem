using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMover : MonoBehaviour
{

    //Stores a reference to the waypoint system this object will use
    [SerializeField] private Waypoint2 waypoints;

    [SerializeField] private float moveSpeed = 5f;

    [Range(0f, 15f)] // How fast the agent will rotate once it reaches its waypoint

    [SerializeField] private float rotateSpeed = 4.0f;
    [SerializeField] private float distanceThreshold = 0.1f;

    public string instantTag = "RailroadGate";


    public Rigidbody carRigidbody;
    private bool active = true;


    //private Rotation rotation;
    //private StopWheels stopWheels;




    //The current waypoint target that the object is moving forward
    private Transform currentWaypoint;

    //The rotation target for the current frame
    private Quaternion rotationGoal;
    //The direction to the next waypoint that the agent needs to rotate towards
    private Vector3 directionToWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        //set initial position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //Set the next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
        carRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()

    {

        if (Active)
        {


            //moves the agent 1 way point
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            //moves the agent to the next waypoints
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {

                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                //transform.LookAt(currentWaypoint);

            }
            RotateTowardsWaypoint();
        }
    }
    //will slowly rotate the agent towards the current waypoint it is moving torwards
    private void RotateTowardsWaypoint()
    {
        directionToWaypoint = (currentWaypoint.position - transform.position);
        rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
    }
    public void StopCar()
    {

        carRigidbody.velocity = Vector3.zero;

        carRigidbody.angularVelocity = Vector3.zero;

        carRigidbody.isKinematic = true;

        Active = false;
        //stopWheels.Stoprot();

    }
    private bool Active = true;
    public void PlayCar()
    {

        carRigidbody.isKinematic = false;

        Active = true;

    }
    //private void Awake()
    //{
    //   GetComponentInParent<WayPointMover>();
    //    //rotation = GetComponentInParent<Rotation>();
    //    //stopWheels = GetComponentInParent<StopWheels>();

    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.GetComponent<StopPoint>() != null)
    //    {
    //        StopCar();
            
          
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.GetComponent<StopPoint>() != null)
    //    {

    //       PlayCar();
    //    }
    //}
}
