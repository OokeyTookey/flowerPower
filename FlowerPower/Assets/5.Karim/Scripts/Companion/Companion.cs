using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{

    public GameObject player;
    public float distance;
    public float followDistance = 2;
    public GameObject companion;
    public float followSpeed;
    public RaycastHit shot;


    void Update()
    {
        transform.LookAt(player.transform);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out shot))
        {
            distance = shot.distance;
            if (distance >= followDistance)
            {
                followSpeed = 0.1f;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed);
            }
            else
            {
                followSpeed = 0;

            }
        }
    }
}
