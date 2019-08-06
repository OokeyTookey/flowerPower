using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeShiftTest : MonoBehaviour
{
    public float followPlayerSpeed;
    public float followRotationSpeed;
    public float zoomSpeed;

    Vector3 shift;
    Vector3 startingShift;
    Vector3 currentPosition;
    Quaternion currentRotation;
    AnnaPlayerMovement playerMovement;
    RaycastHit hit;

    private void Start()
    {
        currentRotation = transform.rotation;
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
        shift = transform.position - playerMovement.transform.position;
        startingShift = transform.position - playerMovement.transform.position;
    }

    private void FixedUpdate()
    {
        //1-calculate new position
        currentPosition = playerMovement.transform.position + shift;

        //2- check if you need to correct the new position
        var directionToCamera = (currentPosition - playerMovement.transform.position);
        Ray rayFromPlayer = new Ray(playerMovement.transform.position, directionToCamera.normalized);

        if (Physics.Raycast(rayFromPlayer, out hit, startingShift.magnitude, LayerMask.GetMask("Wall")))
        {
            Debug.DrawRay(playerMovement.transform.position, directionToCamera, Color.green);
            currentPosition = hit.point;
        }

        //3-smooth movement to the new position
        transform.position = Vector3.Lerp(transform.position, currentPosition, followPlayerSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, followRotationSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Rotate")) 
        {
            SwapCameraAngle();
        }
    }

    public void SwapCameraAngle()
    {   
        shift = Quaternion.Euler(0, 90, 0) * shift;
        currentRotation = Quaternion.Euler(0, 90, 0) * currentRotation;
    }
}