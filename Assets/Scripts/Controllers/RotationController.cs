using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : Controller
{
    private RotationMode rotationMode;

    public override void setCharacter(Character character)
    {
        rotationMode = character.getRotation();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rotationMode.RotateTowards(cameraPos);
    }
}
