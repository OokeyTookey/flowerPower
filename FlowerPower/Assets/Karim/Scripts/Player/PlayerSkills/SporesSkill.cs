﻿using System.Collections;
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
    int firePointOffset;

    void Start()
    {
        firePointOffset = 1;
        playerMovement = FindObjectOfType<AnnaPlayerMovement>();
    }

    private void Update()
    {
        sporeActiveDuration -= Time.deltaTime;


    }

    public void LaunchSpores()
    {
        Physics.IgnoreLayerCollision(10, 11);
        intSpore = Instantiate(sporesPrefab, new Vector3(playerLocation.transform.position.x,
                   playerLocation.transform.position.y + firePointOffset, playerLocation.transform.position.z),
                                                                                playerMovement.transform.rotation);

        intSpore.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce * multiplier);
    }

    public void DestroySpore()
    {
        Destroy(intSpore, 5);
    }

    public void RunFunction()
    {
        LaunchSpores();
        DestroySpore();
        sporeActiveDuration = sporeDuration;

    }
}