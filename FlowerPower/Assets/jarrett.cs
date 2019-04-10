using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jarrett : MonoBehaviour
{
    public float force;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position +=  new Vector3(0,1 * force,0) * Time.deltaTime;

        }
    }
}
