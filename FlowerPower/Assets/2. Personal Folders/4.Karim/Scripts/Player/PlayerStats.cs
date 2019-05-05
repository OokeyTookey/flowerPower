using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public bool invincible;
    public float invincibleLength;

    [HideInInspector]public Animator anim;
    [HideInInspector] public int maxHealth;
    [SerializeField] public int currentHealth;

    private Health playerHealth;
    private float invincibleTimer;

    //Colour flash related ---
    public List<Color> OriginalColors;

    private Renderer[] rends;
    private List<Material> materialsL;
    private bool colourFlashOneHealth;
    private Coroutine flash;

    void Start()
    {
        playerHealth = FindObjectOfType<Health>();
        anim = this.GetComponent<Animator>();
        maxHealth = 6;
        currentHealth = maxHealth;
        invincibleTimer = 2;
        invincible = false;

        int f = 0; //Acts as an index to remember the colour location
        rends = this.GetComponentsInChildren<SkinnedMeshRenderer>(); //Accesses all the meshrenderers in the children

        for (int i = 0; i < rends.Length; i++)
        {
            for (int j = 0; j < rends[i].materials.Length; j++)
            {
                OriginalColors.Add(rends[i].materials[j].color); //Adds the childrens materials.color
                f++;
            }
        }
    }
    private void FixedUpdate()
    {
        if (currentHealth <= 1)
        {
            StopCoroutine("ColourFlash");
            OneHealth();
        }
    }

    void Update()
    {
        invincibleTimer -= Time.deltaTime;

        if (currentHealth > maxHealth)
        {
            currentHealth = 6;
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
            if(flash!=null)
            StopCoroutine(flash);

            flash = StartCoroutine(ColourFlash(Color.red, 0.1f));
        }
    }
    public void GainHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            playerHealth.GainHeath();
            Debug.Log(currentHealth + "/" + maxHealth);

            if (flash != null)
            {
                StopCoroutine(flash);
            }

            flash = StartCoroutine(ColourFlash(Color.green, 0.1f));
        }
    }

    public void OneHealth()
    {
        if (currentHealth == 1 && !colourFlashOneHealth)
        {
            if (flash != null)
            {
                StopCoroutine(flash);
            }

            flash = StartCoroutine(ColourFlash(Color.red, .2f, true));
            colourFlashOneHealth = true;
        }
    }

    IEnumerator ColourFlash(Color color, float delay,bool forever = false)
    {
        do //Goes through once at least then checks
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

            yield return new WaitForSeconds(delay);

            t = 0;
            for (int i = 0; i < rends.Length; i++)
            {
                for (int j = 0; j < rends[i].materials.Length; j++)
                {
                    rends[i].materials[j].color = OriginalColors[t];
                    t++;
                }
            }

            yield return new WaitForSeconds(delay);

        } while (forever); //While checks at the begining
    }
}