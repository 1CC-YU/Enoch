using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    static public DBManager instance;

    //��ġ : 
    public string[] var_name;
    public float[] var;
    // item��
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
        itemList.Insert(0, new Items(){ itemID = 1, itemName = "Stone", itemDescription = "��", miningDurablility = 10 });
    }

    private void Update()
    {
        
    }
}
