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

    public void StoreData(PlayerStats playerStats, AnnaPlayerMovement playerMovement, PlayerManager playerManager)
    {
        currentHealth = playerStats.currentHealth; //Sets the players current health.

        playerPosition = new float[3]; //Stores player position in an array of floats
        playerRotation = new float[4]; //Quaternion has 4 elements. 


        playerPosition[0] = playerMovement.transform.position.x;
        playerPosition[1] = playerMovement.transform.position.y;
        playerPosition[2] = playerMovement.transform.position.z;

        playerRotation[0] = playerMovement.transform.rotation.x;
        playerRotation[1] = playerMovement.transform.rotation.y;
        playerRotation[2] = playerMovement.transform.rotation.z;
        playerRotation[3] = playerMovement.transform.rotation.w;

        sunFlowerSkillUnlocked = playerManager.SeedUNLOCKED;
        thornsSkillUnlocked = playerManager.thornsUNLOCKED;
        sporeSkillUnlocked = playerManager.sporesUNLOCKED;
    }

    public void LoadData(PlayerDataSave playerData, PlayerStats playerStats, AnnaPlayerMovement playerMovement, PlayerManager playerManager)
    {
        playerStats.currentHealth = playerData.currentHealth;

        playerMovement.transform.position = new Vector3(playerData.playerPosition[0], 
                                                        playerData.playerPosition[1], 
                                                        playerData.playerPosition[2]);

        playerMovement.transform.rotation = new Quaternion(playerData.playerRotation[0], playerData.playerRotation[1], 
                                                            playerData.playerRotation[2], playerData.playerRotation[3]);

        playerManager.SeedUNLOCKED = playerData.sunFlowerSkillUnlocked;
        playerManager.thornsUNLOCKED = playerData.thornsSkillUnlocked;
        playerManager.sporesUNLOCKED = playerData.sporeSkillUnlocked;
    }
}