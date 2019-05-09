using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFanButton : MonoBehaviour
{

    public GameObject player;
    public float playerInRange;
    public bool buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        if ((other.CompareTag("Player") && Input.GetButtonDown("Interact") || other.CompareTag("Bullet")))
        {
            buttonPressed = true;
            
        }
    }
}
