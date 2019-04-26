using System.Collections;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveNLoad : MonoBehaviour
{
    //save slots
    const string folderName = "playerSaveSlots";
    const string fileExtension = ".Save";

    public PlayerStats playerStats;
    public AnnaPlayerMovement playerMovement;
    public PlayerManager playerManager;

    public PlayerDataSave playerData;

     //public string whichSave;
    string dataPath;
    private void Start()
    {
        PlayerDataSave playerData = new PlayerDataSave(playerStats, playerMovement, playerManager);
    }

private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            dataPath = Path.Combine(Application.persistentDataPath, folderName); //Combines the two strings into one to create a file path
            if (!Directory.Exists(folderName)) //Checks if the player save file folder exists.
            {
                Directory.CreateDirectory(folderName); //Creates a directory with the folder name.
            }

            SaveData(playerData, dataPath);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadData(dataPath);

            /*string[] filePaths = GetAllSaveFiles();
            playerData = LoadData(filePaths[whichSave]);*/
        }
    }

    /*static string[] GetAllSaveFiles() //Check all save files.
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);

        return Directory.GetFiles(folderPath, fileExtension); //Accesses the designated folder path with the .Save file extension.
    }*/


     void SaveData(PlayerDataSave playerData, string dataPath)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(dataPath, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, playerData);
            //using automatically closes filestream when it reaches the end of the method. Otherwise do: fileStream.Close();
        }

        Debug.Log("saved... theoretically");
    }

     PlayerDataSave LoadData(string dataPath)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(dataPath, FileMode.Open))
        {
        Debug.Log("loaded... theoretically");
            return (PlayerDataSave)binaryFormatter.Deserialize(fileStream);
        }


    }
}
