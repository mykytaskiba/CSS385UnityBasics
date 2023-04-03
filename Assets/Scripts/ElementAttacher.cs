using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAttacher : MonoBehaviour
{

    public Character character;
    public CharacterElement elementPrefab;
    // Start is called before the first frame update
    void Start()
    {
        CharacterElement elementInstance = elementPrefab.CreateInstance();
        character.Attach(elementInstance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
