using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform[] targets;
    public float followSpeed;

    private void Update()
    {
        var position = Vector3.zero;
        for (int i = 0; i < targets.Length; i++)
        {
            position += targets[i].position;
        }
        position /= targets.Length;

        var distance = Vector3.Distance(transform.position, position);
        this.transform.position = Vector3.Lerp(transform.position, position, followSpeed * Time.deltaTime * distance);
    }
}
