using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    private IState currentState;

    public void ChangeState(IState newState)
    {
       
        if (currentState != null)
        {
            this.currentState.Exit();
        }
        this.currentState = newState;
        this.currentState.Enter();
    }
    public void ExecuteState()
    {
       if(currentState != null)
        {
            currentState.Execute();
        }
    }

    public void ExitState()
    {
        currentState.Exit();
    }

}
