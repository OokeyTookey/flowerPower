using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedMovement : MonoBehaviour
{
    public float speed;
    public LayerMask ThisLayer;
    public LayerMask PlayerLayer;
    int thisLayerValue;
    int playerLayerValue;
    private Rigidbody bulletRB;

    private void Start()
    {
        Physics.IgnoreLayerCollision(10, 11); //Compares 
        bulletRB = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime); //Moves projectile
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        Destroy(this.gameObject);
    }
}