using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puzzle4 : MonoBehaviour
{

   
    public SceneChanger sceneChanger;
    public bool puzzleComplete;
    public int enemiesKilled;
    public int requiredKills;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        sceneChanger = FindObjectOfType<SceneChanger>();
        sceneChanger.portalOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesKilled == requiredKills)
        {
            puzzleComplete = true;
            sceneChanger.portalOpen = true;
        }
    }
}
