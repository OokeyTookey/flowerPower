using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedProjectile : MonoBehaviour
{
    public float projectileSpawnOffset;
    public GameObject sunFlowerSeedPrefab;
    public GameObject projectileSpawnLocation;
    GameObject spawnedProjectile;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            spawnedProjectile = Instantiate(sunFlowerSeedPrefab, projectileSpawnLocation.transform.position, transform.rotation);

            Time.timeScale = 0.05f;

            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.7f;
            }
            else
                Time.timeScale = 1.0f;
            // Adjust fixed delta time according to timescale
            // The fixed delta time will now be 0.02 frames per real-time second
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

        }
    }

    private IEnumerator SlowMotion()
    {
        yield return (1);
    }
}
