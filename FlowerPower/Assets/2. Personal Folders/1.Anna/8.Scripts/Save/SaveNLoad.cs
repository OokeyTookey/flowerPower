using System.Collections;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveNLoad : MonoBehaviour
{
    const string folderName = "playerSaveSlots";
    const string fileExtension = ".Save";

    public PlayerStats playerStats;
    public AnnaPlayerMovement playerMovement;
    public PlayerManager playerManager;

    public PlayerDataSave playerData;

    string dataPath;
    private void Start()
    {
        playerData = new PlayerDataSave();
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
            playerData.StoreData(playerStats, playerMovement, playerManager); //Assigns varialbes & stats
            SaveData(playerData, dataPath); //Saves it to file.
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerDataSave loadedData = LoadData(dataPath);
            playerData.LoadData(loadedData, playerStats, playerMovement, playerManager);

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
        Debug.Log("Saved!");
    }

    PlayerDataSave LoadData(string dataPath)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(dataPath, FileMode.Open))
        {
            Debug.Log("Loaded Save!");
            return (PlayerDataSave)binaryFormatter.Deserialize(fileStream);
        }
    }
}