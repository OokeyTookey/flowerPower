using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeShiftTest : MonoBehaviour
{
    public float followPlayerSpeed;
    public float followRotationSpeed;
    public float zoomSpeed;

    Vector3 shift;
    Vector3 currentPosition;
    Quaternion currentRotation;
    AnnaPlayerMovement playerMovement;
    RaycastHit hit;

    //zoom in based on the closeness of the player to the wall
    //Access the distance between the wall and plauer
    //get the difference and move that close

    private void Start()
    {
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
        shift = transform.position - playerMovement.transform.position;
    }

    private void LateUpdate()
    {
      /*  var directionToCamera = (transform.position- playerMovement.transform.position).normalized;
        Ray rayFromPlayer = new Ray(playerMovement.transform.position, directionToCamera);

        if (Physics.Raycast(rayFromPlayer, out hit, LayerMask.GetMask("Wall")))
        {
            Debug.DrawRay(playerMovement.transform.position, directionToCamera, Color.green);
            Debug.Log("collision");

            //var distanceBetween = Vector3.Distance(transform.position, hit.point);
        }
        else Debug.Log("no collsion");*/
      
        currentPosition = playerMovement.transform.position + shift;
        transform.position = Vector3.Lerp(transform.position, currentPosition, followPlayerSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentRotation, followRotationSpeed* Time.deltaTime);
        //- ((playerMovement.GetComponent<Rigidbody>().velocity.magnitude>0.01f)?playerMovement.GetComponent<Rigidbody>().velocity.normalized:Vector3.zero );

        if (Input.GetKeyDown(KeyCode.P))
        {
            SwapCameraAngle();
        }
    }

    public void SwapCameraAngle()
    {
        shift.x *= -1;
        currentRotation = Quaternion.Euler(0, 180, 0) * transform.rotation;
    }

    /*IEnumerator LerpToPoint(Vector3 point)
    {
        var initialPosition=this.transform.position;
        float t = 0;
        while (t < 1)
        {
        transform.position = Vector3.Lerp(initialPosition, point, t);
            yield return null;
            t += 0.01f;
        }
    }*/
}