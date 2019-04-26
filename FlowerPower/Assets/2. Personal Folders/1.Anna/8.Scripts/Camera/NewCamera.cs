using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{
    public Transform target;
    public float range;
    bool isFollowing;
    Vector3 shift;

    void Start()
    {
        shift =  transform.position- target.position;
    }

    private void LateUpdate()
    {
        Vector3 direction = target.position - transform.position;
        var distanceFromCenter = Mathf.Abs(Vector3.Dot(direction, transform.right)); //Projects a line to the rihgt side of the camera

        if (distanceFromCenter > range)
        {
            if (!isFollowing)
            {
                shift = -direction;
                isFollowing = true;
            }
            FollowPlayer();
        }
        else isFollowing = false; ;


        //Debug.Log(Vector3.Project(direction, transform.right));
    }

    public void FollowPlayer()
    {
        this.transform.position = target.position + shift;
    }
}


