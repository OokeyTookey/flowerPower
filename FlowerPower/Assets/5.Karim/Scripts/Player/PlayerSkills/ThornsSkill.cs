using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsSkill : MonoBehaviour
{
    public float thornsActiveTime;
    public bool thornsActive;
    public float thornsActiveDuration;

    void Start()
    {
        thornsActive = false;
    }

    void Update()
    {
        RunFunction();
    }

    public void ThornsActive()
    {
        if (thornsActive)
        {
            thornsActiveTime -= Time.deltaTime;
        }

        if (thornsActive && thornsActiveTime <= 0)
        {
            thornsActive = false;
            thornsActiveTime = thornsActiveDuration;
        }
    }

    public void RunFunction()
    {
        ThornsActive();
    }
}