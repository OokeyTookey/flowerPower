using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : BTNode
{

    public override Result Execute(EnemyBehaviorTree EBT)
    {
        for (int i = 0; i < childNode.Count; i++)
        {
            if (childNode[i].Execute(EBT) == Result.running)
            {
                childNode[i].Execute(EBT);
                return Result.running;
            }

            else if (childNode[i].Execute(EBT) == Result.failure)
            {
                return Result.failure;
            }
        }

        return Result.success;
    }
}
