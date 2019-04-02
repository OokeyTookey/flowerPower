using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    Health healthRef;
    PlayerStats playerStats;
    public GameObject[] UIHealthPetals;

    private void Start()
    {
        healthRef = FindObjectOfType<Health>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        for (int i = 0; i < playerStats.maxHealth - playerStats.currentHealth; i++)
        {
            UIHealthPetals[i].SetActive(false);
        }
    }
}