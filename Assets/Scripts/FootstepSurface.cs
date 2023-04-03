using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSurface : MonoBehaviour
{
    [SerializeField]
    private SoundProfile footstepSound;

    [SerializeField]
    private int layer;

    public bool isHigherPriority(FootstepSurface other)
    {
        return (layer > other.layer);
    }
    public SoundProfile getFootstepSound()
    {
        return footstepSound;
    }

}
