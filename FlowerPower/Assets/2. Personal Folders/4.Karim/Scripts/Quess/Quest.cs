using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{

    [HideInInspector] public List<Objective> objective;
    private int current = 0;
    [HideInInspector] public Objective currentObjective;


    // Start is called before the first frame update

    public void Start()
    {
        StartQuest();
    }
    public void StartQuest()
    {
        current = 0;
        objective[current].Begin();
        currentObjective = objective[current];
    }

    public void Next()
    {
        current++;
        objective[current].Begin();
        currentObjective = objective[current];

    }

    public void Previous()
    {
        current--;
        objective[current].Begin();
        currentObjective = objective[current];

    }

  
}
