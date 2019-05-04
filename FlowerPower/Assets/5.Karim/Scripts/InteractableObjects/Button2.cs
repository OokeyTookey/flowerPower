using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button2 : MonoBehaviour
{

    private AnnaPlayerMovement player;
   
    public float interactableSpeed;
    public bool buttonPressed;
    public GameObject interactable;
    public GameObject targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressed)
            MoveInteractable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            buttonPressed = true;
        }
    }

    public void MoveInteractable()
    {
        
        interactable.transform.position = Vector3.MoveTowards(interactable.transform.position, targetPosition.transform.position, interactableSpeed * Time.deltaTime);

        if(interactable.transform.position == targetPosition.transform.position)
        {
            interactableSpeed = 0;
        }
    }
}
