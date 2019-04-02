using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private Health playerHealth;
    [HideInInspector]public int maxHealth;
    [SerializeField] public int currentHealth;
    float invincibleTimer;
    public float invincibleLength;
    public bool invincible;

   



    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<Health>();
        maxHealth = 6;
        currentHealth = maxHealth;
        invincibleTimer = 2;
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = 6;
        }

        /*if (Input.GetKeyDown(KeyCode.T) && currentHealth <= maxHealth)
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
        }*/

        if (Input.GetKeyDown(KeyCode.H) && currentHealth <= maxHealth)
        {
            currentHealth++;
            playerHealth.GainHeath();
            Debug.Log(currentHealth + "/" + maxHealth);
        }

        invincibleTimer -= Time.deltaTime;
        if(invincibleTimer <= 0)
        {
            invincible = false;
        }

    }

    public void TakeDamage()
    {
        currentHealth --;
        playerHealth.LoseHealth(); //Access the health class and removed a petal in the array
        invincible = true;
        invincibleTimer = 2;
    }
}