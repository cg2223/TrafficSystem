using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerInt : MonoBehaviour
{
    [SerializeField] private GameObject truckTrigger;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("truck"))
        {

            truckTrigger.SetActive(false);
        }

    }




}
