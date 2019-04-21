using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private AnnaPlayerMovement player;
    public float playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AnnaPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInRange() && Input.GetKey(KeyCode.E))
        {
            //Interact with the button

        }
    }

   public bool PlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= playerInRange;
    }
}
