using UnityEngine;

public class TurnTime : MonoBehaviour
{
    public float speed = 10f; // The car's speed
    public float turnSpeed = 50f; // The car's turning speed
    public float turnTime = 2f; // The time it takes for the car to turn

    private bool isTurning = false; // Flag to indicate if the car is turning
    private float turnTimer = 0f; // The timer used to keep track of the turn time

    void Update()
    {
        if (!isTurning) // If the car is not turning
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime); // Move the car forward

            if (transform.position.z >= 5f) // If the car reaches the end of the straight path
            {
                isTurning = true; // Set the flag to indicate that the car is turning
            }
        }
        else // If the car is turning
        {
            turnTimer += Time.deltaTime; // Increase the turn timer

            if (turnTimer >= turnTime) // If the turn is complete
            {
                isTurning = false; // Set the flag to indicate that the car is no longer turning
                turnTimer = 0f; // Reset the turn timer
            }
            else // If the turn is not complete yet
            {
                transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime); // Turn the car
            }
        }
    }
}
