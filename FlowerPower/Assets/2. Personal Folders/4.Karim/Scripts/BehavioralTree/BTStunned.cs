using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTStunned : BTNode
{
    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.stunned)
        {
            EBT.stunnedCounter -= Time.deltaTime;
        }
        if (EBT.stunnedCounter <= 0)
        {
            EBT.stunned = false;
            EBT.knockbackCounter = EBT.knockbackDuration;
        }
        if (!EBT.stunned)
        {
            Debug.Log("Stunned failed");
            return Result.failure;
        }
        //else
        //{

            
        //    EBT.rb.constraints = RigidbodyConstraints.FreezeRotation;

        //}
        return Result.success;
    }
}