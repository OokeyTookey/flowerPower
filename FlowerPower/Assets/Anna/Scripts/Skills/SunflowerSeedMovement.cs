using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedMovement : MonoBehaviour
{
    public float speed;
    public float fireRate;


    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }

        else Debug.Log("No projectile speed, sunflower seed.");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collsion");
        speed = 0;
        Destroy(this.gameObject);
    }
}
