using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : CharacterElement
{
    public abstract void Primary();
    public abstract void PrimaryContinous();

    protected override void onDetach()
    {
        GameObject.Destroy(gameObject);
    }
}
