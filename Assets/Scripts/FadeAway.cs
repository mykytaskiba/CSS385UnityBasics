using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer fadeSprite;
    [SerializeField]
    private float lifetime;

    [SerializeField]
    private bool destroyOnFade = true;

    float startTime;
    Color startingColor;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        startingColor = fadeSprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        float lifetimePercentage = (Time.time - startTime) / lifetime;
        lifetimePercentage = 1 - lifetimePercentage;
        if (lifetimePercentage <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            startingColor.a = lifetimePercentage;
            fadeSprite.color = startingColor;
        }

    }
}
