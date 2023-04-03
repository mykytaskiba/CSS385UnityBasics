using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectAction : Action
{

    [SerializeField]
    private GameObject destroyedObject;

    public override void onAction()
    {
        GameObject.Destroy(destroyedObject);
    }
}
