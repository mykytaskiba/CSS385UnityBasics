using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInstance
{
    public ItemInstance(ItemBase baseItem)
    {
        this.baseItem = baseItem;
    }

    public virtual void onStack(ref ItemInstance other)
    {

    }

    public virtual bool Validate()
    {
        return (quantity > 0);
    }

    public GameObject instantiateVisual()
    {
        GameObject visual = baseItem.instantiateVisual();
        visual.GetComponent<MainItemVisual>().SetItem(this);
        return visual;
    }

    public ItemElement instantiateElement()
    {
        ItemElement element = baseItem.instantiateElement();
        element.SetItem(this);
        return element;
    }
    public GameObject instantiateDropped()
    {
        GameObject dropped = baseItem.instantiateDropped();
        dropped.GetComponent<PickupItemInteractable>().SetItem(this);
        return dropped;
    }

    public int getQuantity()
    {
        return quantity;
    }
    public void setQuantity(int quantity)
    {
        this.quantity = quantity;
    }

    public Sprite GetSprite()
    {
        return baseItem.GetSprite();
    }

    public bool IsBase(ItemBase baseItem)
    {
        return (this.baseItem == baseItem);
    }

    protected ItemBase baseItem;
    protected int quantity = 1;
}
