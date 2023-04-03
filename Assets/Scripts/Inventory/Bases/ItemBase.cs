using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    public abstract ItemInstance createInstance();

    [SerializeField]
    private GameObject visual;

    [SerializeField]
    private GameObject characterElement;

    [SerializeField]
    private GameObject droppedItem;

    [SerializeField]
    private Sprite sprite;

    public Sprite GetSprite()
    {
        return sprite;
    }

    public GameObject instantiateVisual()
    {
        return GameObject.Instantiate(visual);
    }
    public ItemElement instantiateElement()
    {
        return characterElement.GetComponent<CharacterElement>().CreateInstance().GetComponent<ItemElement>();
    }
    public GameObject instantiateDropped()
    {
        return GameObject.Instantiate(droppedItem);
    }
}
