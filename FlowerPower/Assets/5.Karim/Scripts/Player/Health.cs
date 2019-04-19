using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject[] healthPetals;
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void LoseHealth()
    {
        for (int i = 0; i < playerStats.maxHealth - playerStats.currentHealth; i++)
        {
            if (playerStats.currentHealth >= 0)
            {
                healthPetals[i].SetActive(false);
            }
        }
    }

    public void GainHeath()
    {
        for (int i = playerStats.maxHealth -1; i >= playerStats.maxHealth - playerStats.currentHealth ; i--)
        {
            if(playerStats.currentHealth <= playerStats.maxHealth)
            healthPetals[i].SetActive(true);
        }
    }
}