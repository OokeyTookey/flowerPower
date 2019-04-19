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
            EBT.rb.constraints = RigidbodyConstraints.None;
            EBT.speed = 5;
            EBT.stunnedCounter = EBT.stunnedDuration;
        }

        if (EBT.stunnedCounter == EBT.stunnedDuration)
        {
            Debug.Log("Stunned failed");
            return Result.failure;
        }
        else
        {
            Debug.Log("Stunned");
            EBT.speed = 0;
            EBT.rb.constraints = RigidbodyConstraints.FreezeRotation;
           
            
        }
        return Result.success;
    }
}
