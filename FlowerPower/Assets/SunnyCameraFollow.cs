using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyCameraFollow : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject startPosition;
    public GameObject flipPosition;


    Vector3 cameraOffsetStart;
    Vector3 cameraOffsetFlip;

    Vector3 startPositionCamera;
    public Vector3 flipCameraPos; //Flip vector 2 in inspector



    bool doThing;
    bool revertDoThing;

    void Start()
    {
        startPositionCamera = mainCamera.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        cameraOffsetStart = transform.position + startPositionCamera;
        cameraOffsetFlip = transform.position + startPositionCamera + flipCameraPos;

        if (Input.GetKeyDown(KeyCode.P))
        {
            doThing = true;
            revertDoThing = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            doThing = false;
            revertDoThing = true;
        }

        if (doThing)
        {
            ChangePerspective(mainCamera, flipPosition, cameraOffsetFlip);
        }

        if (revertDoThing)
        {
            ChangePerspective(mainCamera, startPosition, cameraOffsetStart);
        }

    }

    public void ChangePerspective(Camera mainCamera, GameObject desiredPosition, Vector3 offset)
    {
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, desiredPosition.transform.position, 0.1f);
        mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, desiredPosition.transform.rotation, 0.1f);

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, offset, 0.1f);
    }
}
