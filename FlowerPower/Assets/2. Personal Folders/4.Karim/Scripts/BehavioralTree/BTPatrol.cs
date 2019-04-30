using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPatrol : BTNode

{
  
    

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.PlayerInRange() || EBT.SporeInRange())
        {
            Debug.Log("Patrol failed");
            EBT.SporeInRange(); 
            return Result.failure;
        }
        else
        {
            if (EBT.patrolSpot[EBT.randomPatrolSpot] != null)
            {
                EBT.speed = 2;
                EBT.transform.LookAt(EBT.patrolSpot[EBT.randomPatrolSpot].position);
                //Debug.Log("Patrolling, Looking at target spot");
            }

            EBT.transform.position = Vector3.MoveTowards(EBT.transform.position, EBT.patrolSpot[EBT.randomPatrolSpot].position, EBT.speed * Time.deltaTime);
            Debug.Log("Moving towards target spot");

            if (Vector3.Distance(EBT.transform.position, EBT.patrolSpot[EBT.randomPatrolSpot].position) <= 1)
            {
                if (EBT.waitTimeCounter <= 0)
                {
                    //Debug.Log("Wait time is finished.");
                    EBT.randomPatrolSpot = Random.Range(0,EBT.patrolSpot.Length);
                    EBT.waitTimeCounter = EBT.waitTimeDuration;
                }

                else
                {
                    //Debug.Log("Wait time refreshed");
                    EBT.waitTimeCounter -= Time.deltaTime;

                }
                return Result.running;
            }
        }
        Debug.Log("Patrol success");
        return Result.success;
    }
}
