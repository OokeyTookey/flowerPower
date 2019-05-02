using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNode 
{
    public List<BTNode> childNode = new List<BTNode>();

    public enum Result { running, success, failure };

    public virtual Result Execute(EnemyBehaviorTree EBT)
    {
        return Result.running;
    }
}