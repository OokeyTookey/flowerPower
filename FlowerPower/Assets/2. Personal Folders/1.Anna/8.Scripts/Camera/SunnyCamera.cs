using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyCamera : MonoBehaviour
{
    //object which follows the player 
    public GameObject playerRef;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            //Swap camera angle. 
        }

    }


    public void SwapCameraAngle(GameObject mainCamera, GameObject desiredLocation)
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, desiredLocation.transform.position, 5/*REPLACE AFTER TESTIN*/ * Time.deltaTime);
        mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, desiredLocation.transform.rotation, 5 /*REPLACE AFTER TESTIN*/* Time.deltaTime);
    }
}
