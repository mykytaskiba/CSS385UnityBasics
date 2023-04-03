using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotVisual : MonoBehaviour
{

    GameObject currentItem;

    [SerializeField]
    private GameObject selectedUI;

    public void setSelected(bool b)
    {
        selectedUI.SetActive(b);
    }

    public void SetItem(ItemInstance item)
    {
        ClearItem();
        if (item != null)
        {
            currentItem = item.instantiateVisual();
            currentItem.transform.SetParent(transform, false);
        }
    }
    void ClearItem()
    {
        if (currentItem != null)
        {
            GameObject.Destroy(currentItem);
            currentItem = null;
        }
    }
}
