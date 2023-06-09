using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : Controller
{
    FlashlightElement flashlight;
    bool hasFlashlight = false;
    public override void setCharacter(Character character)
    {
        flashlight = character.GetElement<FlashlightElement>();
        hasFlashlight = (flashlight != null);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (hasFlashlight)
            {
                flashlight.toggleFlashlight();
            }
        }  
    }
}
