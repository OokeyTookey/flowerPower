using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyMovement : MonoBehaviour
{
    //public Animator animation;

    private GameManager gameManager;
    private PlayerStats playerStats;

    private float moveXAxis;
    private float moveYAxis;

    private Rigidbody RB;
    private Collider playerCollider;
    private Vector3 tempDirection;
    private Vector3 movementClamp;

    [HideInInspector] public Vector3 direction;

    [Header("//------ Sunny main values ------")]
    public float range;
    public float speed;
    public float maxSpeed;
    public float slerpSpeed;
    public float walkMax;

    [Space]

    [Header("//------ Jump related ------")]
    public float clampJumpForce;
    public float maxJumpForce;
    public float pullDownForce;
    public LayerMask groundLayer;
    bool grounded;

    [HideInInspector] public bool invertControls;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        playerCollider = GetComponent<Collider>();
        gameManager = FindObjectOfType<GameManager>();

        // transform.position = gameManager.lastCheckpointLocation;
    }

    private void FixedUpdate()
    {
        // ---- Take input from the player & Calculate angle
        moveXAxis = Input.GetAxis("Horizontal"); //Between -1 & 1
        moveYAxis = Input.GetAxis("Vertical");

        // ---- Calcuate the direction using the input then add force.
        ///Camera.main.transform.position.y = 0;
        direction = (moveYAxis * new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z) + moveXAxis * Camera.main.transform.right).normalized;

        // ---- if there is some input then rotate the object.
        if (direction.magnitude != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * slerpSpeed);

        }
        var velovcity = direction * speed;
        velovcity.y = RB.velocity.y;
        RB.velocity = velovcity; //Adds a continuous force, utilizing the mass of the object 
        //FORCEMODE.ACCELERATION has 4 alt options: Acceleration, Force, Impulse, and VelocityChange                                                   
        // ---- Clamping the speed
        float vx = Mathf.Clamp(RB.velocity.x, -walkMax, walkMax);
        float vz = Mathf.Clamp(RB.velocity.z, -walkMax, walkMax);
        //RB.velocity = new Vector3(vx, RB.velocity.y, vz);

        if (RB.velocity.y < -.1f)  //Checks if he is falling and double gravity  
        {

            RB.velocity += (Physics.gravity * pullDownForce); //Doubles gravity when the player goes down. 
        }
    }

    public void Update()
    {

        if (Input.GetButtonDown("Jump") && IsGrounded() && (grounded))
        {
            //play jump animation
            Vector3 jumpDirection = transform.up * maxJumpForce;
            Vector3 clampedMagnitude = Vector3.ClampMagnitude(jumpDirection, clampJumpForce);
            RB.AddForce(clampedMagnitude, ForceMode.Impulse);
            grounded = false;
        }
    }

    private bool IsGrounded()
    {
        return true;
        ////CheckCapsule: Will return true if the box colliders/overlaps a specific layer or object.
        //return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x,
        // playerCollider.bounds.min.y, playerCollider.bounds.center.z), .1f /*<- Radius size*/, groundLayer);
    }
    int counter = 0;
    private void OnCollisionEnter(Collision collision)
    {
        counter++;
        if (Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x,
             playerCollider.bounds.min.y, playerCollider.bounds.center.z), .1f /*<- Radius size*/, groundLayer))
            grounded = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        counter--;
        if (counter <= 0)
        {
            grounded = false;
            counter = 0;
        }
    }
}
