using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RotationMode : MonoBehaviour
{

    public abstract void RotateTowards(Vector3 point);
}
