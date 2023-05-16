using UnityEngine;

public class TurnTargets: MonoBehaviour
{
    public Transform target1; 
    public Transform target2;
    public Transform target3; 

    public float moveSpeed = 10f; // Speed to move the car forward
    public float turnSpeed = 3f; // Speed to turn the car towards the second target
    public float angleThreshold = 1f; // The angle tolerance for considering the car to have reached its target

    private bool isTurning = false; // Whether the car is currently turning or moving straight
    private Vector3 currentTarget; // The current target to move towards

    void Start()
    {
        currentTarget = target1.position;
    }

    void Update()
    {
        // Check if the car is currently turning
        if (isTurning)
        {
            // Calculate the direction to the second target
            Vector3 targetDir = target2.position - transform.position;
            targetDir.y = 0f;

            // Calculate the angle to the second target
            float angle = Vector3.SignedAngle(transform.forward, targetDir, Vector3.up);

            // Rotate the car towards the second target
            transform.Rotate(Vector3.up, Mathf.Sign(angle) * turnSpeed * Time.deltaTime);

            // Check if the car has reached the second target
            if (Mathf.Abs(angle) <= angleThreshold)
            {
                isTurning = false;
                currentTarget = target3.position;
            }
        }
        else
        {
            // Move the car towards the current target
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

            // Check if the car has reached the current target
            if (transform.position == currentTarget)
            {
                // If the current target is the first target, start turning towards the second target
                if (currentTarget == target1.position)
                {
                    isTurning = true;
                }
                // If the current target is the third target, reset to the first target
                else if (currentTarget == target3.position)
                {
                    currentTarget = target1.position;
                }
            }
        }
    }
}
