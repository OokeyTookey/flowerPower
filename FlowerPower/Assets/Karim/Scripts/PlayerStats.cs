using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

   



    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 6;
        currentHealth = maxHealth;
       
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
                Debug.Log(currentHealth + "/" + maxHealth);
            }
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
        }


    }
}