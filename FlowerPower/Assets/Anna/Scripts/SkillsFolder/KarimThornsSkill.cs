using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarimThornsSkill : Skills
{
    [HideInInspector] public GameObject thorns;
    [HideInInspector] public float thornsActiveTime;
    [HideInInspector] public bool thornsActive;

    public void Start()
    {
        thorns.SetActive(false);
        thornsActiveTime = 2;
    }

    public void RunFunction()
    {
        thornsActive = true;
        ThornsActive();
    }

    public void ThornsActive()
    {
        if (thornsActive)
        {
            thorns.SetActive(true);
            thornsActiveTime -= Time.deltaTime;
        }
        if (thornsActive && thornsActiveTime <= 0)
        {
            thornsActive = false;
            thorns.SetActive(false);
            thornsActiveTime = 2;
        }
    }
}