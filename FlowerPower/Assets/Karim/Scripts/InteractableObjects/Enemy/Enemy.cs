using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
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

    public void DealDamage()
    {
        playerStats.currentHealth -= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DealDamage();
        }
    }
}
