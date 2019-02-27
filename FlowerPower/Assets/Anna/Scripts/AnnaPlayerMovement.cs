using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaPlayerMovement : MonoBehaviour
{
    Rigidbody RB;
    Vector3 movement;

    float moveXAxis;
    float moveYAxis;
    public float speed;
    public float maxSpeed;
    public float maxJumpForce;

    void Start()
    {
        RB = this.GetComponent<Rigidbody>();

        if (RB == null)
        {
            Debug.LogError("Rigidbody not found!! (Player Movement) -A");
        }
    }

    private void FixedUpdate()
    {
        moveXAxis = Input.GetAxis("Horizontal");
        moveYAxis = Input.GetAxis("Vertical");

        if (RB != null)
        {
            movement = new Vector3(moveXAxis, 0, moveYAxis) * speed;
            RB.AddForce(movement, ForceMode.Acceleration); //Adds a continuous force, utilizing the mass of the object
            //Add Force parameter; Acceleration, Force, Impulse, and VelocityChange.

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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(transform.forward * maxJumpForce, ForceMode.Impulse);
        }
    }
}