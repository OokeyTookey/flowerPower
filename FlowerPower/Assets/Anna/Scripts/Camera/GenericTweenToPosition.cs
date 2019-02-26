using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTweenToPosition : MonoBehaviour
{
    public GameObject endPosition;
    public GameObject[] cameraPositions;
    public float tweenSpeed;
    bool isTurnedOn;

    void Start()
    {

    }

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
        for (int i = 0; i < cameraPositions.Length; i++)
        {
            transform.position = Vector3.Lerp(transform.position, cameraPositions[i].transform.position, tweenSpeed * Time.deltaTime);
            Debug.DrawLine(transform.position, cameraPositions[i].transform.position);
            yield return new WaitForSeconds(2f);
        }
    }
}
