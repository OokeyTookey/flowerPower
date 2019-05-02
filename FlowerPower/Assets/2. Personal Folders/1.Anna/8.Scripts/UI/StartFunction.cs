using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFunction : MonoBehaviour
{
    bool gamePaused;
    public Animator startPanelAnimation;

    private void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            Debug.Log("OIOIOI PAUSE SCENE");
            startPanelAnimation.SetInteger("StartPanel", 1);
            Time.timeScale = 0; //Stop the time
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenuAnna");
    }

    public void Resume()
    {
        Time.timeScale = 1; //starts the time
        startPanelAnimation.SetInteger("StartPanel", 2);
    }

    public void Controls()
    {
        //Tween new panel which shows the controls and how to play
    }

    public void Settings()
    {
        //panel fade in
    }
}
