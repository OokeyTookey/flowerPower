using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaRosieCompanion : MonoBehaviour
{

    // Follow the velocity of the player.

    // Seek to players range.
    // Closer rosie gets to player then the slower they go.
    // If in a specific range then dont follow.
    // Look in direction of interest???  ? ? ?? *Tag objects, if in range then change direction of the head.
    // Look around randomly in locations when standing still.
    // done by choosing a random angle between two constraints, every few seconds pick a value
    // transform.lookat(randomAngle)


    // Check the players position, if they are out of a "MAX RANGE"
    // Teleport rosie to a designated spawn point by the player. 


    //Possible speech bubble interactions. HINT SYSTEM?!?!!

    public Transform playerReferenceTransform;
    public Rigidbody playerReferenceRB;
    public GameObject targetPosition;
    AnnaPlayerMovement playerMovementScript;

    Rigidbody thisObject;

    [Header("Seek Variables")]
    public float maxSpeed;
    public float force;
    Vector3 steering;
    Vector3 desiredVelo;

    public float range;
    Vector3 radiusAroundPlayer;

    public void Start()
    {
        thisObject = this.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        radiusAroundPlayer = playerReferenceRB.transform.position + new Vector3(range, 0, range); //0 to lock the Y position

        float distance = Vector3.Distance(this.transform.position, playerReferenceRB.transform.position);

        Debug.DrawLine(playerReferenceRB.transform.position,radiusAroundPlayer);

        if (distance > range)
        {
            desiredVelo = (playerReferenceTransform.position - transform.position).normalized * maxSpeed; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position
            steering = desiredVelo - thisObject.velocity; //Sets the steering behaviour by minusing

            thisObject.AddForce(new Vector3(steering.x, 0, steering.z) * force);
        }


        if (thisObject.velocity.magnitude >= maxSpeed)
        {
            thisObject.velocity = thisObject.velocity.normalized * maxSpeed; //limit the speed 
        }
    }

    /*desiredVelo = (playerReferenceTransform.position - transform.position).normalized * maxSpeed; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position
        steering = desiredVelo - thisObject.velocity; //Sets the steering behaviour by minusing

        thisObject.AddForce(new Vector3(steering.x, 0, steering.z) * force);

        if (thisObject.velocity.magnitude >= maxSpeed)
        {
            thisObject.velocity = thisObject.velocity.normalized * maxSpeed; //limit the speed 
        }*/

}
