using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public SceneFeeder sceneFeeder;
    public Animator transitionAnimator;
    public string sceneName;
    public bool menuScene;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (menuScene && timer >= 5)
        {
            StartCoroutine(LoadScene());
        }
    }
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