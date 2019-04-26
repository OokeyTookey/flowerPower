using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public GameObject pressurePlate;
    public GameObject extendablePlatform;
    public GameObject targetposition;
    public float speed;
    public bool platePressed;
    // Start is called before the first frame update
    void Start()
    {
        platePressed = false;
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (platePressed)
        {
            extendablePlatform.transform.position = Vector3.MoveTowards(extendablePlatform.transform.position, targetposition.transform.position, speed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy is on Pressure Plate.");
            pressurePlate.transform.position += new Vector3(0, -0.05f, 0);
            Debug.Log("Pressure Plate Pressed.");
            platePressed = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Enemy is no longer on the plate.");
            pressurePlate.transform.position += new Vector3(0, 0.05f, 0);
            Debug.Log("Pressure plate released");
            platePressed = false;
        }
    }


}
