using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTweenToPosition : MonoBehaviour
{
    public GameObject endPosition;
    public GameObject[] cameraPositions;
    public float tweenSpeed;
    bool isTurnedOn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isTurnedOn = true;
        }

        if (isTurnedOn)
        {
            StartCoroutine(MultipleCameraPositions());
        }
    }

    private IEnumerator MultipleCameraPositions()
    {
        float percentage = 1;
        while (percentage > 0)
        {
            percentage += 0.01f;
            for (int i = 0; i < cameraPositions.Length-1; i++)
            {
                transform.position = Vector3.Lerp(transform.position, cameraPositions[i].transform.position, percentage * Time.deltaTime);
                transform.rotation = Quaternion.Slerp(transform.rotation, cameraPositions[i].transform.rotation, percentage * Time.deltaTime);
                Debug.DrawLine(transform.position, cameraPositions[i].transform.position);
                yield return new WaitForSeconds(2f);
            }
        }
    }
}