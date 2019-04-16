using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0); //Only rotate on the Y Axis.
    }
}