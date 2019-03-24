using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    //public GameObject[] healthPetals;
    public GameObject[] healthPetals;


    public PlayerStats playerStats;


    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();

    }

    // Update is called once per frame
    void Update()
    {
     

    }


    public void LoseHealth()
    {


        //player.totalHealth = 6
        //player.currentHealth = 4
        //6 - 4 = 2 so you only disable 2 pellets

        for (int i = 0; i <playerStats.maxHealth-  playerStats.currentHealth; i++)
        {
            healthPetals[i].SetActive(false);
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