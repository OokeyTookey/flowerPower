using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSystem2 : MonoBehaviour
{
    public float percentage;
    public GameObject[] menuCameraPositions;
    public GameObject[] menuPanels;

    private int index;
    private bool doOnce;

    //Start game
    //Load game?!?!?!?!
    //Settings
    //Credits
    //Exit

    //***OPTIMIZE TO USE KEYBOARD KEYS!!!!!! 
    //-------------------------------------------------- *** PLEASE COME BACK AND FIX THIS DISGUSTING CODE
    //-------------------------------------------------- *** PLEASE COME BACK AND FIX THIS DISGUSTING CODE

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        menuPanels[index].SetActive(true);

        if (Input.GetKeyDown(KeyCode.A))
        {
            menuPanels[index].SetActive(false);
            index--;

            if (index < 0)
            {
                index = menuCameraPositions.Length - 1; //Last index in the array (Looping effect)
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            menuPanels[index].SetActive(false);
            index++;

            if (index > menuCameraPositions.Length - 1)
            {
                index = 0; //First index in the array (Looping effect)
            }
        }

        for (int i = 0; i < menuCameraPositions.Length; i++)
        {
            transform.position = Vector3.Lerp(transform.position, menuCameraPositions[index].transform.position, percentage * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, menuCameraPositions[index].transform.rotation, percentage * Time.deltaTime);
        }
    }
}