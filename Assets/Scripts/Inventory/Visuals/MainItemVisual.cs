using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainItemVisual : InventoryItemVisual
{

    [SerializeField]
    private InventoryItemVisual[] affectedVisuals;

    public override void SetItem(ItemInstance instance)
    {
        foreach (InventoryItemVisual visual in affectedVisuals)
        {
            visual.SetItem(instance);
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
