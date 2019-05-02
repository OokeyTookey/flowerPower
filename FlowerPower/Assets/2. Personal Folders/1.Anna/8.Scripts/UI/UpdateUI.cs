using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{
    // - When petal is lost, fade colour to grey.
    // - Slowly make fall
    // - change alpha to 0

    // - When petal is gained, make it "grow" from face. (Increase size with animation)

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
            if (playerStats.currentHealth >= 0)
            {
                UIHealthPetals[i].SetActive(false);
            }
        }

        for (int i = playerStats.maxHealth - 1; i >= playerStats.maxHealth - playerStats.currentHealth; i--)
        {
            if (playerStats.currentHealth <= playerStats.maxHealth)
                UIHealthPetals[i].SetActive(true);
        }
    }
}