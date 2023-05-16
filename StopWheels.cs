using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWheels : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        Stoprot();
    }

    public void Stoprot()
    {
        transform.Rotate(0, 0, 0);
    }
}
