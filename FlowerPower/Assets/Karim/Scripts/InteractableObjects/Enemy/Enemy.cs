using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public int speed;
    public int randomPatrolSpot;

    public bool stunned;
    public bool distracted;
    public bool knockback;
    public bool patrol;

    public float waitTime;
    public float startWaitTime;

    public float knockbackForce;
    public float knockbackTime;
    public float knockbackCounter;

    public float distractedTimer;
    public float stunDuration;

    public float distances;

    public Vector3 direction;

    public Rigidbody rb;

    public PlayerStats playerStats;
    public AnnaPlayerMovement player;
    public ThornsSkill thornSkill;
    public SporesSkill sporeSkill;

    public Collider knockCollider;


    public Transform[] patrolspot;





    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        thornSkill = FindObjectOfType<ThornsSkill>();
        sporeSkill = FindObjectOfType<SporesSkill>();
        player = FindObjectOfType<AnnaPlayerMovement>();


        rb = GetComponent<Rigidbody>();
        randomPatrolSpot = Random.Range(0, patrolspot.Length);

        stunned = false;
        knockback = false;
        distracted = false;
        patrol = true;
    }

    // Update is called once per frame
    void Update()
    {
       
                if (knockbackCounter <= 0)
                {
                    knockback = false;

                }
                if(!distracted && !stunned && !knockback)
                {
                    Patrol();
                }
                else
                {
                    knockbackCounter -= Time.deltaTime;

                }
           
        //GetKnockedBack();

        GetStunned();
        GetDistracted();


    }

    public void DealDamage()
    {
        playerStats.currentHealth -= 1;
    }



    public void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolspot[randomPatrolSpot].position, speed * Time.deltaTime);
        

        if (Vector3.Distance(transform.position, patrolspot[randomPatrolSpot].position) < 3f)
        {
            if (waitTime <= 0)
            {
                randomPatrolSpot = Random.Range(0, patrolspot.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    public void GetDistracted()
    {

        if (sporeSkill.intSpore != null)
        {
            distances = Vector3.Distance(transform.position, sporeSkill.intSpore.transform.position);
            //Debug.Log(distances);
            if (distances < 10 && distractedTimer > 0)
            {
                distracted = true;
                patrol = false;
                
                transform.position = Vector3.MoveTowards(transform.position, sporeSkill.intSpore.transform.position, speed * Time.deltaTime);
                distractedTimer -= Time.deltaTime;
            }
        }
        else
        {
            distracted = false;
            patrol = true;
        }
    }

    public void GetStunned()
    {
        if (stunned && !knockback)
        {
            speed = 0;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            stunDuration -= Time.deltaTime;
        }



        if (stunDuration <= 0)
        {
            stunned = false;
            rb.constraints = RigidbodyConstraints.None;
            speed = 5;
            stunDuration = 2;
        }
    }

    public void GetKnockedBack()
    {
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        knockbackCounter = knockbackTime;
        direction = transform.position - player.transform.position;
        direction.y = 0;
        direction = direction.normalized + Vector3.up;
        rb.AddForce(direction.normalized * knockbackForce, ForceMode.Impulse);


    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player" && !thornSkill.thornsActive)
        {
            DealDamage();
            knockback = false;
        }
       
    }
    
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && !thornSkill.thornsActive)
        {
            DealDamage();
            knockback = false;
        }

        else if ((other.tag == "Player" && thornSkill.thornsActive) && (!knockback))
        {
            
            knockback = true;
            GetKnockedBack();

            stunned = true;
            GetStunned();
        }
    }

    

}