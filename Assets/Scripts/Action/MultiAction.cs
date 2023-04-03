using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAction : Action
{

    [SerializeField]
    private Action[] actions;

    public override void onAction()
    {
        foreach (Action action in actions)
        {
            action.onAction();
        }
    }
}
