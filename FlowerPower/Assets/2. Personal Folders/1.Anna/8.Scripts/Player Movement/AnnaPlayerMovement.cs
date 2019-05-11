using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class AnnaPlayerMovement : MonoBehaviour
{
    [HideInInspector] public Vector3 direction; //Look & movement direction. Used for EVERYTHING (Basically)

    private float moveXAxis; //Needed for input.
    private float moveYAxis; //Needed for input 2.0.

    public Animator anim;

    private Rigidbody RB; //For player rigidbody.
    private Collider playerCollider; //For player collider to check if grounded.

    [Header("//------ Sunny main values ------")]
    public float speed; //Player walk speed
    public float speedySpeed; //speedy walk speed
    public float rotationSlerpSpeed; //Rotation speed
    float originalSpeed;

    [Space]

    [Header("//------ Jump related ------")]
    public float jumpHeight; //Sets the height of the jump
    public float timeTillMaxHeight; // how long it takes to reach the max jump height
    public Vector3 fakeGravity; //Sunny has his own gravity!! :D (dont want to effect everyhting in the scene)
    public LayerMask groundLayer; //Which layer does sunny check collisions between for jumping

    void Start()
    {
        originalSpeed = speed;
        RB = GetComponent<Rigidbody>(); 
        playerCollider = GetComponent<Collider>();
        anim = this.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        moveXAxis = Input.GetAxis("Horizontal"); //Takes input from the player.
        moveYAxis = Input.GetAxis("Vertical"); ////Always between -1 & 1

        var cameraDirection = Camera.main; // ---- Calcuate the direction using the input & makes it relative to the camera's variables.
        direction = (moveYAxis * new Vector3(cameraDirection.transform.forward.x, 0, cameraDirection.transform.forward.z)  + moveXAxis * cameraDirection.transform.right).normalized;

        if (direction.magnitude != 0) //If there is input, then rotate object based on direction.
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSlerpSpeed); 
        }
        if(moveXAxis == 0 && moveYAxis == 0)
        {
            anim.SetInteger("AnimatorX", 0);
        }
        if(moveXAxis != 0 || moveYAxis !=0)
        {
            anim.SetInteger("AnimatorX",1);
        }
        var moveWithVelo = direction * speed; //Creating new varible for player movement. 
        moveWithVelo.y = RB.velocity.y; //making sure we are not messing with the Y & it stays the same.
        RB.velocity = moveWithVelo; //Making the player move using velocity rather than add force! :D

        //Sunny will use his own physics --------------------------------------------------------------------------------------------------
        fakeGravity = new Vector3(0, -2 * jumpHeight / timeTillMaxHeight / timeTillMaxHeight, 0); //Creating gravity by XX X X X X 

        float jumpForce = 2 * jumpHeight / timeTillMaxHeight;

        //- ----------- JUMP FUNCTION
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            anim.SetTrigger("jump");
            RB.velocity = new Vector3(0, jumpForce, 0); //Adds jump force. 
        }

        RB.velocity += fakeGravity * Time.deltaTime; //Constantly adds gravity to sunny. 
    }

    private bool IsGrounded()
    {
        //CheckCapsule: Will return true if the box colliders/overlaps a specific layer or object.
        return Physics.CheckCapsule(playerCollider.bounds.center, new Vector3(playerCollider.bounds.center.x,
           playerCollider.bounds.min.y, playerCollider.bounds.center.z), .1f /*<- Radius size*/, groundLayer);
    }
}