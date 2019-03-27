using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporesSkill : Skills
{
    public AnnaPlayerMovement playerMovement;
    private Enemy enemy;
    public GameObject spores;
    public GameObject intSpore;
    public GameObject firepoint;

    public float sporeActiveDuration;
    public float throwForce;
    public float sporeDuration;
    public float distractedDuration;
    public int multiplier;

    void Start()
    {
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
    }

    void Update()
    {
        RunFunction();
    }

    public void LaunchSpores()
    {
        intSpore = Instantiate(spores, firepoint.transform.position, playerMovement.transform.rotation);
        intSpore.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce * multiplier);

       
        //enemy.distractedTimer = distractedDuration;
        


        Debug.Log(throwForce);
    }
    public void DestroySpore()
    {
        if (sporeActiveDuration <= 0)
        {
            sporeActiveDuration = sporeDuration;
            Destroy(intSpore);
        }
    }

    public void RunFunction()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LaunchSpores();

        }
        if (intSpore !=null)
        {
            sporeActiveDuration -= Time.deltaTime;
        }

        DestroySpore();
        


    }

   
}
