using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheeltruckScript : MonoBehaviour
{

    public Vector3 wheelTruckRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(wheelTruckRotation * Time.deltaTime);
    }
}
