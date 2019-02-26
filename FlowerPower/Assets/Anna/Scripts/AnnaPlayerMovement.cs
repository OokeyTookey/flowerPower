using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaPlayerMovement : MonoBehaviour
{
    Rigidbody RB;
    Vector3 movement;

    public float speed;
    const float GRAVITY = 9.8f;

    float moveXAxis;
    float moveYAxis;
    public float projectileForce;
    public float maxJumpForce;

    [SerializeField]
    float angle;
    float initalVelocity;
    float initalVelocityY;
    float initalVelocityZ;
    Vector3 comboVelo;

    void Start()
    {
        RB = this.GetComponent<Rigidbody>();

        if (RB == null)
        {
            Debug.LogError("Rigidbody not found!! -A");
        }
    }

    private void FixedUpdate()
    {
        if (RB != null)
        {
            movement = new Vector3(moveXAxis, 0, moveYAxis) * speed;
            RB.AddForce(movement, ForceMode.Acceleration); //Adds a continuous force, utilizing the mass of the object
            //Add Force parameter; Acceleration, Force, Impulse, and VelocityChange.
        }
    }

    void Update()
    {
        moveXAxis = Input.GetAxis("Horizontal");
        moveYAxis = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            initalVelocityY = Mathf.Sqrt(projectileForce) * Mathf.Cos(angle * Mathf.PI / 180.0f);
            initalVelocityZ = Mathf.Sqrt(projectileForce) * Mathf.Sin(angle * Mathf.PI / 180.0f);

            comboVelo = new Vector3(0, initalVelocityY, initalVelocityZ);

            Debug.DrawLine(transform.position , RB.velocity.normalized);
            /* initalVelocity = Mathf.Sqrt(projectileForce) * 
             initalVelocityX = initalVelocity * Mathf.Sin(Mathf.Deg2Rad * angle);
             initalVelocityZ = initalVelocity * Mathf.Cos(Mathf.Deg2Rad * angle);*/


            /*Debug.Log(comboVelo);
            if (RB.velocity.y <= maxJumpForce)
            {
                Debug.Log(RB.velocity.y + "y velo");
                Mathf.Clamp(RB.velocity.y, 0, maxJumpForce);
            }*/

            //RB.AddForce((comboVelo * Time.deltaTime * GRAVITY), ForceMode.Impulse);
            RB.velocity = comboVelo * Time.deltaTime * GRAVITY;



            /*playerProjectile[i].sprite.Position += new Vector2f(playerProjectile[i].initialVelocity.X * playerProjectile[i].time,
                                                                       playerProjectile[i].initialVelocity.Y * playerProjectile[i].time
                                                                       + 0.5f * GRAVITY * playerProjectile[i].time * playerProjectile[i].time
                                                                       );
                                                                       */

        }
    }
}