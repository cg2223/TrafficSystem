using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsRotation : MonoBehaviour
{

    public Quaternion startQuaternion;
    public float lerpTime = 1;
    public bool rotate;

    // Start is called before the first frame update
    void Start()
    {
        startQuaternion = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(rotate)
        transform.rotation = Quaternion.Lerp(transform.rotation, startQuaternion, Time.deltaTime * lerpTime);
    }


    public void snapRotation()
    {
        transform.rotation = startQuaternion;
    }
}
