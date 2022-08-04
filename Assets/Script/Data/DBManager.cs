using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    static public DBManager instance;

    //수치 : 
    public string[] var_name;
    public float[] var;
    // item들
    public string[] switch_name;
    public bool[] switches;
    public List<Items> itemList;


    private void Awake()
    {

        if (instance != null)
        {
            Destroy(this.gameObject);
        }

        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;

        }
    }

    private void Start()
    {
        itemList.Insert(0, new Items(){ itemID = 1, itemName = "Stone", itemDescription = "돌", miningDurablility = 10 });
    }

    private void Update()
    {
        
    }
}
