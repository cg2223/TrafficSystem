using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionColliders : MonoBehaviour
{


    public float maxSpeed = 10.0f; //max speed of the car
    public float brakeDistance = 5.0f; //distance at which the car will start to brake
    public float stopDistance = 1.0f; // distance at which the car will stop

    private bool isBraking = false; //the car is currently braking
    private Rigidbody rigidBody; // the car's rigidbody component


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        Vector3 velocity = rigidBody.velocity;
        float speed = velocity.magnitude;
        Vector3 direction = velocity.normalized;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, brakeDistance))
        {
            if (hit.collider.CompareTag("Car"))
            {
                isBraking = true;

            }


            else if (hit.collider.CompareTag("Intersection"))
            {
                isBraking = false;
            }
        }

        if (isBraking)
        {
            float brakingForce = Mathf.Clamp((speed / brakeDistance) * rigidBody.mass, 0.0f, maxSpeed);
            rigidBody.AddForce(-direction * brakingForce);


            if (hit.distance <= stopDistance)
            {
                speed = 0.0f;
            }

        }
        else
        {
            float accelerationForce = Mathf.Clamp((maxSpeed-speed)* rigidBody.mass, 0.0f, maxSpeed);
            rigidBody.AddForce(direction * accelerationForce);
        }
    }
   

}
