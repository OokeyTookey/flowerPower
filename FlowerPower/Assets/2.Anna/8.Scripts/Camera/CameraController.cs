using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /* public Rigidbody playerReference;

     [SerializeField]
     Vector3 startPositionCamera;
     Vector3 cameraPosition;
     Vector3 cameraOffset;

     void Start()
     {
         startPositionCamera = transform.position - playerReference.transform.position;
     }

     void FixedUpdate()
     {
         cameraOffset = playerReference.position + startPositionCamera;
         transform.position = Vector3.Lerp(transform.position, cameraOffset, 0.1f);

         /*if (cameraOffset )
         {

         }*/



    public Rigidbody playerReference;

    [SerializeField]
    Vector3 startPositionCamera;
    Vector3 cameraPosition;
    Vector3 cameraOffset;

    void Start()
    {
        startPositionCamera = transform.position - playerReference.transform.position;
    }

    void FixedUpdate()
    {
        cameraOffset = playerReference.position + startPositionCamera;
        transform.position = Vector3.Lerp(transform.position, cameraOffset, 0.1f);
    }
}
