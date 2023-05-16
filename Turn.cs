using UnityEngine;

public class Turn: MonoBehaviour
{
    public float speed = 10f; 
    public float turnSpeed = 50f; 

    private bool isTurning = false; 
    private Quaternion targetRotation; 

    private void FixedUpdate()
    {
        if (isTurning)
        {
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);

       
            if (transform.rotation == targetRotation)
            {
                isTurning = false;
            }
        }
        else
        {
       
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTurning)
        {
           
            targetRotation = Quaternion.Euler(0f, Random.Range(-90f, 90f), 0f) * transform.rotation;
            isTurning = true;
        }
    }
}
