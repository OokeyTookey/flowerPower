using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTStunned : BTNode
{
    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (!EBT.stunned)
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
