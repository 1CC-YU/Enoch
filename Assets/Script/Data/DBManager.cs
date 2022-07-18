using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    static public DBManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }

        else 
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;

        }
    }

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] switches;
    public List<Items> itemList = new List<Items>();


    void Start()
    {
        
    }
}
