using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterElement : MonoBehaviour
{

    protected Character character;

    public CharacterElement CreateInstance()
    {

        GameObject clone = GameObject.Instantiate(gameObject);
        CharacterElement cloneElement = clone.GetComponent<CharacterElement>();
        
        return cloneElement;
    }

    public void Attach(Character character)
    {
        this.character = character;

        transform.SetParent(character.GetPivot());
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;

        onAttach();

    }

    public void Detach()
    {
        onDetach();
        character = null;
    }

    protected abstract void onAttach();
    protected abstract void onDetach();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
