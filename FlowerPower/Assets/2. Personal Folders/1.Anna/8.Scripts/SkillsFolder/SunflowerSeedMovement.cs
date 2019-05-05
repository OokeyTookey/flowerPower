using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedMovement : MonoBehaviour
{
    private EnemyBehaviorTree EBT;
    public float speed;
    public LayerMask ThisLayer;
    public LayerMask PlayerLayer;
    int thisLayerValue;
    int playerLayerValue;
    private Rigidbody bulletRB;

    private void Start()
    {
        EBT = FindObjectOfType<EnemyBehaviorTree>();
        Physics.IgnoreLayerCollision(10, 11); //Compares 
        bulletRB = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.position += transform.forward * (speed * Time.deltaTime); //Moves projectile
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bee"))
        {
            EBT.enemyHealth -= 1;
            Destroy(collision.gameObject);
        }

        speed = 0;
        Destroy(this.gameObject);
    }
}