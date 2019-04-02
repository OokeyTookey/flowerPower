using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AnnaPlayerMovement : MonoBehaviour
{
    Rigidbody RB;
    Collider playerCollider;
    Vector3 tempDirection;
    Vector3 movementClamp;
    float moveXAxis;
    float moveYAxis;

    [HideInInspector]
    public Vector3 direction;

    [Header("//------ Sunny main values ------")]
    public float range;
    public float speed;
    public float maxSpeed;
    public float slerpSpeed;
    public float walkMax;

    [Space]

    [Header("//------ Others & Jump ------")]
    public float maxJumpForce;
    public LayerMask groundLayer;

    [Space]

    public GameObject firepoint;

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

        // ---- Calcuate the direction using the input then add force.
        direction = (-moveYAxis * Vector3.right + moveXAxis * Vector3.forward).normalized;
        RB.AddForce(direction * speed, ForceMode.Acceleration); //Adds a continuous force, utilizing the mass of the object 
        //FORCEMODE.ACCELERATION has 4 alt options: Acceleration, Force, Impulse, and VelocityChange                                                   

        // ---- if there is some input then rotate the object.
        if (direction.magnitude != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * slerpSpeed);
        }

        // ---- Clamping the speed
        float vx = Mathf.Clamp(RB.velocity.x, -walkMax, walkMax);
        float vz = Mathf.Clamp(RB.velocity.z, -walkMax, walkMax);
        RB.velocity = new Vector3(vx, RB.velocity.y, vz);

        if (RB.velocity.y < 0) //Checks if he is falling and double gravity  
        {
            RB.velocity += (Physics.gravity * 2) * Time.fixedDeltaTime; //Doubles gravity when the player goes down.
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            RB.AddForce(transform.up * maxJumpForce, ForceMode.Impulse);
        }
        Debug.Log(speed);
    }

    private bool IsGrounded()
    {
        //CheckCapsule: Will return true if the box colliders/overlaps a specific layer or object.
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x,
            playerCollider.bounds.min.y, playerCollider.bounds.center.z), 1f /*<- Radius size*/, groundLayer);
    }


    //-------------------------------------------------- GOO CODE *** PLEASE COME BACK AND FIX THIS DISGUSTING CODE
    //-------------------------------------------------- *** PLEASE COME BACK AND FIX THIS DISGUSTING CODE
    //-------------------------------------------------- *** PLEASE COME BACK AND FIX THIS DISGUSTING CODE

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goo"))
        {
            speed = speed / 3;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Goo"))
        {
            speed = speed * 3;
        }
    }
}