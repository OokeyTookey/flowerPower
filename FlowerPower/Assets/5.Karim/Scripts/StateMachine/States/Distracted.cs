using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distracted : IState
{
    public GameObject target;
    public GameObject enemy;

    public float speed;
    public float distractedTime;
    public float radius;


    public Distracted(GameObject _enemy, GameObject _target, float _speed, float _distractedTime)
    {
       
        this.speed = _speed;
        this.enemy = _enemy;
        this.target = _target;
        this.distractedTime = _distractedTime;
    }

    public void Enter()
    {
        Debug.Log("Distracted");
    }

    public void Execute()
    {
        if(target!=null)
        enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target.transform.position, speed * Time.deltaTime);
        //distractedTime -= Time.deltaTime;
    }

    public void Exit()
    {
        
    }
}

