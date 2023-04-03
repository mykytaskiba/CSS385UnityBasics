using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : Controller
{
    Character character;

    ItemElement item;
    bool hasItem = false;
    public override void setCharacter(Character character)
    {
        this.character = character;
        Validate();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hasItem)
            {
                item.onPrimaryDown();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (hasItem)
            {
                item.onPrimaryUp();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (hasItem)
            {
                item.onSecondaryDown();
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (hasItem)
            {
                item.onSecondaryUp();
            }
        }  

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (hasItem)
            {
                item.onDropDown();
            }
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (hasItem)
            {
                item.onDropUp();
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (hasItem)
            {
                item.onReloadDown();
            }
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            if (hasItem)
            {
                item.onReloadUp();
            }

        }
    }

    public override void Validate()
    {
        item = character.GetElement<ItemElement>();
        hasItem = (item != null);
    }

}
