using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    [HideInInspector] public List<Objective> puzzlesList;
    [HideInInspector] public Objective currentPuzzle;
    [HideInInspector] public int current = 0;

    private void Start()
    {
        StartLevel();
    }

    public void StartLevel()
    {
        current = 0;
        puzzlesList[current].Begin();
        currentPuzzle = puzzlesList[current];
    }

    public void Next()
    {
        current++;
        puzzlesList[current].Begin();
        currentPuzzle = puzzlesList[current];
    }

    public void Previous()
    {
        current--;
        puzzlesList[current].Begin();
        currentPuzzle = puzzlesList[current];
    }
}