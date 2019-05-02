using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject impassableCollider;
    public bool puzzleComplete;
    public Vector3 buttonPressedOffest;
    public GameObject[] pistons;
    public Vector3[] startPosition;
    Vector3 newButtonLocation;
    int index;

    private void Start()
    {
        newButtonLocation = transform.position + buttonPressedOffest;

        for (int i = 0; i < pistons.Length; i++)
        {
            startPosition[i] = pistons[i].transform.position;
        }
    }

    private void Update()
    {
        if (puzzleComplete)
        {
            for (int i = 0; i < pistons.Length; i++)
            {
                pistons[i].GetComponent<Animator>().enabled = false;
                pistons[i].transform.position = Vector3.Lerp(pistons[i].transform.position, startPosition[i], Time.deltaTime);
            }
            transform.position = Vector3.Lerp(transform.position, newButtonLocation, Time.deltaTime);
            impassableCollider.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetButtonDown("Interact"))
        {
            puzzleComplete = true;
        }
    }
}
