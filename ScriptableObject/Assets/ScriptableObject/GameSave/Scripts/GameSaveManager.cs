using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager instance;

    public KeyBindings keybindings;

    public ygoCard ygocard;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/game_save");
    }

    //Check %AppData%
    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/game_save/card_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/card_data");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/game_save/card_data/card_save");
        var json = JsonUtility.ToJson(ygocard);
        bf.Serialize(file, json);
        file.Close();
    }

    public void LoadGame()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/game_save/card_data"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_save/card_data");
        }
        BinaryFormatter bf = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "/game_save/card_data/card_save"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_save/card_data/card_save", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), ygocard);
            file.Close();
        }
    }
}
