using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puzzle4 : MonoBehaviour
{


    public GameObject interactable;
    public GameObject interactable2;
    public GameObject targetPosition;
    public GameObject targetPosition2;
    public float interactableSpeed;
    public float interactableSpeed2;
    public bool puzzleComplete;
    public int enemiesKilled;
    public int requiredKills;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesKilled == requiredKills)
        {
            puzzleComplete = true;
            interactable.transform.position = Vector3.MoveTowards(interactable.transform.position, targetPosition.transform.position, interactableSpeed * Time.deltaTime);
            if (interactable.transform.position == targetPosition.transform.position)
            {
                interactableSpeed = 0;
            }
            interactable2.transform.position = Vector3.MoveTowards(interactable2.transform.position, targetPosition2.transform.position, interactableSpeed * Time.deltaTime);
            if (interactable2.transform.position == targetPosition2.transform.position)
            {
                interactableSpeed2 = 0;
            }

        }
    }
}
