using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTDead : BTNode
{
    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if(EBT.enemyHealth > 0)
        {
            
            return Result.failure;
            
        }
        else
        {
            Debug.Log("Enemy Dead");
            EBT.speed = 0;
            EBT.puzzle4.enemiesKilled++;
            EBT.GetComponent<EnemyBehaviorTree>().enabled = false;

        }
        return Result.success;
    }
}
