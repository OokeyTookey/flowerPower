using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ThornsSkill : MonoBehaviour
{

    public float thornsActiveTime;
    public bool thornsActive;
    public float thornsActiveDuration;
   
    // Start is called before the first frame update
    void Start()
    {
        thornsActive = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        RunFunction();
    }

    public void ThornsActive()
    {
        if (thornsActive)
        {
            thornsActiveTime -= Time.deltaTime;
            //Debug.Log(thornsActiveTime);
        }
        if (thornsActive && thornsActiveTime <= 0)
        {
            thornsActive = false;
            thornsActiveTime = thornsActiveDuration;
            
        }
    }

    public void RunFunction()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            thornsActive = true;
        }
        ThornsActive();
    }

    //public void RunFunction()
    //{
        
    //        thornsActive = true;
        
    //    ThornsActive();
    //}
}





