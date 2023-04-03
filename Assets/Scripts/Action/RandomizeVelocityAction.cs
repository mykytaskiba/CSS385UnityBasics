using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeVelocityAction : Action
{
    [SerializeField]
    private Rigidbody2D controlledRigidbody;

    [SerializeField]
    private Vector3 velocityMin;
    [SerializeField]
    private Vector3 velocityMax;

    [SerializeField]
    private bool randomizeVelocityIndividual; //randomize each individual component

    [SerializeField]
    private float angularVelocityMin;
    [SerializeField]
    private float angularVelocityMax;

    public override void onAction()
    {
        Vector3 newVelocity = Random.value * (velocityMax - velocityMin) + velocityMin; 
        if (randomizeVelocityIndividual)
        {
            float x = Random.value * (velocityMax.x - velocityMin.x) + velocityMin.x;
            float y = Random.value * (velocityMax.y - velocityMin.y) + velocityMin.y;
            float z = Random.value * (velocityMax.z - velocityMin.z) + velocityMin.z;
            newVelocity = new Vector3(x, y, z);
        }

        float newAngularVelocity = Random.value * (angularVelocityMax - angularVelocityMin) + angularVelocityMin;

        controlledRigidbody.velocity = newVelocity;
        controlledRigidbody.angularVelocity = newAngularVelocity;
    }

}
