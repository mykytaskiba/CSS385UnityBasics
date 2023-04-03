using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this component colors all the parts of the character in the right colors.
//(Example: All shirt and arm parts will be the same color. 
//All the skin parts of a character will be the same color)

//It searches the hierarchy to find all ColoredComponent components and colors those
//accordingly to their slot type (based on the id from enum)

public class CharacterColorer : MonoBehaviour
{


    ColorIndexer[] indexers;
    ColoredComponent[] coloredParts;

    // Start is called before the first frame update
    void Start()
    {
        ApplyColors();
    }


    public void ApplyColors()
    {
        indexers = GetComponents<ColorIndexer>();
        coloredParts = GetComponentsInChildren<ColoredComponent>();

        foreach (ColoredComponent coloredPart in coloredParts)
        {
            foreach (ColorIndexer indexer in indexers)
            {
                if (indexer.layer == coloredPart.GetLayer())
                {
                    coloredPart.Color(indexer.color);
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
