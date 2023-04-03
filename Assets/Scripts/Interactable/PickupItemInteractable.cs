using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private ItemBase item;

    [SerializeField]
    private int quantity = 1;

    //override
    private ItemInstance instance;

    public void onInteract(Character actor)
    {
        actor.GetInventory().addItem(GetInstance());



        //this works but i dont like calling validate in this script
        //i wonder if it can be moved somewhere in the inventory script
        actor.Validate();
        GameObject.Destroy(gameObject);
    }

    ItemInstance GetInstance()
    {
        if (instance != null)
        {
            return instance;
        }

        ItemInstance result = item.createInstance();
        result.setQuantity(quantity);
        return result;
    }

    public void SetItem(ItemInstance instance)
    {
        this.instance = instance;
    }

}
