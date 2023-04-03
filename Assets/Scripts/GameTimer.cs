using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer
{
    public GameTimer(float cooldown)
    {
        this.cooldown = cooldown;
    }

    float startTime;
    float cooldown;


    public bool isActive;

    public bool isLooping = false;

    /*
     * public void onTimer()
    {
        if (current <= cooldown)
        {
            current += Time.deltaTime;
        }
    }*/

    public void StartTimer()
    {
        isActive = true;
        startTime = Time.time;
    }
    public void StopTimer()
    {
        isActive = false;
    }

    public bool GetTimer()
    {
        if (isActive)
        {
            if ((Time.time - startTime > cooldown))
            {
                if (isLooping)
                {
                    StartTimer();
                } else
                {
                    isActive = false;
                }
                return true;
            }
        }
        return false;
    }

    public float GetValue()
    {
        return Mathf.Min(1,(Time.time - startTime) / cooldown);
    }
}
