using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quantifiable Item")]
public class QuantifiableBase : ItemBase
{

    [SerializeField]
    private int maxStackSize;

    public int GetMaxStack()
    {
        return maxStackSize;
    }

    public override ItemInstance createInstance()
    {
        return new QuantifiableInstance(this);
    }

}
