using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyMovement : MonoBehaviour
{
    public float jumpHeight= 10;
    public float timeTillMaxHeight=.6f;
    public Vector3 gravity;
    private void FixedUpdate()
    {
        gravity = new Vector3(0, -2 * jumpHeight / timeTillMaxHeight / timeTillMaxHeight, 0);
        float jumpForce = 2 *jumpHeight / timeTillMaxHeight;
        if (Input.GetButtonDown("Jump"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpForce, 0);
        }
        this.GetComponent<Rigidbody>().velocity += gravity*Time.deltaTime; 
    }
}
