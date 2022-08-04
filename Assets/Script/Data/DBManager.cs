using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBManager : MonoBehaviour
{
    static public DBManager instance;

    //¼öÄ¡ : 
    public string[] var_name;
    public float[] var;
    // itemµé
    public string[] switch_name;
    public bool[] switches;
    public List<Items> itemList;


    private void Awake()
    {
        itemList = new List<Items>();

        /*if (instance != null)
        {
            Destroy(this.gameObject);
        }

        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;

        }*/
    }

    private void Start()
    {
        itemList = new List<Items>();
    }
}
