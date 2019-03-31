using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSystem2 : MonoBehaviour
{
    public GameObject[] menuCameraPositions;
    public GameObject[] menuPanels;
    public float percentage;
    private int index;
    bool stopLooping;

    void Update()
    {
        menuPanels[index].SetActive(true);

        if (Input.GetKeyDown(KeyCode.D))
        {
            index++;

            if (index >= menuCameraPositions.Length)
            {
                index = 0; //First index in the array (Looping effect)
            }
            menuPanels[index - 1].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            index--;
            if (index < 0)
            {
                index = menuCameraPositions.Length - 1; //Last index in the array (Looping effect)
            }
            menuPanels[index - 1].SetActive(false);
        }

        for (int i = 0; i < menuCameraPositions.Length; i++)
        {
            transform.position = Vector3.Lerp(transform.position, menuCameraPositions[index].transform.position, percentage * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, menuCameraPositions[index].transform.rotation, percentage * Time.deltaTime);
        }

    }
}