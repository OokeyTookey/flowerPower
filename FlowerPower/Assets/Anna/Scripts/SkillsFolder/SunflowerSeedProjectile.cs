using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedProjectile : Skills
{
    public GameObject sunFlowerSeedPrefab;
    public GameObject projectileSpawnLocation;
    GameObject spawnedProjectile;

    public void RunFunction()
    {
        spawnedProjectile = Instantiate(sunFlowerSeedPrefab, projectileSpawnLocation.transform.position, transform.rotation);
    }
}