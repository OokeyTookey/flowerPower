using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonMovement : MonoBehaviour
{
    int index;
    public GameObject[] platformPositions;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, platformPositions[index].transform.position, Time.deltaTime); //Moves towards the temp current waypoint
        transform.LookAt(platformPositions[index].transform.position);

        if (Vector3.Distance(transform.position, platformPositions[index].transform.position) <= 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, platformPositions[index].transform.position, Time.deltaTime); //Moves towards the temp current waypoint

            if (index < platformPositions.Length - 1)
            {
                index++;
            }
            else index = 0;
        }
    }
}
