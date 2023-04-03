using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectAction : Action
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Transform parent;

    [SerializeField]
    Vector3 spawnedPosition = new Vector3(0,0,0);
    [SerializeField]
    Vector3 spawnedRotation = new Vector3(0,0,0);
    [SerializeField]
    Vector3 spawnedScale = new Vector3(1,1,1);

    [SerializeField]
    private bool spawnLocalPosition = true;
    [SerializeField]
    private bool spawnLocalRotation = true;


    public override void onAction()
    {
        GameObject clone = GameObject.Instantiate(prefab);

        if (parent != null)
        {
            clone.transform.SetParent(parent, false);
        }

        if (spawnLocalPosition)
        {
            clone.transform.position = transform.position + spawnedPosition;
        } else
        {
            clone.transform.position = spawnedPosition;
        }

        if (spawnLocalRotation)
        {
            clone.transform.localRotation = Quaternion.Euler(spawnedRotation);
        } else
        {
            clone.transform.rotation = Quaternion.Euler(spawnedRotation);
        }

        clone.transform.localScale = spawnedScale;

        

    }
}
