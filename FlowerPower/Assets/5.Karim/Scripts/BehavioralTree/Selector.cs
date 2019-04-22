using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : BTNode
{

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        for (int i = 0; i < childNode.Count; i++)
        {

            Result nodeResult = childNode[i].Execute(EBT);
            if (nodeResult == Result.success)
            {
                //currentResult = Result.success;
                return Result.success;
            }


            else if (nodeResult == Result.running)
            {
                //currentResult = Result.running;
                return Result.running;
            }
        }

        //currentResult = Result.failure;
        return Result.failure;

    }

}
