using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ThornsSkill : Skills
{
    public GameObject thorns;
    public float thornsActiveTime;
    public bool thornsActive;

    


    // Start is called before the first frame update
    void Start()
    {
        thorns.SetActive(false);
        thornsActiveTime = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            thornsActive = true;
        }
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
