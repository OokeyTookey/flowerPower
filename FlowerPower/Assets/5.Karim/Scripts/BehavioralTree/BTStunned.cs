using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTStunned : BTNode
{
    

    public override Result Execute(EnemyBehaviorTree EBT)
    {
<<<<<<< HEAD:FlowerPower/Assets/Karim/Scripts/BehavioralTree/BTStunned.cs
        if (EBT.stunned)
        {
            EBT.stunnedCounter -= Time.deltaTime;
        }
        if (EBT.stunnedCounter <= 0)
        {
            EBT.stunned = false;
            EBT.rb.constraints = RigidbodyConstraints.None;
            EBT.speed = 5;
            EBT.stunnedCounter = EBT.stunnedDuration;
        }

        if (EBT.stunnedCounter == EBT.stunnedDuration)
=======
        if (!EBT.stunned)
>>>>>>> 7b7854018d2c96d8615443cb8771614bdab10024:FlowerPower/Assets/5.Karim/Scripts/BehavioralTree/BTStunned.cs
        {
            Debug.Log("Stunned failed");
            return Result.failure;
        }
        else
        {
    
            EBT.speed = 0;
            EBT.rb.constraints = RigidbodyConstraints.FreezeRotation;
           
            
        }
        return Result.success;
    }
}
