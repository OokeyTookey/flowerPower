using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerDataSave
{
    public int currentHealth;
    public float[] playerPosition;
    public float[] playerRotation;

    public bool sunFlowerSkillUnlocked;
    public bool sporeSkillUnlocked;
    public bool thornsSkillUnlocked;

    //Will need to save the different puzzle elements. 

    public PlayerDataSave(PlayerStats playerStats, AnnaPlayerMovement PlayerMovement, PlayerManager playerManager) //Constructor - We need to date data from the following scripts.
    {
        currentHealth = playerStats.currentHealth; //Sets the players current health.

        playerPosition = new float[3]; //Stores player position in an array of floats
        playerRotation = new float[3]; //Stores player rotation in an array of floats

        playerPosition[0] = PlayerMovement.transform.position.x;
        playerPosition[1] = PlayerMovement.transform.position.y;
        playerPosition[2] = PlayerMovement.transform.position.z;

        playerRotation[0] = PlayerMovement.transform.rotation.x;
        playerRotation[1] = PlayerMovement.transform.rotation.y;
        playerRotation[2] = PlayerMovement.transform.rotation.z;
    }
}
