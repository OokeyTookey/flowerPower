using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTChase : BTNode
{

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (!EBT.PlayerInRange() || (EBT.EnemyOnPlayer() && EBT.thornsSkill.thornsActive))// Checking if close
        {
            Debug.Log("Chase Failed");
            //Debug.Log("Enemy on Player" +EBT.EnemyOnPlayer());
            return Result.failure;
        }
        else if (EBT.PlayerInRange() && !EBT.knockedBack)
        {
            //Debug.Log("Player in Range");
            //Debug.Log("Enemy on Player" + EBT.EnemyOnPlayer());

            EBT.transform.LookAt(EBT.player.transform);
            Vector3 enemyPosition = (EBT.player.gameObject.transform.position - EBT.transform.position).normalized;
            Vector3 Distance = new Vector3(enemyPosition.x, 0, enemyPosition.z);
            Debug.Log("Chasing Player");
            EBT.transform.position += Distance * EBT.speed * Time.deltaTime;

            return Result.running;
        }
        Debug.Log("Chase Succeed");
        return Result.success;

    }
}