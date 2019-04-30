using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorTree : MonoBehaviour
{

    public AnnaPlayerMovement player;
    public SporesSkill sporeSkill;
    public ThornsSkill thornsSkill;

    public Transform[] patrolSpot;
    public int randomPatrolSpot;
    public Rigidbody rb;

    public Vector3 direction;

    public BTNode root;
    public BTNode healthCheck;
    
  
    public int enemyHealth;

    public float playerInRange;
    public float sporeInRange;
    public float enemyOnPlayer;
    public float knockbackForce;
    public float knockbackDuration;
    public float knockbackCounter;
    public float speed;
    public float stunnedDuration;
    public float stunnedCounter;
    public float waitTimeDuration;
    public float waitTimeCounter;

    public bool knockedBack;
    public bool stunned;





    void Start()
    {
        player = FindObjectOfType<AnnaPlayerMovement>();
        sporeSkill = FindObjectOfType<SporesSkill>();
        thornsSkill = FindObjectOfType<ThornsSkill>();
        rb = GetComponent<Rigidbody>();
        AddChildrenNodes();
        stunnedCounter = stunnedDuration;
        waitTimeCounter = waitTimeDuration;
        knockbackCounter = knockbackDuration;
    }

    void Update()
    {
        root.Execute(this);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            enemyHealth--;
        }

       
       
        
    }
   
    void AddChildrenNodes()
    {
        root = new Selector();
        BTNode actions = new Selector();

        root.childNode.Add(actions);
        //root.childrenNodes.Add(Idle()); To be added later

        actions.childNode.Add(new BTDead());
        actions.childNode.Add(new BTKnockback());      
        actions.childNode.Add(new BTStunned());
        actions.childNode.Add(new BTDistracted());
        actions.childNode.Add(new BTChase()); 
        actions.childNode.Add(new BTPatrol());
    }

    public bool PlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= playerInRange ;
    }

    public bool SporeInRange()
    {
        if (sporeSkill.intSpore != null)
        {
            if (Vector3.Distance(transform.position, sporeSkill.intSpore.transform.position) <= sporeInRange)
            {
                return true;
            }
        }
        return false;
    }

    public bool EnemyOnPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= enemyOnPlayer;
       
    }
}