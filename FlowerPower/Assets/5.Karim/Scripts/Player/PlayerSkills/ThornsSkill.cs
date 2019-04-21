using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsSkill : MonoBehaviour
{
    public float thornsActiveTime;
    public bool thornsActive;
    public float thornsActiveDuration;

    void Start()
    {
        thornsActive = false;
    }

    void Update()
    {
        RunFunction();
    }

    public void ThornsActive()
    {
        if (thornsActive)
        {
            thornsActiveTime -= Time.deltaTime;
        }

        if (thornsActive && thornsActiveTime <= 0)
        {
            thornsActive = false;
            thornsActiveTime = thornsActiveDuration;
        }
    }

    public void RunFunction()
    {
<<<<<<< HEAD:FlowerPower/Assets/Karim/Scripts/Player/PlayerSkills/ThornsSkill.cs
        if (Input.GetKey(KeyCode.Q))
        {
            thornsActive = true;
        }
        ThornsActive();
    }

    //public void RunFunction()
    //{
        
    //        thornsActive = true;
        
    //    ThornsActive();
    //}
}





=======
        ThornsActive();
    }
}
>>>>>>> 7b7854018d2c96d8615443cb8771614bdab10024:FlowerPower/Assets/5.Karim/Scripts/Player/PlayerSkills/ThornsSkill.cs
