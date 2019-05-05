using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public int sceneNumber;
    public bool portalOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && portalOpen == true)
        {
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
