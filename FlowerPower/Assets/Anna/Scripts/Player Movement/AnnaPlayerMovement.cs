using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AnnaPlayerMovement : MonoBehaviour
{
    Rigidbody RB;
    Vector3 direction;

    float moveXAxis;
    float moveYAxis;

    public float speed;
    public float maxSpeed;
    public float maxJumpForce;

    bool isGrounded;

    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveXAxis = Input.GetAxis("Horizontal");
        moveYAxis = Input.GetAxis("Vertical");

        //mouseXAxis += Input.GetAxis("Mouse X");
        //mouseYAxis += Input.GetAxis("Mouse Y");

        direction = (moveXAxis * Vector3.right + moveYAxis * Vector3.forward).normalized;
        RB.AddForce(direction * speed, ForceMode.Acceleration); //Adds a continuous force, utilizing the mass of the object
                                                                //Add Force parameter; Acceleration, Force, Impulse, and VelocityChange                                                    
        if (moveXAxis > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 90, transform.rotation.eulerAngles.z));
        }

        if (moveXAxis < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, -90, transform.rotation.eulerAngles.z));
        }

        if (moveYAxis > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z));
        }

        if (moveYAxis < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z));
        }

        //if (RB.velocity.magnitude > maxSpeed)
        {
            RB.velocity = Vector3.ClampMagnitude(RB.velocity, maxSpeed);
        }

        if (RB.velocity.y < 0) //Checks if he is falling.   
        {
            //Figure out the height of objects and make the force that pulls the player down 
            RB.velocity += Physics.gravity  * Time.fixedDeltaTime; //Doubles gravity when the player goes down.
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(transform.forward * maxJumpForce, ForceMode.Impulse); //Move the object forward because its rotated -90
        }
    }
}