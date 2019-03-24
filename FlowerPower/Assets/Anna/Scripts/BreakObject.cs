using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    public GameObject brokenObject;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(brokenObject,transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
