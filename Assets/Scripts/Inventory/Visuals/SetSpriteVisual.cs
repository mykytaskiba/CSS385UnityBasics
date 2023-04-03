using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSpriteVisual : InventoryItemVisual
{
    [SerializeField]
    private Image image;
    public override void SetItem(ItemInstance instance)
    {
        image.sprite = instance.GetSprite();
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
