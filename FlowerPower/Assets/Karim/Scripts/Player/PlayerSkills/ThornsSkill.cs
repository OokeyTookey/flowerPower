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
        thornsActiveTime -= Time.deltaTime;
    }

    public void ThornsActive()
    {
        if (thornsActive && thornsActiveTime <= 0)
        {
            thornsActiveTime = thornsActiveDuration;
            thornsActive = false;
        }
    }

    public void RunFunction()
    {
        thornsActive = true;    
        ThornsActive();
    }
}