using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNode : MonoBehaviour
{
    public List<BTNode> childNode = new List<BTNode>();

    public enum Result { ready, running, success, failure };

    public virtual Result Execute(EnemyBehaviorTree EBT)
    {
        return Result.running;
    }
}