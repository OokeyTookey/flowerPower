using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    Renderer[] rends;
    public List<Color> OriginalColors;

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

        int f = 0; //Acts as an index to remember the colour location
        rends = this.GetComponentsInChildren<MeshRenderer>(); //Accesses all the meshrenderers in the children

        for (int i = 0; i < rends.Length; i++)
        {
            for (int j = 0; j < rends[i].materials.Length; j++)
            {
                OriginalColors.Add(rends[i].materials[j].color); //Adds the childrens materials.color
                f++;
            }
        }
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
            StartCoroutine(ColourFlash(new Color(1,0,0,1)));
        }
    }

    public void GainHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            playerHealth.GainHeath();
            Debug.Log(currentHealth + "/" + maxHealth);
            StartCoroutine(ColourFlash(new Color(0, 1, 0, 1)));
        }
    }

    IEnumerator ColourFlash(Color color)
    {
        int t = 0;
        for (int i = 0; i < rends.Length; i++)
        {
            for (int j = 0; j < rends[i].materials.Length; j++)
            {
                rends[i].materials[j].color = color;
                t++;
            }
        }

        yield return new WaitForSeconds(0.1f);

        t = 0;
        for (int i = 0; i < rends.Length; i++)
        {
            for (int j = 0; j < rends[i].materials.Length; j++)
            {
                rends[i].materials[j].color = OriginalColors[t];
                t++;
            }
        }

    }
}