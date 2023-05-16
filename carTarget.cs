using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carTarget : MonoBehaviour
{

    public Transform target;
    public Rigidbody rb;
    public float t;
    public float speed;
    public float force;
    public Vector3 moveDirection;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        //transform.position = target.position;

        //Vector3 a = transform.position;
        //Vector3 b = target.position;
        //transform.position = Vector3.Lerp(a, b, t);

        //Vector3 a = transform.position;
        //Vector3 b = target.position;
        //transform.position = Vector3.MoveTowards(a, b, speed);

        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.MoveTowards(a, Vector3.Lerp(a, b, t), speed);



        //Vector3 f = target.position - transform.position;
        //f = f.normalized;
        //f = f * force;
        //rb.AddForce(f);


        //transform.Translate(moveDirection, Space.World);


        //public float t2;

        //    public float speed2;
        //public Rigidbody rb2;
        //public Transform target2;
        //public Vector3 moveDirection2;


        //transform.position = target.position;

        //Vector3 a2 = transform.position;
        //Vector3 b2 = target2.position;
        //transform.position = Vector3.Lerp(a2,b2,t);

        //Vector3 a2 = transform.position;
        //Vector3 b2 = target.position;
        //transform.position = Vector3.MoveTowards(a2,b2,speed);

        //Vector3  a2 = transform.position;
        // Vector3 b2 = target.position;
        //transform.position = Vector3.MoveTowards(a,Vector3.Lerp(a,b,t),speed);

        //Vector3 f = target.position - transform.position;
        // f =f.normalized;
        //f = f* force;
        //rb.AddForce(f);























    }
}
