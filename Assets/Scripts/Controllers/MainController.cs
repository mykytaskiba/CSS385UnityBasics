using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : Controller
{
    [SerializeField]
    private Character controlledCharacter;

    private Controller[] subControllers;

    public override void setCharacter(Character character)
    {
        character.SetController(this);

        foreach (Controller controller in subControllers)
        {
            //prevents recursion
            if (controller != this)
            {
                controller.setCharacter(character);
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        subControllers = GetComponents<Controller>();
        setCharacter(controlledCharacter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Validate()
    {
        foreach (Controller controller in subControllers)
        {
            //prevents recursion
            if (controller != this)
            {
                controller.Validate();
            }
        }
    }
}
