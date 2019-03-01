using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedProjectile : MonoBehaviour
{
    private GameObject sunFlowerSeed;
    public GameObject projectileSpawnLocation;
    public List<GameObject> projectileSeeds = new List<GameObject>();

    void Start()
    {
        if (projectileSpawnLocation == null)
        {
            Debug.LogError("No sunflower seed spawn location -A");
        }

        sunFlowerSeed = projectileSeeds[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SpawnProjectile();
        }
    }

    public void SpawnProjectile()
    {
        GameObject spawnedProjectile;

        if ( projectileSpawnLocation != null)
        {
            spawnedProjectile = Instantiate(sunFlowerSeed, projectileSpawnLocation.transform.position, Quaternion.identity);
        }

        else
        {
            Debug.LogError("Projectile not fired. -A");
        }
    }
}
