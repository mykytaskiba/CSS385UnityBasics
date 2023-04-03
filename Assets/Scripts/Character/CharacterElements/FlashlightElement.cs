using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightElement : CharacterElement
{
    [SerializeField]
    private GameObject flashlight;

    bool active = false;

    public void toggleFlashlight()
    {
        active = !active;
        flashlight.SetActive(active);
    }

    protected override void onAttach()
    {
    }

    protected override void onDetach()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        flashlight.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
