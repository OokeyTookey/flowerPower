using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFan : MonoBehaviour
{
    public float fanSpeed;
    
    void Update()
    {
        transform.Rotate(0, fanSpeed, 0);
    }
}
