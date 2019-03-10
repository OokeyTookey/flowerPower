using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoint : MonoBehaviour
{
    public Rigidbody playerReference;
    public Vector3 projectileSpawnLocation;
    Vector3 hitPointOffset;

    void Start()
    {
        projectileSpawnLocation = transform.position - playerReference.transform.position;
    }

    void FixedUpdate()
    {
        transform.position = playerReference.transform.position + hitPointOffset;

        hitPointOffset = playerReference.position + projectileSpawnLocation;
        transform.rotation = Quaternion.Euler(new Vector3(playerReference.transform.rotation.eulerAngles.x, 
            90, playerReference.transform.rotation.eulerAngles.z));


    }
}
