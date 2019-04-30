using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisTimeItsGoingToWork : MonoBehaviour
{
    public bool puzzle1Complete;
    public bool puzzle2Complete;
    public GameObject[] pistons1;
    public GameObject[] pistons2;
    [HideInInspector]public Vector3[] startPosition;

    private void Start()
    {
        for (int i = 0; i < pistons1.Length; i++)
        {
            startPosition[i] = pistons1[i].transform.position;
        }

        for (int i = 0; i < pistons2.Length; i++)
        {
            startPosition[i] = pistons2[i].transform.position;
        }
    }

    private void Update()
    {
        if (puzzle1Complete)
        {
            for (int i = 0; i < pistons1.Length; i++)
            {
                pistons1[i].GetComponent<Animator>().enabled = false;
                pistons1[i].transform.position = Vector3.Lerp(pistons1[i].transform.position, startPosition[i], Time.deltaTime);
            }
        }

        if (puzzle2Complete)
        {
            for (int i = 0; i < pistons2.Length; i++)
            {
                pistons2[i].GetComponent<Animator>().enabled = false;
                pistons2[i].transform.position = Vector3.Lerp(pistons2[i].transform.position, startPosition[i], Time.deltaTime);
            }
        }
    }

   /* void MovePiston(GameObject piston, Vector3 startPos, Vector3 endPos, float speed)
    {
        Vector3 currentPosition;
        currentPosition = startPos;
        piston.transform.position = Vector3.MoveTowards(piston.transform.position, currentPosition, speed * Time.deltaTime); //Moves towards the temp current waypoint

        if (Vector3.Distance(piston.transform.position, currentPosition) <= 1)
        {
            currentPosition = endPos;
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, currentPosition, speed * Time.deltaTime); //Moves towards the temp current waypoint

        }
    }*/

   /* void MovePiston(GameObject piston, Vector3 startPos, Vector3 endPos, float speed)
    {
        Vector3 currentPosition;

        Debug.Log(Vector3.Distance(piston.transform.position, endPos));

        if (Vector3.Distance(piston.transform.position, startPos) <= 1)
        {
            turn = false;
        }
        else if (Vector3.Distance(piston.transform.position, endPos) <= 1)
        {
            turn = true;
        }

        if (turn == false)
        {
            Debug.Log("Start" + Vector3.Distance(piston.transform.position, endPos));
            currentPosition = endPos;
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, currentPosition, speed * Time.deltaTime); //Moves towards the temp current waypoint

        }
        else if (turn == true)
        {
            Debug.Log("End" + Vector3.Distance(piston.transform.position, startPos));
            currentPosition = startPos;
            piston.transform.position = Vector3.MoveTowards(piston.transform.position, currentPosition, speed * Time.deltaTime); //Moves towards the temp current waypoint
        }
    }*/
}
