using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistonMovement : MonoBehaviour
{
    
    int index;
    public GameObject[] platformPositions;
    public bool puzzle1Complete;

    [Header("//------ Puzzle 1 ------")]
    public GameObject puzzle1Pison1;
    public GameObject puzzle1Piston2;
    public GameObject puzzle1Piston3;

    [Space]

    [Header("//------ Puzzle 2 ------")]
    public GameObject puzzle2Pison1;
    public GameObject puzzle2Piston2;
    public GameObject puzzle2Piston3;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, platformPositions[index].transform.position, Time.deltaTime); //Moves towards the temp current waypoint

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
