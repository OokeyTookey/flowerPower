using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AnnaPlayerMovement : MonoBehaviour
{
    Rigidbody RB;
    Collider playerCollider;
    Vector3 tempDirection;
    float moveXAxis;
    float moveYAxis;

    public Vector3 direction;
    public float angle;
    public float range;
    public float speed;
    public float maxSpeed;
    public float maxJumpForce;
    public float angleForce;
    public float slerpSpeed;

    public GameObject firepoint;
    public LayerMask groundLayer;

    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
        playerCollider = this.GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        // ---- Take input from the player & Calculate angle
        moveXAxis = Input.GetAxis("Horizontal"); //Between -1 & 1
        moveYAxis = Input.GetAxis("Vertical");
        angle = Mathf.Atan2(moveYAxis, moveXAxis); //Angle is calculated by (sin and cos of each, aka) tan-1 y/x
             //Debug.Log(angle * Mathf.Rad2Deg);


        // ---- Calcuate the direction using the input then add force.
        direction = (-moveYAxis * Vector3.right + moveXAxis * Vector3.forward).normalized;
        RB.AddForce(direction * speed, ForceMode.Acceleration); //Adds a continuous force, utilizing the mass of the object  

        // FORCEMODE.ACCELERATION has 4 alt options: Acceleration, Force, Impulse, and VelocityChange                                                   



        // Quaternion targetRotation = Quaternion.LookRotation(direction);
        /*transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(direction.x, 
          -angle * Mathf.Rad2Deg, direction.z), Time.deltaTime * slerpSpeed);*/
          // += angle/ horizontal x/y but then clamp it




        // ---- Setting the rotation by slerping between the original rotation to the angle specified above.
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x,
         -angle * Mathf.Rad2Deg, transform.rotation.eulerAngles.z), Time.deltaTime * slerpSpeed);

        // ---- Clamping the speed so player is limited & making gravity stronger so the player falls faster.
        RB.velocity = Vector3.ClampMagnitude(RB.velocity, maxSpeed);

        if (RB.velocity.y < 0) //Checks if he is falling.   
        {
            RB.velocity += (Physics.gravity * 2) * Time.fixedDeltaTime; //Doubles gravity when the player goes down.
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // ---- Makes the player up, "Transform.forward" might change due to rotation of object
            RB.AddForce(transform.up * maxJumpForce, ForceMode.Impulse); 
        }
    }

    private bool IsGrounded()
    {
        //CheckCapsule: Will return true if the box colliders/overlaps a specific layer or object.
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x,
            playerCollider.bounds.min.y, playerCollider.bounds.center.z), 2f /*<- Radius size*/, groundLayer);
    }
}