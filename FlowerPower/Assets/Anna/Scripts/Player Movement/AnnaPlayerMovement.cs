using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AnnaPlayerMovement : MonoBehaviour
{
    Rigidbody RB;
    Vector3 direction;
    Vector3 tempDirection;
    float moveXAxis;
    float moveYAxis;
    public float angle;


    public float range;
    public float speed;
    public float maxSpeed;
    public float maxJumpForce;
    public float angleForce;
    public float slerpSpeed;

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
    
        //Angle is calculated by (sin and cos of each, otherwise known as:) tan-1 y/x
        angle = Mathf.Atan2(moveYAxis, moveXAxis); //Gives the angle 
        Debug.Log(angle * Mathf.Rad2Deg);

        direction = (-moveYAxis * Vector3.right + moveXAxis * Vector3.forward).normalized;
        RB.AddForce(direction * speed, ForceMode.Acceleration); //Adds a continuous force, utilizing the mass of the object                                                
                                                                //Add Force parameter; Acceleration, Force, Impulse, and VelocityChange                                                   
 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, 
                                                                    -angle * Mathf.Rad2Deg, transform.rotation.eulerAngles.z), Time.deltaTime * slerpSpeed);

        RB.velocity = Vector3.ClampMagnitude(RB.velocity, maxSpeed);

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