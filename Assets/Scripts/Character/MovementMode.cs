using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementMode : MonoBehaviour
{

    public abstract void Move(Vector2 direction);
}
