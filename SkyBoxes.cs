using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SkyBoxes : MonoBehaviour
{

    private static SkyBoxes gameManager;

    public Material skybox_a;
    public Material skybox_b;
    public Material skybox_c;
    public Material skybox_d;

    private void Awake()
    {

        if(gameManager != null && gameManager != this)
        {
            Destroy(gameObject);
            return;
        }

        gameManager = this;

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Scenario 1 Area A")
            RenderSettings.skybox = skybox_a;
        else if (scene.name == "Scenario 1 Area B")
            RenderSettings.skybox = skybox_b;
        else if (scene.name == "Scenario 1 Area C")
            RenderSettings.skybox = skybox_c;
        else if (scene.name == "Scenario 1 Area D")
            RenderSettings.skybox = skybox_d;
    }


}
