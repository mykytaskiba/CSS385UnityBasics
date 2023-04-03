using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemElement : CharacterElement
{

    [SerializeField]
    private SoundProfile attachSound;
    public void SetItem(ItemInstance instance)
    {
        this.instance = instance;
    }
    private ItemInstance instance;
    public virtual void onPrimaryDown()
    {

    }
    public virtual void onPrimaryUp()
    {

    }
    public virtual void onSecondaryDown()
    {

    }
    public virtual void onSecondaryUp()
    {

    }
    public virtual void onDropDown()
    {
        GameObject dropped = instance.instantiateDropped();
        dropped.transform.position = character.getDropLocation();

        character.GetInventory().removeItem(instance);
        character.Validate();

    }
    public virtual void onDropUp()
    {

    }
    public virtual void onReloadDown()
    {

    }
    public virtual void onReloadUp()
    {

    }

    protected override void onAttach()
    {
        if (attachSound != null)
        {
            SoundManager.Get().playSound(attachSound, transform.position);
        }
    }

    protected override void onDetach()
    {
    }
}
