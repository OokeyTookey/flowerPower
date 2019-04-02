using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnaCheckpoints : MonoBehaviour
{
    private static AnnaCheckpoints instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else Destroy(gameObject);
    }
}
