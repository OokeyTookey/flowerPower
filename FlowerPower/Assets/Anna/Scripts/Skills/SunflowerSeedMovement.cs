using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedMovement : MonoBehaviour
{
    public float speed;
    public LayerMask ThisLayer;
    public LayerMask PlayerLayer;
    private Rigidbody bulletRB;

    private void Start()
    {
        Physics.IgnoreLayerCollision(10, 11); //ThisLayer.value
        bulletRB = this.GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collsion");
        speed = 0;
        Destroy(this.gameObject);
    }
}