using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeShiftTest : MonoBehaviour
{
    private Vector3 currentCameraPosition;

    private Vector3 startingCameraPosition;

    public GameObject mainCamera;
    public GameObject playerReference;
    public GameObject desiredLocation;

    GameObject startingPosition;
    AnnaPlayerMovement playerMovement;

    bool swapCameraNewPer;
    bool swapCameraOldPer;

    private void Start()
    {
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
        startingCameraPosition = mainCamera.transform.position;

        startingPosition = mainCamera;
    }

    private void Update()
    {
        if (swapCameraNewPer)
        {
            SwapCameraAngle(mainCamera, desiredLocation);
            //swapCameraOldPer = false;
        }

        if (swapCameraOldPer)
        {
            SwapCameraAngle(mainCamera, startingPosition);     
           // swapCameraNewPer = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Vector3 cameraOffset = playerReference.transform.position + startingCameraPosition;

        if (other.CompareTag("Player"))
        {
            swapCameraNewPer = true;
            //playerMovement.invertControls = true;
        }
    }

   private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //swapCameraOldPer = true;
            //playerMovement.invertControls = false;
        }
    }

    public void SwapCameraAngle(GameObject mainCamera, GameObject desiredLocation)
    {
        //mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, desiredLocation.transform.position, 5 * Time.deltaTime);
        //mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, desiredLocation.transform.rotation, 5 * Time.deltaTime);
    }
}
