using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerSpeed;
    public int playerJumpForce;
    public int rotateSpeed;

    public float groundRadius;

    public bool grounded;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, groundRadius) ? true : false;
        Move();
        Jump();
        //Rotate();
    }

    // Movement
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * playerSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -transform.forward * playerSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * playerSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * playerSpeed;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector3(0, playerJumpForce));
        }
    }

    //Rotation
    //public void Rotate()
    //{
    //    if (Input.GetKey(KeyCode.Q))
    //    {
    //        transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed, Space.World);
    //    }
    //    if (Input.GetKey(KeyCode.E))
    //    {
    //        transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed, Space.World);
    //    }
    //}
}
