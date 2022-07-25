using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveSaver : MonoBehaviour
{
    private Player thePlayer;
    public Playerdata data;
    [ContextMenu("To Json Data")]
    void Saver()
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
        string savePath = Path.Combine(Application.dataPath,"data.json");
        File.WriteAllText(savePath,jsonData);
    }

    [ContextMenu("From Json Data")]
    void Loader()
    {
        string savePath = Path.Combine(Application.dataPath,"data.json");
        string jsonData = File.ReadAllText(savePath);
        data = JsonUtility.FromJson<Playerdata>(jsonData);

    }
}


[System.Serializable]
public class Playerdata{
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