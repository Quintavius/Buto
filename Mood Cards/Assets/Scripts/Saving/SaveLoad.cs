using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad {

    public static List<SaveData> saveDataFiles = new List<SaveData>();

    public static void Save()
    {
        if (SaveData.current.currentScene > SaveData.current.sceneProgress)
        {
            SaveData.current.sceneProgress = SaveData.current.currentScene;
        }
        saveDataFiles.Add(SaveData.current);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/memories.bug");
        bf.Serialize(file, saveDataFiles);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/memories.bug"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/memories.bug", FileMode.Open);
            saveDataFiles = (List<SaveData>)bf.Deserialize(file);
        }
    }
}
