using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaPlayerMovement : MonoBehaviour
{
    Rigidbody RB;
    public float speed;

    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            print("fikjc");
            RB.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            RB.AddForce(-transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            RB.AddForce(-transform.right * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            RB.AddForce(transform.right * speed);
        }
    }
}