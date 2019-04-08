using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorTree : MonoBehaviour
{

    public AnnaPlayerMovement player;
    public SporesSkill sporeSkill;
    public ThornsSkill thornsSkill;

    public Transform[] patrolSpot;
    public Rigidbody rb;

    public Vector3 direction;

    public BTNode root;
    public BTNode healthCheck;
    
    public int randomPatrolSpot;
    public int enemyHealth;

    public float playerInRange;
    public float sporeInRange;
    public float enemyOnPlayer;

    public float speed;
    public float waitTimeDuration;
    public float waitTimeCounter;

    public float knockbackForce;
    public float knockbackDuration;
    public float knockbackCounter;

    public float stunnedDuration;
    public float stunnedCounter;

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

        if (knockedBack)
        {
            knockbackCounter -= Time.deltaTime;
        }
        if(knockbackCounter <= 0)
        {
            knockedBack = false;
            knockbackCounter = knockbackDuration;
        }
        if (stunnedCounter <= 0)
        {
            stunned = false;
            rb.constraints = RigidbodyConstraints.None;
            speed = 5;
            stunnedCounter = stunnedDuration;
        }
        if (stunned)
        {
            stunnedCounter -= Time.deltaTime;
        }
    }
   
    void AddChildrenNodes()
    {
        root = new Selector();
        BTNode actions = new Selector();

        root.childNode.Add(actions);
        //root.childrenNodes.Add(Idle()); To be added later

        actions.childNode.Add(new BTPatrol());
        actions.childNode.Add(new BTDistracted());
        actions.childNode.Add(new BTChase()); 
        actions.childNode.Add(new BTKnockback());      
        actions.childNode.Add(new BTStunned());
        actions.childNode.Add(new BTDead());
    }

    public bool PlayerInRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= playerInRange)
        {
            return true;
        }
        return false;
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
        if (Vector3.Distance(transform.position, player.transform.position) <= enemyOnPlayer)
        {
            return true;
        }
        return false;
    }
}