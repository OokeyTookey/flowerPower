using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Puzzles : MonoBehaviour
{
    //public GameObject button1;
   // public GameObject button2;
    bool puzzle1Complete;
    //bool puzzle2Complete;

    public GameObject[] pistons;
    Transform [] endPos;
   // public 
    Transform[] startPos;
    public float speed;

    void Start()
    {
        for (int i = 0; i < pistons.Length; i++)
        {
            startPos[i].transform.position = pistons[i].transform.position;
        }
    }

    void Update()
    {
        if (!puzzle1Complete)
        {
            for (int i = 0; i < pistons.Length; i++)
            {
                MovePiston(pistons[i], startPos[i], endPos[i]);
            }
        }
    }

    void MovePiston(GameObject moveGameObject, Transform startPos,Transform endPos)
    { 
        moveGameObject.transform.position = Vector3.MoveTowards(moveGameObject.transform.position, endPos.position, Time.deltaTime * speed); //Moves towards the temp current waypoint

        if (Vector3.Distance(moveGameObject.transform.position, endPos.position) <= 1)
        {
            moveGameObject.transform.position = Vector3.MoveTowards(moveGameObject.transform.position, startPos.position, Time.deltaTime * speed); //Moves towards the temp current waypoint
        }   
    }
}