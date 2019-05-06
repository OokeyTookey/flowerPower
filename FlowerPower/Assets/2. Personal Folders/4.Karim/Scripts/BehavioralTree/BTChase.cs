using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTChase : BTNode
{

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        // STOP CHASING --- Check if the enemy finished chasing the player 
        if (EBT.PlayerInRange() && EBT.EnemyOnPlayer())
        {
            Debug.Log("Chase Succeed");
            return Result.success;
        }
        // CHASE --- Check if the enemy is in range to start chasing the player
        if (EBT.PlayerInRange())
        {
            Debug.Log("Player in Range");
            Debug.Log("Enemy on Player" + EBT.EnemyOnPlayer());
            EBT.transform.LookAt(EBT.player.transform);
            Vector3 enemyPosition = (EBT.player.gameObject.transform.position - EBT.transform.position).normalized;
            Vector3 Distance = new Vector3(enemyPosition.x, 0, enemyPosition.z);
            Debug.Log("Chasing Player");
            EBT.transform.position += Distance * EBT.speed * Time.deltaTime;

            return Result.running;
        }
        return Result.failure;
    }
}
