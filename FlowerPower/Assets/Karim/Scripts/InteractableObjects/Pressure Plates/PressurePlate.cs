using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // play animation to make the pressure plate go down.
            // do whatever the plate is supposed to do.
            // play a sound clip.
            // whatever else you want this to do.
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            // play animation to make the pressure plate go back up.
            
        }
    }
}
