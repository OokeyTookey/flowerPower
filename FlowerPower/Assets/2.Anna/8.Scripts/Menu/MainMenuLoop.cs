using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLoop : MonoBehaviour
{
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
        float percentage = 0;
        while (percentage < 1)
        {
            percentage += 0.01f;

            for (int i = 0; i < cameraPositions.Length; i++)
            {
                 transform.position = Vector3.Lerp(transform.position, cameraPositions[i].transform.position, tweenSpeed * Time.deltaTime);
                 transform.rotation = Quaternion.Slerp(transform.rotation, cameraPositions[i].transform.rotation, tweenSpeed * Time.deltaTime);
                yield return new WaitForSeconds(2f);                
            }
        }
    }
}
