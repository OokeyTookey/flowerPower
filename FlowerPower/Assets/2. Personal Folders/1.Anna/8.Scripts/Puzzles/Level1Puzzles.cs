using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level1Puzzles : MonoBehaviour
{

    public bool puzzle1Complete;
    public bool puzzle2Complete;
    public GameObject[] pistons1;

    public GameObject endPos;
    public GameObject startPos;
    public float speed;

    public GameObject button1;
    public GameObject button2;


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