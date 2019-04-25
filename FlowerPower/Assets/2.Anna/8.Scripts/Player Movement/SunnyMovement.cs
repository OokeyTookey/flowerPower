using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyMovement : MonoBehaviour
{
    public float jumpHeight= 10;
    public float timeTillMaxHeight=.6f;
    private void Update()
    {
        float jumpForce = (jumpHeight/ timeTillMaxHeight - .5f * Physics.gravity.y * timeTillMaxHeight );
        if (Input.GetButtonDown("Jump"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpForce, 0);
        }
    }
}
