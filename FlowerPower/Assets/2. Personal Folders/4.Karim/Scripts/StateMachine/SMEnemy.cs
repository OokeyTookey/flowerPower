using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMEnemy : MonoBehaviour
{
   
    [SerializeField]
    private Transform[] patrolspot;
    [SerializeField]
    private GameObject enemy;
    public GameObject target;
    public float distanceToTarget;
    public bool distracted;
    public bool patrolling;
    public float distractedTime;
    public float distractedTimeduration;
    public ThornsSkill thornsSkill;
    public bool knockback;
    public bool stunned;
    public float speed;
    public Rigidbody rb;
    public float stunDuration;
    public float knockbackCounter;
    public float knockbackTime;
    public float knockbackForce;
    public Vector3 direction;


    private StateMachine stateMachine = new StateMachine();
    private void Awake()
    {
        thornsSkill = FindObjectOfType<ThornsSkill>();
    }
    private void Start()
    {
        this.stateMachine.ChangeState(new Patrol(patrolspot, this.gameObject, 0, 5, 5, 5));


    }

    private void Update()
    {
        this.stateMachine.ExecuteState();
        distanceToTarget = Vector3.Distance(enemy.transform.position, target.transform.position);
        if (distanceToTarget < 10 && distractedTime > 0)
        {
            this.stateMachine.ExitState();
            
            this.stateMachine.ChangeState(new Distracted(this.gameObject, target.gameObject, 5, 5));
            distractedTime -= Time.deltaTime;
            
        }
        else if(distractedTime <= 0)
        {
           
            this.stateMachine.ExitState();
            this.stateMachine.ChangeState(new Patrol(patrolspot, this.gameObject, 0, 5, 5, 5));
            Debug.Log("Distracted ended");
            Destroy(target);
            
        }

        //if (stunned)
        //{
        //    this.stateMachine.ExitState();
        //    this.stateMachine.ChangeState(new Stunned(rb, speed, stunDuration));
            

        //}
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player" && !thornsSkill.thornsActive)
    //    {
    //        Debug.Log("Trigger Entered: Enemy in Trigger, thorns inactive");
    //        //DealDamage();
    //        knockback = false;
    //    }

    //}
    //private void OnTriggerStay(Collider other)
    //{

    //    if (other.tag == "Player" && !thornsSkill.thornsActive)
    //    {
    //        //DealDamage();
    //        Debug.Log("Enemy in Trigger, thorns inactive");
    //        knockback = false;
    //    }

    //    else if ((other.tag == "Player" && thornsSkill.thornsActive) && (!knockback))
    //    {
    //        Debug.Log("Enemy in Trigger, thorns active");
    //        knockback = true;
    //        stunned = true;
           

          
    //    }
    //}

}
