using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;
    public GameObject health6;

    public PlayerStats playerStats;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowHealth();
    }

    public void ShowHealth()
    {
        if(playerStats.currentHealth == 6)
        {
            health1.gameObject.SetActive(true);
            health2.gameObject.SetActive(true);
            health3.gameObject.SetActive(true);
            health4.gameObject.SetActive(true);
            health5.gameObject.SetActive(true);
            health6.gameObject.SetActive(true);

        }
        if (playerStats.currentHealth == 5)
        {
            health1.gameObject.SetActive(false);
            health2.gameObject.SetActive(true);
            health3.gameObject.SetActive(true);
            health4.gameObject.SetActive(true);
            health5.gameObject.SetActive(true);
            health6.gameObject.SetActive(true);

        } if (playerStats.currentHealth == 4)
        {
            health1.gameObject.SetActive(false);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(true);
            health4.gameObject.SetActive(true);
            health5.gameObject.SetActive(true);
            health6.gameObject.SetActive(true);

        }
        if (playerStats.currentHealth == 3)
        {
            health1.gameObject.SetActive(false);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(false);
            health4.gameObject.SetActive(true);
            health5.gameObject.SetActive(true);
            health6.gameObject.SetActive(true);

        }
        if (playerStats.currentHealth == 2)
        {
            health1.gameObject.SetActive(false);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(false);
            health4.gameObject.SetActive(false);
            health5.gameObject.SetActive(true);
            health6.gameObject.SetActive(true);

        }
        if (playerStats.currentHealth == 1)
        {
            health1.gameObject.SetActive(false);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(false);
            health4.gameObject.SetActive(false);
            health5.gameObject.SetActive(false);
            health6.gameObject.SetActive(true);

        }
        if (playerStats.currentHealth == 0)
        {
            health1.gameObject.SetActive(false);
            health2.gameObject.SetActive(false);
            health3.gameObject.SetActive(false);
            health4.gameObject.SetActive(false);
            health5.gameObject.SetActive(false);
            health6.gameObject.SetActive(false);

        }
    }
}
