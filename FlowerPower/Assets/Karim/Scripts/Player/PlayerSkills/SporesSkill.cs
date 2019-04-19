using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporesSkill : MonoBehaviour
{
    public AnnaPlayerMovement playerMovement;
    private Enemy enemy;
    public GameObject sporesPrefab;
    public GameObject intSpore;
    public GameObject playerLocation;

    public float sporeActiveDuration;
    public float throwForce;
    public float sporeDuration;
    public float distractedDuration;
    public int multiplier;
    int offset;

    void Start()
    {
        offset = 1;
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
    }
    private void Update()
    {
        RunFunction();
    }
    public void LaunchSpores()
    {
        Physics.IgnoreLayerCollision(10, 11);
        intSpore = Instantiate(sporesPrefab, new Vector3(playerLocation.transform.position.x,
                   playerLocation.transform.position.y + offset, playerLocation.transform.position.z),
                                                                                playerMovement.transform.rotation);

        intSpore.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce * multiplier);
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

        if (Input.GetKey(KeyCode.G))
        {
            LaunchSpores();
        }
        if (intSpore != null)
        {
            sporeActiveDuration -= Time.deltaTime;
        }
    }
}