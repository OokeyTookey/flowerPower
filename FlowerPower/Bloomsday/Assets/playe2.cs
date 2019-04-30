using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playe2 : MonoBehaviour
{
    public float speed;
    public float speed2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(speed, 0, 0);
        }

        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, speed * speed2 , 0);
        }

        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0, -speed * speed2, 0);
        }

    
    }
}


