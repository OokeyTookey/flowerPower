using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepointrotation : MonoBehaviour
{

    public AnnaPlayerMovement playerMovement;
    public GameObject player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
