using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerSeedMovement : MonoBehaviour
{
    public float speed;
    public float fireRate;
    Rigidbody RB;
    AnnaPlayerMovement annaPlayerMovement;

    //---
    Vector3 direction;

    private Quaternion rotation;

   /* void RotateTowardsDirection(GameObject bullet, Vector3 destination)
    {
        direction = destination - bullet.transform.position;
        rotation = Quaternion.LookRotation(direction);
    }*/

    private void Start()
    {
        annaPlayerMovement = transform.GetComponent<AnnaPlayerMovement>();
        annaPlayerMovement = FindObjectOfType<AnnaPlayerMovement>();
        RB = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //RB.AddForce(transform.forward * (speed * Time.deltaTime), ForceMode.Acceleration);
        //RB.AddForceAtPosition(Vector3.forward * 600, transform.position, ForceMode.Impulse);
        //Debug.Log(annaPlayerMovement.speed);
        //RB.AddForceAtPosition(, transform.position, ForceMode.Impulse);
        //transform.position = transform.TransformPoint(Vector3.forward * (speed * Time.deltaTime));
        //transform.position += annaPlayerMovement.direction * (speed * Time.deltaTime);
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collsion");
        speed = 0;
        Destroy(this.gameObject);
    }*/
}
