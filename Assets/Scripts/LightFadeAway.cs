using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFadeAway : MonoBehaviour
{
    [SerializeField]
    private Light2D controlledLight;
    [SerializeField]
    private float lifetime;

    [SerializeField]
    private bool destroyOnFade = true;

    float startTime;
    float startingIntensity;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        startingIntensity = controlledLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        float lifetimePercentage = (Time.time - startTime) / lifetime;
        lifetimePercentage = 1 - lifetimePercentage;
        if (lifetimePercentage <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            controlledLight.intensity = startingIntensity * lifetimePercentage; 
        }

    }
}
