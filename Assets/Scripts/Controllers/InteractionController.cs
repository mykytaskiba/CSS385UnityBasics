using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : Controller
{
    public override void setCharacter(Character character)
    {
        this.character = character;
    }

    Character character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithCursorItem();
        }
    }

    void InteractWithCursorItem()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] collisions = Physics2D.OverlapPointAll(mousePos);

        foreach (Collider2D collision in collisions)
        {
            IInteractable interactable = collision.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.onInteract(character);
                return;
            }
        }

    }
}
