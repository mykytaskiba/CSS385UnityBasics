using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    public Character character;
    public Item weapon1;
    public Item weapon2;
    public Item weapon3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            clearWeapon();
            character.Attach(weapon1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            clearWeapon();
            character.Attach(weapon2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            clearWeapon();
            character.Attach(weapon3 );
        }

    }

    void clearWeapon()
    {
        Item weapon = character.GetElement<Item>();
        if (weapon != null)
        {
            character.Detach(weapon);
        }
    }
}
