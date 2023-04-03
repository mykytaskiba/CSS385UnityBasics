using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantifiableInstance : ItemInstance
{
    public QuantifiableInstance(ItemBase baseItem) : base(baseItem)
    {

    }

    public bool Decrement()
    {
        if (quantity > 0)
        {
            quantity--;
            return true;
        }
        return false;
    }
    public override void onStack(ref ItemInstance other)
    {
        QuantifiableInstance otherQuantifiable = other as QuantifiableInstance;
        QuantifiableBase baseQuantifiable = baseItem as QuantifiableBase;
        if (otherQuantifiable != null)
        {
            if (otherQuantifiable.baseItem == baseItem)
            {
                int stackAdded = otherQuantifiable.quantity;
                int stackNeeded = baseQuantifiable.GetMaxStack() - quantity;
                stackAdded = Mathf.Min(stackAdded, stackNeeded);
                quantity += stackAdded;
                otherQuantifiable.quantity += -stackAdded;

                if (otherQuantifiable.quantity == 0)
                {
                    other = null;
                }
            }
        }
    }
}
