using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    float randomNumber;
    float timer;
    Light thisLight;

    void Start()
    {
        thisLight = this.GetComponent<Light>();
        randomNumber = Random.Range(3, 5);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= randomNumber)
        {
            thisLight.enabled = false;
            timer = 0;
            randomNumber = Random.Range(3, 5);
        }

        else
        {
            thisLight.enabled = true;
        }

    }
}
