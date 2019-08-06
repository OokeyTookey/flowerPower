using System.Collections;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveNLoad : MonoBehaviour
{
    const string folderName = "SaveFiles";
    string currentSaveSlot;

    const string fileExtension = ".Save";

    public PlayerStats playerStats;
    public AnnaPlayerMovement playerMovement;
    public PlayerManager playerManager;

    public TransitionController transitionController;

    public PlayerDataSave playerData;

    string dataPath;
    private void Start()
    {
        playerData = new PlayerDataSave();
        currentSaveSlot = "/emptySave";
        dataPath = Application.persistentDataPath + currentSaveSlot + fileExtension; //Being updated constantly, perhaps have a sepreate function which is called and saves this??
    }

    private void Update()
    {
        Debug.Log(dataPath);
        if (Input.GetKeyDown(KeyCode.K))
        {
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
        }
    }

    void SaveData(PlayerDataSave playerData, string dataPath)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = new FileStream (dataPath, FileMode.OpenOrCreate))
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

    public void SaveFile1()
    {
        currentSaveSlot = "/save1";
        SceneManager.LoadScene("Level1");
        Debug.Log(dataPath);
       
    }

    public void SaveFile2()
    {
        currentSaveSlot = "/save2";
        UpdatePath();
        SceneManager.LoadScene("Level1");
    }

    public void SaveFile3()
    {
        currentSaveSlot = "/save3";
        UpdatePath();
        SceneManager.LoadScene("Level1");
    }

    public void UpdatePath()
    {
        dataPath = Application.persistentDataPath + currentSaveSlot + fileExtension; //Being updated constantly, perhaps have a sepreate function which is called and saves this??
        LoadData(dataPath);
    }
}