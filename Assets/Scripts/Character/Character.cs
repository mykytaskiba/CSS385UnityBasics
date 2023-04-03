using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    #region Movement
    [SerializeField]
    private MovementMode movementMode;

    public MovementMode getMovement()
    {
        return movementMode;
    }
    #endregion

    #region Rotation
    [SerializeField]
    private RotationMode rotationMode;

    public RotationMode getRotation()
    {
        return rotationMode;
    }
    #endregion

    #region Pivot
    [SerializeField]
    private Transform pivot;

    public Transform GetPivot()
    {
        return pivot;
    }
    #endregion

    #region Elements
    private List<CharacterElement> elements = new List<CharacterElement>();

    public void Attach(CharacterElement element)
    {   
        elements.Add(element);
        element.Attach(this);

        Validate();
    }

    public void Detach(CharacterElement element)
    {
        elements.Remove(element);
        element.Detach();

        Validate();
    }

    public T GetElement<T>() where T : CharacterElement
    {
        foreach (CharacterElement element in elements)
        {
            T type_element = element as T;
            if (type_element != null)
            {
                return type_element;
            }

        }
        return null;
    }
    #endregion

    #region Controller

    private Controller controller;

    public void SetController(Controller controller)
    {
        this.controller = controller; 
    }


    #endregion

    #region Faction

    [SerializeField]
    private Faction faction;

    public Faction getFaction()
    {
        return faction;
    }

    #endregion

    #region Inventory

    Inventory inventory;

    [SerializeField]
    private int inventorySize;

    public Inventory GetInventory()
    {
        return inventory;
    }

    #endregion

    #region DropLocation

    [SerializeField]
    private Transform dropLocation;

    public Vector3 getDropLocation()
    {
        return dropLocation.transform.position;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory(inventorySize);
        CharacterManager.Get().AddCharacter(this);
    }
    private void OnDestroy()
    {
        CharacterManager.Get().RemoveCharacter(this);
    }
    public void Validate()
    {
        inventory.Validate();
        if (controller != null)
        {
            controller.Validate();
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
