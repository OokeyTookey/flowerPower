using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFadeController : MonoBehaviour
{
    TransitionController transitionController;
    public Animator newGameTransition;
    public void MainMenuButtonsTransition()
    {
        newGameTransition.SetTrigger("end");
        transitionController.StartCoroutine(transitionController.LoadScene());  //Does generic fade
    }
}
