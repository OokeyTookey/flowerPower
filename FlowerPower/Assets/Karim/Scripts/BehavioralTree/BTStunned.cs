using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTStunned : BTNode
{
    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.stunnedCounter == 2 || EBT.enemyHealth < 0)
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
