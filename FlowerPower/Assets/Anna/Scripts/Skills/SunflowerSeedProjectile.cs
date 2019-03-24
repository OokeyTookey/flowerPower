using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedProjectile : Skills
{
    public float projectileSpawnOffset;
    public GameObject sunFlowerSeedPrefab;
    public GameObject projectileSpawnLocation;
    GameObject spawnedProjectile;
    Skills skills;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            spawnedProjectile = Instantiate(sunFlowerSeedPrefab, projectileSpawnLocation.transform.position, transform.rotation);
        }
    }
}