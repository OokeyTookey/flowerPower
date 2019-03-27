using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarimSporeSkill : MonoBehaviour
{
    public AnnaPlayerMovement playerMovement;
    public Enemy enemy;
    public GameObject spores;
    public GameObject intSpore;
    public GameObject firepoint;

    public float throwForce;
    public float sporeDuration;
    public float distractedDuration;

    public void RunFunction()
    {
        LaunchSpores();
    }

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
        /*if (Input.GetKeyDown(KeyCode.G))
        {
            LaunchSpores();
        }*/
        sporeDuration -= Time.deltaTime;
    }

    public void LaunchSpores()
    {
        intSpore = Instantiate(spores, firepoint.transform.position, playerMovement.transform.rotation);
        intSpore.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
        enemy.distractedTimer = 10;

        Destroy(intSpore, 10);


        Debug.Log(throwForce);
    }


}

