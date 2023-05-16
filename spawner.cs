using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public Transform spawnPos2;
    public GameObject spawnee2;

    // Update is called once per frame
    void Start()
    {
        {
            Instantiate(spawnee2, spawnPos2.position, spawnPos2.rotation);
        }
    }
}
