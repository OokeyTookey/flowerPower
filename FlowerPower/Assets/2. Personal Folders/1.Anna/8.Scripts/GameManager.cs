using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public Vector3 lastCheckpointLocation;

    private void Awake() //Singleton
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else Destroy(gameObject);
    }

    private void Update()
    {
        
    }
}
