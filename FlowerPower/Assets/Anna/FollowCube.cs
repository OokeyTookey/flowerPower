using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCube : MonoBehaviour
{
    public Transform playerReference;
    public GameObject targetPosition;
    Rigidbody enemyRB;

    [Header("Seek Variables")]
    public float maxSpeed;
    public float force;
    Vector3 steering;
    Vector3 desiredVelo;
    

    void Start()
    {
        enemyRB = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        desiredVelo = (targetPosition.transform.position - transform.position).normalized * maxSpeed; //Get the desired velocity for flee by minusing the target positions (in this case the player) from the attached objects position
        steering = desiredVelo - enemyRB.velocity; //Sets the steering behaviour by minusing

        enemyRB.AddForce(new Vector3(steering.x, 0, steering.z) * force);

        if (enemyRB.velocity.magnitude >= maxSpeed)
        {
            enemyRB.velocity = enemyRB.velocity.normalized * maxSpeed; //limit the speed 
        }
    }

}
