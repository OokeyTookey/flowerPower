using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTKnockback : BTNode
{
   

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (EBT.knockedBack)
        {
            EBT.knockbackCounter -= Time.deltaTime;
        }
        if (EBT.knockbackCounter <= 0)
        {
            EBT.knockedBack = false;
            EBT.knockbackCounter = EBT.knockbackDuration;
        }

        

        else if (EBT.thornsSkill.thornsActive && EBT.EnemyOnPlayer())
        {
            EBT.knockedBack = true;
            EBT.stunned = true;
          
            Debug.Log("Knockback Node Running");
            EBT.rb.velocity = Vector3.zero;
            EBT.direction = EBT.transform.position - EBT.player.transform.position;
            EBT.direction.y = 0;
            EBT.direction = EBT.direction.normalized + Vector3.up;
            EBT.rb.AddForce(EBT.direction.normalized * EBT.knockbackForce, ForceMode.Impulse);
           
           
        Debug.Log("Knockback success");
        return Result.success;
        }
        Debug.Log("Knockback failed");
        return Result.failure;
    }
}
