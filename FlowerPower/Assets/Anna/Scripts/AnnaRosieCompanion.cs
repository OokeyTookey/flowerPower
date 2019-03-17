using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaRosieCompanion : MonoBehaviour
{
    public Rigidbody playerReferenceRB;
    AnnaPlayerMovement playerMovementScript;
    float distanceFromSunny;
    Vector3 playerLocation;

    Rigidbody rosieRB;
    public float lookRotationSpeed;
    public float rosieLookDelay;
    private float rosieLookCountUp;
    private Vector3 outOfRangeRespawn;

    [Header("Seek Variables")]
    public float maxSpeed;
    public float force;
    Vector3 steering;
    Vector3 desiredVelo;

    public float range;
    public float maxRange;
    Vector3 radiusAroundPlayer;

    public void Start()
    {
        rosieRB = this.GetComponent<Rigidbody>();
    }

    public void Update()
    {

        playerLocation = playerReferenceRB.position;
        playerLocation.y = transform.position.y;
        transform.LookAt(playerLocation);

        // ---- Creates a radius around the player then calcuates the distance between em.
        radiusAroundPlayer = playerReferenceRB.transform.position + new Vector3(range, 0, range); //0 to lock the Y position
        distanceFromSunny = Vector3.Distance(this.transform.position, playerReferenceRB.transform.position);
            Debug.DrawLine(playerReferenceRB.transform.position,radiusAroundPlayer);

        outOfRangeRespawn = new Vector3(playerReferenceRB.transform.position.x + 5, playerReferenceRB.transform.position.y, playerReferenceRB.transform.position.z + 5);

        // ---- If Rosie is in range then slow down.
        if (distanceFromSunny < range)
        {
            rosieRB.velocity += Vector3.zero;
        }

        // ---- Checks is Rosie is out of range then run towards Sunny.
        else if (distanceFromSunny > range)
        {
            desiredVelo = (playerReferenceRB.transform.position - transform.position).normalized * maxSpeed; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position
            steering = desiredVelo - rosieRB.velocity; //Sets the steering behaviour by minusing
            rosieRB.AddForce(new Vector3(steering.x, 0, steering.z) * force);
        }

        // ---- Checks is Rosie is out of the max range then teleport
        if (distanceFromSunny > maxRange /*&& Input.GetKeyDown(KeyCode.R)*/)
        {
            rosieRB.position = outOfRangeRespawn;
            Debug.Log("Respawn Rosie!!");
        }

        // --- Limits Rosies speed.
        if (rosieRB.velocity.magnitude >= maxSpeed)
        {
            rosieRB.velocity = rosieRB.velocity.normalized * maxSpeed;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(playerReferenceRB.transform.position, range); //Debugging range 
    }
}