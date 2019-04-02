using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public bool invincible;
    public float invincibleLength;
    [HideInInspector] public int maxHealth;
    [SerializeField] public int currentHealth;

    private Health playerHealth;
    private float invincibleTimer;

    void Start()
    {
        playerHealth = FindObjectOfType<Health>();
        maxHealth = 6;
        currentHealth = maxHealth;
        invincibleTimer = 2;
        invincible = false;
    }

    void Update()
    {
        invincibleTimer -= Time.deltaTime;

        if (currentHealth > maxHealth)
        {
            currentHealth = 6;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }

        if (invincibleTimer <= 0)
        {
            invincible = false;
        }

        if (Input.GetKeyDown(KeyCode.H)) //TESTING PURPOSES TO HEAL
        {
            GainHealth();
        }
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            playerHealth.LoseHealth(); //Access the health class and removed a petal in the array
            invincible = true;
            invincibleTimer = 2;
        }
    }

    public void GainHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            playerHealth.GainHeath();
            Debug.Log(currentHealth + "/" + maxHealth);
        }
    }
}