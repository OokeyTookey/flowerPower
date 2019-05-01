using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level1Puzzles : MonoBehaviour
{
    public GameObject player;

    public bool puzzle1Complete;
    public bool puzzle2Complete;
    public GameObject[] pistons1;
    public GameObject[] pistons2;

    [HideInInspector] public Vector3[] startPosition;

    public GameObject button1;
    public GameObject button2;

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

}