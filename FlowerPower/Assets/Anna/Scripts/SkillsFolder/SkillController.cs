using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    [Header("//------ Sunflower Skill ------")]
    public float sunflowerCooldown;
    SunflowerSeedProjectile sunflowerSeedSkill;

    [Space] //---------------

    [Header("//------ Thorns Skill ------")]
    public float thornsCooldown;
    KarimThornsSkill thornsSkill;

    [Space] //---------------

    [Header("//------ Spore Skill ------")]
    public float sporeCooldown;
    KarimSporeSkill sporeSkill;

    void Start()
    {
        sporeSkill = new KarimSporeSkill();
        thornsSkill = new KarimThornsSkill();
        sunflowerSeedSkill = new SunflowerSeedProjectile();

        sporeSkill.Start();
        thornsSkill.Start();
    }

    void Update()
    {
        sporeSkill.Update();
        
        //---- Sunflower Skill
        if (Input.GetButton("Fire1")) //Left mouse button, Left Control & INSERT CONTROLLER SUPPORT HERE
        {
            sunflowerSeedSkill.RunFunction();
            Debug.Log("<color=blue> Sunflower Skill:</color> <b>Active</b>");
        }

        /*//---- Thorns Skill
        if (Input.GetButton("Fire2")) //Q, Left alt & INSERT CONTROLLER SUPPORT HERE
        {
            thornsSkill.RunFunction();
            Debug.Log("<color=red> Thorns Skill:</color> <b>Active</b>");
        }

        //---- Spores Skill
        if (Input.GetButton("Fire3")) //Right mouse button, E & INSERT CONTROLLER SUPPORT HERE
        {
            sporeSkill.RunFunction();
            Debug.Log("<color=green> Sports Skill:</color><b> Active</b>");
        }*/
    }
}
