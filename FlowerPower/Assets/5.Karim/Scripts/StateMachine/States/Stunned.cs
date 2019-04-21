using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stunned : IState
{
    Rigidbody enemyRB;
    float speed;
    float stunTime;
    float stunDuration;
    public bool stunned;
    

    public Stunned(Rigidbody _enemyRB, float _speed, float _duration)
    {
        this.enemyRB = _enemyRB;
        this.speed = _speed;
        this.stunDuration = _duration;
    }

    public void Enter()
    {
    }

    public void Execute()
    {
        if (stunned)
        {
            
            speed = 0;
            enemyRB.constraints = RigidbodyConstraints.FreezeRotation;
            stunDuration -= Time.deltaTime;
        }



        if (stunDuration <= 0)
        {
            stunned = false;
            enemyRB.constraints = RigidbodyConstraints.None;
            speed = 5;
            stunDuration = 2;
        }
    }

    public void Exit()
    {
    }

    
}
