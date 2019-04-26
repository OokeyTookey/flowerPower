using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SporesSkill))]
[RequireComponent(typeof(ThornsSkill))]
[RequireComponent(typeof(SunflowerSeedProjectile))]

//ANNA TO DO:
    //- CLEANUP SCRIPTS

    //- Access mesh render and make flicker green when healing.
    //- Do the same for damage, make red.
    //- WHEN THE PLAYER LOOSES HEALTH MAKE PETAL FALL.
    //- GROW PETAL WHEN PLAYER GAINS HEALTH.
    // SAVE AND LOAD FOR CHECK POINTS (PLAYER STATE)


    //&&&&- Animation petals, check drive and bones??
    //&&&&- Check rosie texture


    //Mark LO ->
    // controlling thinga wiht buttons or triggers in game. Simple game. 


public class PlayerManager : MonoBehaviour
{
    PlayerStats playerStats;
    AnnaPlayerMovement playerMovement;
    public Animator UITransitionAnimator;
    public GameObject mainCamera;
    Animator mainCameraAnimator;
    TransitionController transitionController;

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

        healOverTimer = healOverTimeDelay;
        mainCameraAnimator = mainCamera.GetComponent<Animator>();
        transitionController = GetComponent<TransitionController>();
    }

    void Update()
    {
        healOverTimer -= Time.deltaTime;

        //---------------------------------------------------- Skills -------------------------------------------------------

        cooldownTimerSeed += Time.deltaTime;
        cooldownTimerThorns += Time.deltaTime;
        cooldownTimerSpores += Time.deltaTime;

        //---- Sunflower Skill
        if (SeedUNLOCKED && Input.GetButton("Fire1") && cooldownTimerSeed > sunflowerCooldown)
        {
            playerStats.TakeDamage();
            sunflowerSeedSkill.RunFunction();
            Debug.Log("<color=blue> Sunflower Skill:</color> <b>Active</b>");
            cooldownTimerSeed = 0;
        } 

        //---- Thorns Skill
        if (thornsUNLOCKED && Input.GetButton("Fire2") && cooldownTimerThorns > thornsCooldown)  //Q, Left alt & INSERT CONTROLLER SUPPORT HERE
        {
            playerStats.TakeDamage();
            thornsSkill.thornsActive = true;
            thornsSkill.RunFunction();
            Debug.Log("<color=red> Thorns Skill:</color> <b>Active</b>");
            cooldownTimerThorns = 0;
        }

        //---- Spores Skill
        if (sporesUNLOCKED == true && Input.GetButton("Fire3") && cooldownTimerSpores > sporeCooldown)
        {
            playerStats.TakeDamage();
            sporeSkill.RunFunction();
            Debug.Log("<color=green> Sports Skill:</color><b> Active</b>");
            cooldownTimerSpores = 0;
        }

        //---------------------------------------------------- Health -------------------------------------------------------

       /* if (playerStats.currentHealth <= 0)
        {
            Time.timeScale = 0;
        }*/

        Debug.Log(playerStats.currentHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goo"))
        {
            playerMovement.speed /= gooSpeedDivider;
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
            playerMovement.speed *= gooSpeedDivider;
        }
    }

    public void SavePlayer()
    {
        //SaveNLoad.SaveData(this);
    }

   /* public IEnumerator DeathScene()
    {
        UITransitionAnimator.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");
    }*/
}