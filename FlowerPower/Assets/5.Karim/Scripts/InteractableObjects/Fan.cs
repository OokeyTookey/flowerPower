using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public int maxRayDistance;
    public LayerMask rayMask;
    public GameObject fan;
    public Rigidbody rb;
    public float thrust;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, -Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRayDistance, rayMask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin+ ray.direction * maxRayDistance, Color.green);
            rb.AddForce(Vector3.forward * thrust);
        }

    }
}
