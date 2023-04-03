using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Controller
{
    private Transform centerTransform;
    public override void setCharacter(Character character)
    {
        transform.position = character.transform.position;
        transform.parent = character.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
