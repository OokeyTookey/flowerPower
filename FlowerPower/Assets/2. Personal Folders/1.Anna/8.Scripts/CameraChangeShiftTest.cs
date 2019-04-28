using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeShiftTest : MonoBehaviour
{
    public float followPlayerSpeed;
    public float followRotationSpeed;
    float angle;
    Vector3 shift;
    Vector3 currentPosition;
    Quaternion currentRotation;
    AnnaPlayerMovement playerMovement;

        //transform.position = playerMovement.transform.position + shift;
  
    private void Start()
    {
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
        shift = transform.position - playerMovement.transform.position;
       // currentRotation = transform.rotation;
    }

    private void Update()
    {
        currentPosition = playerMovement.transform.position + shift;
        transform.position = Vector3.Lerp(transform.position, currentPosition, followPlayerSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, followRotationSpeed* Time.deltaTime);

       // transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, followRotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            SwapCameraAngle();
        }

    }

    public void SwapCameraAngle()
    {
        shift.x *= -1;
        //currentRotation.y *= -1;
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation,  Time.deltaTime);
        //transform.Rotate(0, 180, 0, Space.World); 
        currentRotation = Quaternion.Euler(0, 180, 0) * transform.rotation;

        //transform.rotation = currentRotation;
        // mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, desiredLocation.transform.position, 5/*REPLACE AFTER TESTIN*/ * Time.deltaTime);
        // mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, desiredLocation.transform.rotation, 5 /*REPLACE AFTER TESTIN*/* Time.deltaTime);
    }
}

