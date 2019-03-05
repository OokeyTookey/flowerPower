using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AnnaPlayerMovement : MonoBehaviour
{
    Rigidbody RB;
    Vector3 direction;
    Vector3 lookPosition;
    Quaternion lookRotation;

    public Quaternion north;
    public Quaternion east;
    public Quaternion south;
    public Quaternion west;

    float moveXAxis;
    float moveYAxis;
    // float mouseXAxis;
    // float mouseYAxis;

    public float speed;
    public float maxSpeed;
    public float maxJumpForce;
    public float rotateSpeed;
    public float damping;
    public float moveSpeed;
    float angle;

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

        direction = (moveXAxis * transform.right + moveYAxis * -transform.up).normalized; //Inverse because model shape
        //direction = (moveXAxis * transform.right + moveYAxis * -transform.up).normalized; //Inverse because model shape
        RB.AddForce(direction * speed, ForceMode.Acceleration); //Adds a continuous force, utilizing the mass of the object
                                                                //Add Force parameter; Acceleration, Force, Impulse, and VelocityChange
                                                                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 90, transform.rotation.eulerAngles.z);
                                                                //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, moveYAxis, transform.rotation.eulerAngles.z);

        if (moveXAxis > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, -90, transform.rotation.eulerAngles.z));
        }


        if (RB.velocity.magnitude > maxSpeed)
        {
            RB.velocity = Vector3.ClampMagnitude(RB.velocity, maxSpeed);
        }

        if (RB.velocity.y < 0) //Checks if he is falling.   
        {
            //Figure out the height of objects and make the force that pulls the player down 
            RB.velocity += Physics.gravity * Time.deltaTime; //Doubles gravity when the player goes down.
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(transform.forward * maxJumpForce, ForceMode.Impulse); //Move the object forward because its rotated -90
        }
    }

    //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, mouseXAxis, transform.rotation.eulerAngles.z);

}