using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySelectionController : Controller
{
    [SerializeField]
    private InventorySlotVisual[] slots;

    Inventory inventory;
    Character character;

    CharacterElement currentEquiped;

    ItemInstance lastItem;

    int selected = 0;

    float lastChangedTime;

    [SerializeField]
    private float scrollCooldown = 0.05f;
    public override void setCharacter(Character character)
    {
        this.character = character;
        inventory = character.GetInventory();
        ResetDisplay();
    }

    public override void Validate()
    {
        ResetDisplay();
    }


    void ResetDisplay()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].setSelected(false);
        }
        slots[selected].setSelected(true);

        HandleCurrentElement();
    }

    void HandleCurrentElement()
    {
        ItemInstance currentItem = inventory.getItemAt(selected);
        if (lastItem == currentItem)
        {
            return;
        }

        lastItem = currentItem;

        if (currentEquiped != null)
        {
            character.Detach(currentEquiped);
            GameObject.Destroy(currentEquiped.gameObject);
            currentEquiped = null;
        }


        ItemInstance currentInstance = inventory.getItemAt(selected);
        if (currentInstance != null)
        {
            currentEquiped = currentInstance.instantiateElement();
            character.Attach(currentEquiped);
        }
    }

    void ChangeSelected(int delta)
    {
        if (Time.time - lastChangedTime < scrollCooldown)
        {
            return;
        }

        lastChangedTime = Time.time;

        int lastSlot = slots.Length - 1;
        selected += delta;
        if (selected < 0)
        {
            selected = lastSlot;
        }
        if (selected > lastSlot)
        {
            selected = 0;
        }
        ResetDisplay();

    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseInput = Input.mouseScrollDelta.y;

        if (mouseInput > 0)
        {
            ChangeSelected(-1);
        }
        if (mouseInput < 0)
        {
            ChangeSelected(1);
        }

    }
}
