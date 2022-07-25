using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveSaver : MonoBehaviour
{
    public PlayerData playerData;
    [ContextMenu("To Json Data")]
    void Saver()
    {
        string jsonData = JsonUtility.ToJson(playerData,true);
        string savePath = Path.Combine(Application.dataPath,"playerData.json");
        File.WriteAllText(savePath,jsonData);
    }

    [ContextMenu("From Json Data")]
    void Loader()
    {
        string savePath = Path.Combine(Application.dataPath,"playerData.json");
        string jsonData = File.ReadAllText(savePath);
        playerData = JsonUtility.FromJson<PlayerData>(jsonData);

    }
}


[System.Serializable]
public class PlayerData{
    public float mSpeed;
    public int health;
    public int depend;
    public int mastery;
    public int power;
    public int luck;
    public string[] items;
}   