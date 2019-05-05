using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTimer : MonoBehaviour
{
    public PlayerHealth1 playerHealth1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth1.theyDidIt = true;
        }
    }
}
