using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingScript : MonoBehaviour
{
    Light light;
    bool sunny;
    public Material sunBox;
    public Material nightBox;
    public GameObject snow;

    // Start is called before the first frame updates   
    void Start()
    {
        sunny = true;
        light = GameObject.Find("mainLight").GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (sunny)
            {
                sunny = false;
                RenderSettings.skybox = nightBox;
                light.enabled = false;
                snow.SetActive(true);
                snow.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                sunny = true;
                RenderSettings.skybox = sunBox;
                light.enabled = true;
                snow.SetActive(false);
                snow.GetComponent<ParticleSystem>().Stop();
            }
        }
        if (sunny)
        {
            Vector3 rotationSpeed = new Vector3(-0.15f, 0, 0);
            light.transform.Rotate(rotationSpeed);
        }
    }
}
