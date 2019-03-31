using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    //In order to use this script you must attach an empty game object to the scene.
    //Place the empty game object where you want to rotate around.
    //Make the camera a child on this object.
    public float speed;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0); //Only rotate on the Y Axis.
    }
}