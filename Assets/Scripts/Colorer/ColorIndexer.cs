using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIndexer : MonoBehaviour
{
    //The color indexer, links a color to a layer for this specific character

    public ColoredLayer layer;
    public Color color;

    private void OnValidate()
    {
        GetComponent<CharacterColorer>().ApplyColors();
    }
}
