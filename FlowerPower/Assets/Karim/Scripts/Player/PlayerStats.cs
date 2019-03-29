using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public Health playerHealth;
    public int maxHealth;
    public int currentHealth;
    public float invincibleTime;
    public bool invincible;

   



    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<Health>();
        maxHealth = 6;
        currentHealth = maxHealth;
        invincibleTime = 2;
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = 6;
        }
        if (Input.GetKeyDown(KeyCode.T) && currentHealth <= maxHealth)
        {
            if (currentHealth > 0)
            {
                currentHealth--;
                playerHealth.LoseHealth();
                Debug.Log(currentHealth + "/" + maxHealth);
            }
          
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.H) && currentHealth <= maxHealth)
        {
            currentHealth++;
            playerHealth.GainHeath();
            Debug.Log(currentHealth + "/" + maxHealth);
        }

        invincibleTime -= Time.deltaTime;
        if(invincibleTime <= 0)
        {
            invincible = false;
        }

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        invincible = true;
        invincibleTime = 2;
    }
}