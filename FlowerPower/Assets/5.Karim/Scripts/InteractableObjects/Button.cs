using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private AnnaPlayerMovement player;
    public float playerInRange;
    public float interactableSpeed;
    public bool buttonPressed;
    public GameObject interactable;
    public GameObject targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AnnaPlayerMovement>();
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerInRange());
        //PressButton();
        if (buttonPressed)
            MoveInteractable();

    }

    //public bool PlayerInRange()
    //{
    //    return Vector3.Distance(transform.position, player.transform.position) <= playerInRange;
    //}

    //public void PressButton()
    //{
    //    if (PlayerInRange() && Input.GetKeyDown(KeyCode.M))
    //    {
    //        buttonPressed = true;
    //    }
    //}
    public void MoveInteractable()
    {
        interactable.transform.position = Vector3.MoveTowards(interactable.transform.position, targetPosition.transform.position, interactableSpeed * Time.deltaTime);
        if (interactable.transform.position == targetPosition.transform.position)
        {
            interactableSpeed = 0;
        }
    }
    public bool test=false;
    private void OnTriggerStay(Collider other)
    {
        test = true;
        if ((other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) || other.CompareTag("Bullet")))
        {
            buttonPressed = true;
        }
    }
}
