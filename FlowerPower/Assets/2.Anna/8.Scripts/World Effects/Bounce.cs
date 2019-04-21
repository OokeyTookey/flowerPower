using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float speed;
    public Vector3 movement;

    float distance;
    Vector3 direction;
    Vector3 startLocation;
    Vector3 movementDirection;

    void Start()
    {
        startLocation = transform.position;
        movementDirection = movement;
        direction = movementDirection;
        direction.Normalize();
    }

    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, movementDirection + startLocation);
        if (distance <= 0.3f)
        {
            direction *= -1;
            movementDirection *= -1;
        }
        transform.position += direction * speed * Time.deltaTime;
    }
}   