using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporesSkill : Skills
{
    public AnnaPlayerMovement playerMovement;
    public EnemyBehaviorTree EBT;
    private Enemy enemy;
    public GameObject spores;
    public GameObject intSpore;
    public GameObject firepoint;

    public float sporeActiveDuration;
    public float sporeDuration;

    public float throwForce;
    public float distractedDuration;
    public int multiplier;

    void Start()
    {
        EBT = FindObjectOfType<EnemyBehaviorTree>();
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
        sporeActiveDuration = sporeDuration;
      
    }

    void Update()
    {
        RunFunction();

        sporeActiveDuration -= Time.deltaTime;
    }

    public void LaunchSpores()
    {
        sporeActiveDuration = sporeDuration;
        intSpore = Instantiate(spores, firepoint.transform.position, playerMovement.transform.rotation);
        if(intSpore !=null)
        {

        intSpore.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce * multiplier);
        }
        sporeActiveDuration = sporeDuration;
      
       
        //enemy.distractedTimer = distractedDuration;
        


        Debug.Log(throwForce);
    }
    public void DestroySpore()
    {
        if (intSpore !=null && sporeActiveDuration <= 0)
        {
            Destroy(intSpore);
           
            
        }
    }

    public void RunFunction()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            
            LaunchSpores();
            
        }


        DestroySpore();



    }

   
}
