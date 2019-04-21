using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (playerStats.currentHealth < playerStats.maxHealth)
            {
                playerStats.currentHealth++;
                Destroy(gameObject);
                Debug.Log("The water has regenerated you! Your health is now : " + playerStats.currentHealth + "/" + playerStats.maxHealth);

            }
            else if (playerStats.currentHealth >= playerStats.maxHealth)
            {
                playerStats.maxHealth = 6;
                Debug.Log("You are already at full health! Come back if you start losing petals!");
            }
        }
    }
}
