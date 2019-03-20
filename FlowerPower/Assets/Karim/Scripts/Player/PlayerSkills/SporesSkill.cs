using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporesSkill : Skills
{
    public AnnaPlayerMovement playerMovement;
    public Enemy enemy;
    public GameObject spores;
    public GameObject intSpore;
    
    public float throwForce;
    public float sporeDuration;
    public float distractedDuration;



    // Start is called before the first frame update
    void Start()
    {
        sporeDuration = 10;
        enemy = FindObjectOfType<Enemy>();
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LaunchSpores();
        }
        sporeDuration -= Time.deltaTime;
    }

    public void LaunchSpores()
    {
        intSpore = Instantiate(spores, playerMovement.transform.position , playerMovement.transform.rotation);
        intSpore.GetComponent<Rigidbody>().AddForce(transform.right * throwForce );
        enemy.distractedTimer = 3;

        Destroy(intSpore, 3);


        Debug.Log(throwForce);
    } 


}
