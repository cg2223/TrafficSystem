using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    //private GameObject wheelFrontLeft;
    //private GameObject wheelFrontRight;
    //private GameObject wheelRearLeft;
    //private GameObject wheelRearRight;



    public Vector3 _rotation;
    public Rigidbody carRigidbody;
    private bool active = true;




    //private void Start()
    //{
    //    wheelRigidbody = transform.parent.GetComponent<Rigidbody>();
    //    wheelFrontLeft = transform.Find("WheelFrontLeft").gameObject;
    //    wheelFrontRight = transform.Find("WheelFrontRight").gameObject;
    //    wheelRearLeft = transform.Find("WheelRearLeft").gameObject;
    //    wheelRearRight = transform.Find("WheelRearRight").gameObject;


    //}

    void Update()
    {
        if (active)
        {

            if (carRigidbody.velocity.magnitude < 0.1f)

                transform.Rotate(0, 0, 0);

            else transform.Rotate(_rotation * Time.deltaTime);



        }
    }



    // Start is called before the first frame update

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "RailroadGate")
    //    {
    //        wheelFrontLeft.transform.Rotate(0, 0, 0);
    //        wheelFrontRight.transform.Rotate(0, 0, 0);
    //        wheelRearLeft.transform.Rotate(0, 0, 0);
    //        wheelRearRight.transform.Rotate(0, 0, 0);
    //}


    public void StopWheels()
    {
        if (carRigidbody.velocity.magnitude < 0.1)
        {
            transform.Rotate(0, 0, 0);
        }
        //wheelRigidbody.isKinematic = true;
        active = false;

    }




    public void PlayWheels()
    {
        transform.Rotate(_rotation * Time.deltaTime);
        active = true;
    }





    //private void Awake()
    //{
    //    GetComponentInParent<Rotation>();
    //}



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.GetComponent<StopPoint>() != null)
    //    {
    //        StopWheels();
    //    }
    //}


    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.GetComponent<StopPoint>())

    //        PlayWheels();
    //}
}

























    //public void StopWheel()
    //{
    //    transform.Rotate(0, 0, 0);
    //    wheelRigidbody.isKinematic = true;
    //    Active = false;
    //}

    //public void PlayWheel()
    //{
    //    wheelRigidbody.isKinematic = false;
    //}

    //private void Awake()
    //{
    //    GetComponentInParent<Rotation>();
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.GetComponent<Stopper>() != null)
    //    {
    //        StopWheel();
    //    }
    //}


    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.GetComponent<Stopper>() != null)
    //    {
    //        PlayWheel();
    //    }
    //}



