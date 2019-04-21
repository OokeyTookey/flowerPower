using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Piston
{
    int index;
    public float speed;
    [HideInInspector] public Vector3 startPos;
    [HideInInspector] public Vector3 direction;
    [HideInInspector]public GameObject gameObject;
    [HideInInspector] public Vector3 targetPos;
    [HideInInspector] public bool goToEnd = true;
}


public class Level1Puzzles : MonoBehaviour
{

    public bool puzzle1Complete;
     public bool puzzle2Complete;
     public Piston[] pistons1;

    public GameObject piston;
    public GameObject endPos;
    public GameObject startPos;
    public float speed;

     void Start()
     {
        /*for (int i = 0; i < pistons1.Length; i++)
        {
           pistons1[i].startPos = startPos.transform.position;
        }*/

        //piston.transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, speed * Time.deltaTime); //Moves towards the temp current waypoint

    }

    void Update()
     {
         if (!puzzle1Complete)
         {
             for (int i = 0; i < pistons1.Length; i++)
             {
                 MovePiston(pistons1[i].gameObject, startPos.transform.position, endPos.transform.position);
             }
         }
     }

   void MovePiston(GameObject piston, Vector3 startPos, Vector3 endPos)
    {
        Vector3 currentPosition;
        currentPosition = startPos;
        piston.transform.position = Vector3.MoveTowards(piston.transform.position, currentPosition, speed *Time.deltaTime); //Moves towards the temp current waypoint

        if (Vector3.Distance(piston.transform.position, currentPosition) <= 1)
        {
            currentPosition = endPos;
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, currentPosition, speed *Time.deltaTime); //Moves towards the temp current waypoint

        }
    }
}

/*void MovePiston(Piston piston, Vector3 startPos, Vector3 endPos)
      {
          piston.direction = (piston.targetPos - startPos).normalized;

          if (Vector3.Distance(piston.gameObject.transform.position, piston.targetPos) <= 1)
          {
              if (piston.goToEnd)
              {
                  piston.targetPos = endPos;
                  piston.goToEnd = false;
              }
              else
              {
                  piston.targetPos = startPos;
                  piston.goToEnd = true;
              }
          }
        piston.gameObject.transform.position += piston.direction * piston.speed * Time.deltaTime; //Move the piston
     }*/
