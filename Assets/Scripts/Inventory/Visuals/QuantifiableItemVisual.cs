using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuantifiableItemVisual : InventoryItemVisual
{
    [SerializeField]
    private TextMeshProUGUI quantityText;

    public override void SetItem(ItemInstance instance)
    {
        quantityText.text = ""+instance.getQuantity();
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
