using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Item
{

    [SerializeField]
    private Transform slashSpawnPoint;

    [SerializeField]
    private GameObject slashPrefab;

    [SerializeField]
    private Transform rotationPivot;

    [SerializeField]
    private float rotationOut;

    [SerializeField]
    private float swingTime;

    [SerializeField]
    private float recoveryTime;

    [SerializeField]
    private SoundProfile swingSound;

    GameTimer swingTimer;
    GameTimer recoveryTimer;

    bool swinging = false;
    bool recovering = false;

    public override void Primary()
    { 
        if (!swinging && !recovering)
        {
            swingTimer.StartTimer();
            swinging = true;
        }
    }

    public override void PrimaryContinous()
    {
    }

    void Swing()
    {

        GameObject clone = GameObject.Instantiate(slashPrefab);
        clone.transform.position = slashSpawnPoint.position;
        clone.transform.rotation = transform.rotation;

        SoundManager.Get().playSound(swingSound, transform.position);
    }

    protected override void onAttach()
    {
        swingTimer = new GameTimer(swingTime);
        recoveryTimer = new GameTimer(recoveryTime);
    }

    private void Update()
    {
        if (swinging)
        {
            rotationPivot.localRotation = Quaternion.Euler(0, 0, rotationOut * swingTimer.GetValue());
            if (swingTimer.GetTimer())
            {
                swinging = false;
                recovering = true;
                recoveryTimer.StartTimer();
                Swing();

            }
        } else
        {
            if (recovering)
            {
                rotationPivot.localRotation = Quaternion.Euler(0, 0, rotationOut - rotationOut * recoveryTimer.GetValue());

                if (recoveryTimer.GetTimer())
                {
                    recovering = false;
                    rotationPivot.localRotation = Quaternion.identity;
                }
            }
        }
    }
}
