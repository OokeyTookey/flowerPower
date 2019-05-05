using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public SceneFeeder sceneFeeder;
    public Animator transitionAnimator;
    [HideInInspector]public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sceneName = null;
            sceneName = sceneFeeder.scene;
            StartCoroutine(LoadScene());
        }
    }

    public IEnumerator LoadScene()
    {
        transitionAnimator.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}