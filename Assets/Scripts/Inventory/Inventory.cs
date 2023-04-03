using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public Inventory(int size)
    {
        setSize(size);
    }

    void setSize(int size)
    {
        inventorySize = size;
        contents = new ItemInstance[inventorySize];
    }

    int inventorySize;
    ItemInstance[] contents;
    public bool hasItemAt(int i)
    {
        if (i < 0 || i >= contents.Length)
        {
            return false;
        }

        return (contents[i] != null);
    }
    int findOpenSlot()
    {
        for (int i = 0; i < contents.Length; i++)
        {
            if (contents[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    public void Validate()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (contents[i] != null)
            {
                if (!contents[i].Validate())
                {
                    removeItemAt(i);
                }
            }
        }
    }

    public ItemInstance addItem(ItemInstance itemInstance)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (contents[i] != null)
            {
                contents[i].onStack(ref itemInstance);
            }
        }
        if (itemInstance != null)
        {
            int index = findOpenSlot();

            if (index != -1)
            {
                itemInstance = addItem(itemInstance, index);
            }
        }
        return itemInstance;


    }
    
    private ItemInstance addItem(ItemInstance itemInstance, int index)
    {
        //itemInstance.setInventory(this);
        contents[index] = itemInstance;
        return null;



    }
    public ItemInstance removeItemAt(int i)
    {
        if (!hasItemAt(i))
        {
            return null;
        }
        ItemInstance temp = contents[i];
        contents[i] = null;
        return temp;
    }
    public ItemInstance removeItem(ItemInstance removedItem)
    {
        for (int i = 0; i < contents.Length; i++)
        {
            if (contents[i] == removedItem)
            {
                return removeItemAt(i);
            }
        }
        return null;
    }
    public ItemInstance getItemAt(int i)
    {
        if (!hasItemAt(i))
        {
            return null;
        }
        return contents[i];
    }

    public ItemInstance GetItemOfType(ItemBase itemBase)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (contents[i] != null)
            {
                if (contents[i].IsBase(itemBase))
                {
                    return contents[i];
                }
            }
        }
        return null;
    }
    /*
    public void validate()
    {
        for (int i = 0; i < contents.Length; i++)
        {
            validate(i);
        }
    }
    public void validate(int index)
    {
        if (contents[index] != null)
        {
            if (!contents[index].validate())
            {
                contents[index] = null;
            }
        }
    }*/

    /*
    public ItemInstance addItem(ItemInstance itemInstance, int index)
    {
        if (hasItemAt(index))
        {

            itemInstance = contents[index].onStack(itemInstance);

            return itemInstance;
        }
        else
        {
            itemInstance.setInventory(this);
            contents[index] = itemInstance;
            return null;
        }



    }*/


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
