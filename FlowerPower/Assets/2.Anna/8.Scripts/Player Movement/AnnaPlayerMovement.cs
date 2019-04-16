using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AnnaPlayerMovement : MonoBehaviour
{
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
    public LayerMask groundLayer;

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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            //RB.AddForce(transform.up * maxJumpForce, ForceMode.Impulse);
            //RB.AddForce(transform.forward * maxJumpForwardForce, ForceMode.Impulse);

            //Vector3 jumpDirection = transform.forward + transform.up;
            Vector3 jumpDirection = transform.up * maxJumpForce;
            Vector3 clampedMagnitude = Vector3.ClampMagnitude(jumpDirection, clampJumpForce);
            RB.AddForce(clampedMagnitude, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        //CheckCapsule: Will return true if the box colliders/overlaps a specific layer or object.
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x,
            playerCollider.bounds.min.y, playerCollider.bounds.center.z), .1f /*<- Radius size*/, groundLayer);
    }
}