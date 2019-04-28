using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTDistracted : BTNode
{
    public override Result Execute(EnemyBehaviorTree EBT)
    {
        if (!EBT.SporeInRange())
        {
            Debug.Log("Distracted Failed");
            return Result.failure;
        }

        else if (EBT.SporeInRange())
        {



            EBT.transform.LookAt(EBT.sporeSkill.intSpore.transform.position);
            //Debug.Log("Distracted, looking at spore");

            EBT.transform.position = Vector3.MoveTowards(EBT.transform.position, EBT.sporeSkill.intSpore.transform.position, EBT.speed * Time.deltaTime);
            EBT.speed = 2;

            Debug.Log("Distracted, moving towards spore");
            if (Vector3.Distance(EBT.sporeSkill.intSpore.transform.position, EBT.transform.position) <= 1)
            {


                EBT.speed = 0;
            }
            else if ( EBT.sporeSkill.intSpore == null)
            {
                Debug.Log("Distracted duration ended");
                EBT.speed = 2;
            }

            return Result.running;


        }

        Debug.Log("Distracted Success");
        return Result.running;
    }
}

