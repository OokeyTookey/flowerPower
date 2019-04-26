using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : IState
{

    public int randomPatrolSpot;
    public Transform[] patrolSpot;
    public GameObject enemy;
    public float speed;
    public float waitTime;
    public float startWaitTime;


    public Patrol(Transform[] _patrolSpot, GameObject _enemy, int randomSpot, float _speed, float _waitTime, float _startWaitTime)
    {
        this.patrolSpot = _patrolSpot;
        this.enemy = _enemy;
        this.randomPatrolSpot = randomSpot;
        this.speed = _speed;
        this.waitTime = _waitTime;
        this.startWaitTime = _startWaitTime;

    }

    public void Enter()
    {
        randomPatrolSpot = Random.Range(0, patrolSpot.Length);
    }

    public void Execute()
    {
        
        Debug.Log("Patrol State");
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, patrolSpot[randomPatrolSpot].position, speed * Time.deltaTime);


        if (Vector3.Distance(enemy.transform.position, patrolSpot[randomPatrolSpot].position) < 3f)
        {
            if (waitTime <= 0)
            {
                randomPatrolSpot = Random.Range(0, patrolSpot.Length);
                waitTime = startWaitTime;
            }
            else
            {
               
                waitTime -= Time.deltaTime;
            }
        }
    }

    public void Exit()
    {

    }
}
