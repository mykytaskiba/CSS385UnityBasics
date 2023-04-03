using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : Controller
{

    private MovementMode movementMode;

    public override void setCharacter(Character character)
    {
        movementMode = character.getMovement();
    }

    //public MovementAnimation anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = 0;
        float yMovement = 0;
        if (Input.GetKey(KeyCode.A))
        {
            xMovement = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xMovement = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            yMovement = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            yMovement = -1;
        }

        Vector2 input = new Vector2(xMovement, yMovement);
        movementMode.Move(input);
    }
}
