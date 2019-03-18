using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporesSkill : MonoBehaviour
{
    public AnnaPlayerMovement playerMovement;
    public GameObject spores;
    public float throwForce;



    // Start is called before the first frame update
    void Start()
    {


        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            LaunchSpores();
        }


    }

    public void LaunchSpores()
    {
        GameObject intSpore = Instantiate(spores, playerMovement.transform.position , playerMovement.transform.rotation);
        intSpore.GetComponent<Rigidbody>().AddForce(transform.right * throwForce );
        Debug.Log(throwForce);
    } 
}
