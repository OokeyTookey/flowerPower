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

    float angle;
    public float speed;
    public float maxSpeed;
    public float maxJumpForce;
    public float angleForce;

    bool isGrounded;

    public GameObject firepoint;

    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        moveXAxis = Input.GetAxis("Horizontal");
        moveYAxis = Input.GetAxis("Vertical");
        //Angle is calculated by (sin and cos of each, otherwise known as:) tan-1 y/xx

        angle = Mathf.Atan2(moveYAxis, moveXAxis); //Gives the angle 
        Debug.Log(angle * Mathf.Rad2Deg);

        direction = (moveXAxis * Vector3.right + moveYAxis * Vector3.forward).normalized;
        RB.AddForce(direction * speed, ForceMode.Acceleration); //Adds a continuous force, utilizing the mass of the object                                                
                                                    //Add Force parameter; Acceleration, Force, Impulse, and VelocityChange                                                   

        transform.rotation = Quaternion.Euler(transform.rotation.x, angle *Mathf.Rad2Deg, transform.rotation.z);                                                    //Add Force parameter; Acceleration, Force, Impulse, and VelocityChange                                                   




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