using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredComponent : MonoBehaviour
{
    [SerializeField]
    private ColoredLayer layer;

    public ColoredLayer GetLayer()
    {
        return layer;
    }

    public void Color(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
