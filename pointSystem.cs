using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointSystem : MonoBehaviour
{
    public Transform[] points; 
    public float lookAheadDistance = 10.0f; 
    public float maxSteeringAngle = 45.0f; 
    public float maxSpeed = 10.0f; 
    public float accelerationRate = 2.0f; 
    public float decelerationRate = 2.0f; 

    private int currentPoint = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // calculate the lookahead point
        Vector3 lookaheadPoint = transform.position + transform.forward * lookAheadDistance;

        // find the nearest point on the path
        int nearestPointIndex = FindNearestPointIndex(points, transform.position);
        Vector3 nearestPoint = points[nearestPointIndex].position;
        Vector3 nextPoint = points[(nearestPointIndex + 1) % points.Length].position;

        // calculate the angle to the nearest point
        float angle = Vector3.SignedAngle(transform.forward, nearestPoint - transform.position, Vector3.up);

        // calculate the steering angle
        float delta = Mathf.Atan2(2.0f * transform.localScale.z * Mathf.Sin(Mathf.Deg2Rad * angle), lookAheadDistance);

        // limit the steering angle
        delta = Mathf.Clamp(delta, -maxSteeringAngle, maxSteeringAngle);

        // calculate the desired speed
        float distance = Vector3.Distance(transform.position, nearestPoint);
        float desiredSpeed = Mathf.Clamp(distance / lookAheadDistance, 0.0f, 1.0f) * maxSpeed;

        // apply acceleration and deceleration
        float speed = rb.velocity.magnitude;
        float rate = speed < desiredSpeed ? accelerationRate : decelerationRate;
        float acceleration = Mathf.Clamp((desiredSpeed - speed) * rate, -1.0f, 1.0f);
        rb.AddForce(transform.forward * acceleration, ForceMode.Acceleration);

        // apply steering
        transform.Rotate(Vector3.up, delta * Time.fixedDeltaTime * Mathf.Rad2Deg);

        // switch to the next point if reached
        if (distance < lookAheadDistance && currentPoint < points.Length - 1)
        {
            currentPoint++;
        }
    }

    int FindNearestPointIndex(Transform[] points, Vector3 position)
    {
        int nearestIndex = 0;
        float nearestDistance = float.MaxValue;

        for (int i = 0; i < points.Length; i++)
        {
            float distance = Vector3.Distance(points[i].position, position);
            if (distance < nearestDistance)
            {
                nearestIndex = i;
                nearestDistance = distance;
            }
        }

        return nearestIndex;
    }
}
