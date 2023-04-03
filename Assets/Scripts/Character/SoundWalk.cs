using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWalk : MonoBehaviour
{
    float distanceTravelled;

    Rigidbody2D rb;

    [SerializeField]
    private float distancePerFootstep;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += rb.velocity.magnitude * Time.deltaTime;
        if (distanceTravelled > distancePerFootstep)
        {
            SoundProfile sound = GetCurrentFootstepSound();
            distanceTravelled += -distancePerFootstep;
            if (sound != null)
            {
                SoundManager.Get().playSound(sound, transform.position);
            }
        }
    }

    SoundProfile GetCurrentFootstepSound()
    {
        int layerMask = LayerMask.GetMask("FootstepSurface");
        Collider2D[] collisions = Physics2D.OverlapPointAll(transform.position, layerMask);

        FootstepSurface currentSurface = null;
        foreach (Collider2D collision in collisions)
        {
            FootstepSurface surface = collision.GetComponent<FootstepSurface>();
            if (surface != null)
            {
                if (currentSurface == null || surface.isHigherPriority(currentSurface))
                {
                    currentSurface = surface;
                }
            }
        }

        if (currentSurface != null)
        {
            return currentSurface.getFootstepSound();
        }

        return null;


    }
}
