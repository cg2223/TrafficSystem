using UnityEngine;

public class Turn5points : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    public float turnSpeed = 2f;
    private int currentWaypoint = 0;
    private float targetAngle = 0f;
    private bool turning = false;

    void Update()
    {
        Vector3 targetDirection = waypoints[currentWaypoint].position - transform.position;
        float angleToWaypoint = Vector3.Angle(transform.forward, targetDirection);

        // check if the car is close enough to the current waypoint to move to the next one
        if (targetDirection.magnitude < 0.5f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
            turning = false;
        }

        // check if the car is currently turning
        if (turning)
        {
            // rotate the car towards the target angle
            float angleDifference = Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle);
            if (Mathf.Abs(angleDifference) > 0.5f)
            {
                float rotationAmount = Mathf.Sign(angleDifference) * turnSpeed * Time.deltaTime;
                transform.Rotate(Vector3.up, rotationAmount);
            }
            else
            {
                turning = false;
            }
        }
        else
        {
            // move the car towards the current waypoint
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // check if the car needs to turn
            if (angleToWaypoint > 30f)
            {
                targetAngle = Vector3.SignedAngle(transform.forward, targetDirection, Vector3.up);
                turning = true;
            }
        }
    }

    // draw gizmos to show the waypoints in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        foreach (Transform waypoint in waypoints)
        {
            Gizmos.DrawSphere(waypoint.position, 0.2f);
        }
    }
}
