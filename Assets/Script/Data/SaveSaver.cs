using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveSaver : MonoBehaviour
{
    public Player thePlayer;
    public PlayerData data;
    [ContextMenu("To Json Data")]
    public void Saver()
    {
        thePlayer = FindObjectOfType<Player>();
        data.mSpeed = thePlayer.mSpeed;
        data.health = thePlayer.mHealth;
        data.depend = thePlayer.mDepend;
        data.mastery = thePlayer.mMastery;
        data.power = thePlayer.mPower;
        data.luck = thePlayer.mLuck;
        data.level = thePlayer.mLevel;
        data.exp = thePlayer.mExp;

        string jsonData = JsonUtility.ToJson(data,true);
        string savePath = Path.Combine(Application.dataPath,"playerData.json");
        File.WriteAllText(savePath,jsonData);
    }

    [ContextMenu("From Json Data")]
    public void Loader()
    {
        string savePath = Path.Combine(Application.dataPath,"playerData.json");
        string jsonData = File.ReadAllText(savePath);
        data = JsonUtility.FromJson<PlayerData>(jsonData);

        thePlayer = FindObjectOfType<Player>();
        thePlayer.mSpeed = data.mSpeed ;
        thePlayer.mHealth = data.health ;
        thePlayer.mDepend = data.depend ;
        thePlayer.mMastery = data.mastery ;
        thePlayer.mPower = data.power;
        thePlayer.mLuck = data.luck ;
        thePlayer.mLevel = data.level;
        thePlayer.mExp = data.exp;

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
    public int level;
    public int exp;
    public List<int> items;
    public List<int> itemsCount;
}