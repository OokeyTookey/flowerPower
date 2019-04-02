using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SporesSkill))]
[RequireComponent(typeof(ThornsSkill))]
[RequireComponent(typeof(SunflowerSeedProjectile))]

public class SkillController : MonoBehaviour
{

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

    void Start()
    {
        sporeSkill = this.GetComponent<SporesSkill>();
        thornsSkill = this.GetComponent<ThornsSkill>();
        sunflowerSeedSkill = this.GetComponent<SunflowerSeedProjectile>();

        SeedUNLOCKED = false;
        thornsUNLOCKED = false;
        sporesUNLOCKED = false;
    }

    void Update()
    {
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
                if (cooldownTimerSpores > sporeCooldown)
                {
                    sporeSkill.RunFunction();
                    Debug.Log("<color=green> Sports Skill:</color><b> Active</b>");
                    cooldownTimerSpores = 0;
                }
            }
        }
    }
}