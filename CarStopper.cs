using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStopper : MonoBehaviour
{
    private WayPointMover wayPointMover;


    private void Awake()
    {
        wayPointMover = GetComponentInParent<WayPointMover>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<StopPoint>() != null)
        {
            wayPointMover.StopCar();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<StopPoint>() != null)
        {

            wayPointMover.PlayCar();
        }
    }
}
