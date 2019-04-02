using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPuddle : MonoBehaviour
{
    public PlayerStats playerStats;
    public float damageDelay;

    // Start is called before the first frame update
    void Start()
    {
        damageDelay = 2;
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        damageDelay -= Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && damageDelay <= 0)
        {
            if (playerStats.currentHealth > 0 && playerStats.invincible == false)
            {
                playerStats.TakeDamage();
                Debug.Log(playerStats.currentHealth);
            }

        }
    }
        private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && damageDelay <= 0)
        {
            if (playerStats.currentHealth > 0 && playerStats.invincible == false)
            {
                playerStats.TakeDamage();
                Debug.Log(playerStats.currentHealth);
            }

        }
    }
}
