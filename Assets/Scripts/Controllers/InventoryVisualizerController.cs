using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryVisualizerController : Controller
{


    [SerializeField]
    private InventorySlotVisual[] slots;

    Inventory inventory;

    public override void setCharacter(Character character)
    {
        inventory = character.GetInventory();
        ResetInventoryDisplay();
    }

    public override void Validate()
    {
        ResetInventoryDisplay();
    }

    void ResetInventoryDisplay()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetItem(inventory.getItemAt(i));
        }
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
