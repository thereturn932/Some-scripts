using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavenLoad : MonoBehaviour {

    string jsonString;
    JsonData saveFile, itemData;
    List<Item> data = new List<Item>();
    public void Save()
    {
        data = LeaderItemData.leaderData;
        saveFile = JsonMapper.ToJson(data);
        File.WriteAllText(Application.dataPath + "/Saves/save.json", saveFile.ToString());
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Saves/save.mk"))
        {
            jsonString = File.ReadAllText(Application.dataPath + "/Saves/save.json");
            Debug.Log(jsonString);
            itemData = JsonMapper.ToObject(jsonString);
            ImportSaveData();
            LeaderItemData.leaderData = data;
            SceneManager.LoadScene("Night");
        }
    }

    void ImportSaveData()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            data.Add(new Item((int)itemData[i]["ID"], itemData[i]["Title"].ToString(), (int)itemData[i]["numberOfItems"]));
        }
    }
}

[Serializable]
class ItemData
{
    public List<Item> savedItemData;

}