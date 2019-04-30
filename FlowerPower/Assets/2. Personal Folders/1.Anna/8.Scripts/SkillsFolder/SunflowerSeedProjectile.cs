using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedProjectile : MonoBehaviour
{
    public GameObject sunFlowerSeedPrefab;
    public GameObject playerLocation;
    GameObject spawnedProjectile;
    int offset;

    private void Start()
    {
        offset = 1;
    }

    public void RunFunction()
    {
        spawnedProjectile = Instantiate(sunFlowerSeedPrefab, new Vector3(playerLocation.transform.position.x, 
                                                                         playerLocation.transform.position.y + offset, 
                                                                 playerLocation.transform.position.z), playerLocation.transform.rotation);
    }
}