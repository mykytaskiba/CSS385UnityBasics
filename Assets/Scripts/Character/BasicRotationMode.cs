using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRotationMode : RotationMode
{
    [SerializeField]
    private float acceleration;

    float currentDegree;
    float targetDegree;
    public override void RotateTowards(Vector3 targetPoint)
    {

        Vector3 characterPos = gameObject.transform.position;

        targetDegree = Mathf.Rad2Deg * Mathf.Atan2(targetPoint.y - characterPos.y, targetPoint.x - characterPos.x);


    }

    // Update is called once per frame
    void Update()
    {
        currentDegree = Mathf.LerpAngle(currentDegree, targetDegree, acceleration * Time.deltaTime);

        gameObject.transform.rotation = Quaternion.Euler(0, 0, currentDegree);

    }
}
