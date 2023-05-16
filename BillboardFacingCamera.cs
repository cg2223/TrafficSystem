using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardFacingCamera : MonoBehaviour
{
    [SerializeField] bool freezeXZAxis = true;

    // Update is called once per frame
    void Update()
    {

        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(270f, Camera.main.transform.rotation.eulerAngles.y, 0f);
        }
        else
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
