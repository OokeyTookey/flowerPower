using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SporesSkill))]
[RequireComponent(typeof(ThornsSkill))]
[RequireComponent(typeof(SunflowerSeedProjectile))]

//ANNA TO DO:
    //- Access mesh render and make flicker green when healing.
    //- Do the same for damage, make red.

    //- CLEANUP SCRIPTS

    //&&&&- Animation petals, check drive and bones??
    //&&&&- Check rosie texture


public class PlayerManager : MonoBehaviour
{
    PlayerStats playerStats;
    AnnaPlayerMovement playerMovement;

    [Space]
    [Header("//------ Player Reactions ------")]
    public float gooSpeedDivider;

    [Header("//------ Sunflower Skill ------------")]
    public bool SeedUNLOCKED;
    [Range(0, 10)] public float sunflowerCooldown;
    float cooldownTimerSeed;
    SunflowerSeedProjectile sunflowerSeedSkill;

    [Space] //---------------

    [Header("//------ Thorns Skill ------------")]
    public bool thornsUNLOCKED;
    [Range(0, 10)] public float thornsCooldown;
    float cooldownTimerThorns;
    ThornsSkill thornsSkill;

    [Space] //---------------

    [Header("//------ Spore Skill ------------")]
    public bool sporesUNLOCKED;
    [Range(0, 10)] public float sporeCooldown;
    float cooldownTimerSpores;
    SporesSkill sporeSkill;

    float healOverTimer;
    public float healOverTimeDelay;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();

        sporeSkill = GetComponent<SporesSkill>();
        thornsSkill = GetComponent<ThornsSkill>();
        sunflowerSeedSkill = GetComponent<SunflowerSeedProjectile>();

        /*SeedUNLOCKED = false;
        thornsUNLOCKED = false;
        sporesUNLOCKED = false;*/

        healOverTimer = healOverTimeDelay;
    }

    void Update()
    {
        healOverTimer -= Time.deltaTime;

        //---------------------------------------------------- Skills -------------------------------------------------------

        cooldownTimerSeed += Time.deltaTime;
        cooldownTimerThorns += Time.deltaTime;
        cooldownTimerSpores += Time.deltaTime;

        //---- Sunflower Skill
        if (SeedUNLOCKED == true)
        {
            if (Input.GetButton("Fire1")) //Left mouse button, Left Control & INSERT CONTROLLER SUPPORT HERE
            {
                if (cooldownTimerSeed > sunflowerCooldown) //If timer is greater than cooldown cost
                {
                    playerStats.TakeDamage();
                    sunflowerSeedSkill.RunFunction();
                    Debug.Log("<color=blue> Sunflower Skill:</color> <b>Active</b>");
                    cooldownTimerSeed = 0;
                }
            }
        }

        //---- Thorns Skill
        if (thornsUNLOCKED == true)
        {
            if (Input.GetButton("Fire2")) //Q, Left alt & INSERT CONTROLLER SUPPORT HERE
            {
                if (cooldownTimerThorns > thornsCooldown)
                {
                    playerStats.TakeDamage();
                    thornsSkill.thornsActive = true;
                    thornsSkill.RunFunction();

                    Debug.Log("<color=red> Thorns Skill:</color> <b>Active</b>");
                    cooldownTimerThorns = 0;
                }
            }
        }

        //---- Spores Skill
        if (sporesUNLOCKED == true)
        {
            if (Input.GetButton("Fire3")) //Right mouse button, E & INSERT CONTROLLER SUPPORT HERE
            {
                Debug.Log("<color=red> FIRE SKILL SPORE</color>");
                if (cooldownTimerSpores > sporeCooldown)
                {
                    playerStats.TakeDamage();
                    sporeSkill.RunFunction();
                    Debug.Log("<color=green> Sports Skill:</color><b> Active</b>");
                    cooldownTimerSpores = 0;
                }
            }
        }

        //---------------------------------------------------- Health -------------------------------------------------------

        if (playerStats.currentHealth <= 0)
        {
            Debug.Log("DEATH");
        }

        Debug.Log(playerStats.currentHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goo"))
        {
            playerMovement.speed = playerMovement.speed / gooSpeedDivider;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            if (playerStats.currentHealth < playerStats.maxHealth && healOverTimer <= 0)
            {
                playerStats.currentHealth++;
                playerStats.GainHealth();
                healOverTimer = healOverTimeDelay;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Goo"))
        {
            playerMovement.speed = playerMovement.speed * gooSpeedDivider;
        }
    }
}