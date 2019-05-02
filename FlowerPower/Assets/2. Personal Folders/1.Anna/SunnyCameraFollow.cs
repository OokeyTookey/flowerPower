using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyCameraFollow : MonoBehaviour
{
    //---- Camera perspective flip etc.
    public Camera mainCamera;
    public GameObject startPosition;
    public GameObject flipPosition;

    Vector3 cameraOffsetStart;
    Vector3 cameraOffsetFlip;

    Vector3 startPositionCamera;
    public Vector3 flipCameraPos; //Flip vector 2 in inspector

    bool doThing;
    bool revertDoThing;

    //---- Raycast Wall fade
    RaycastHit hit;

    void Start()
    {
        startPositionCamera = mainCamera.transform.position - transform.position;
        revertDoThing = true;
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

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraOffsetStart, 0.1f);
        Debug.DrawLine(transform.position, mainCamera.transform.position, Color.yellow);
    }

    public void ChangePerspective(Camera mainCamera, GameObject desiredPosition, Vector3 offset)
    {
       mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, desiredPosition.transform.position, 0.1f);
       mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, desiredPosition.transform.rotation, 0.1f);

       //mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, offset, 0.1f);
    }

    public void HideWalls()
    {
        //Ray cameraToPlayer = new Ray(mainCamera.transform.position, transform.position);
        /*if (Physics.Raycast(cameraToPlayer, out hit));
        {
            Vector3 v = Vector3.Reflect(enemyRB.velocity, hit.normal);
            Debug.DrawRay(hit.point, v, Color.green);

            enemyRB.AddForce(v * force);
        }*/
    }
}
