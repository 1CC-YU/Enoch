using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_gem : MonoBehaviour
{
    public enum MineralState { Stone_gem, Iron_gem, Copper_gem, Ruby_gem, Diamond_gem };
    public MineralState state;

    [SerializeField]
    private DBManager mDBItem;

    [HideInInspector]
    public int mPrice;


    private void Awake()
    {
        CheckState();
    }

    private void CheckState()
    {
        switch (state)
        {
            case MineralState.Stone_gem:
                mPrice = mDBItem.gemList[0].gemPrice;
                break;
            case MineralState.Iron_gem:
                mPrice = mDBItem.gemList[1].gemPrice;
                break;
            case MineralState.Copper_gem:
                mPrice = mDBItem.gemList[2].gemPrice;
                break;
            case MineralState.Ruby_gem:
                mPrice = mDBItem.gemList[3].gemPrice;
                break;
            case MineralState.Diamond_gem:
                mPrice = mDBItem.gemList[4].gemPrice;
                break;

        }
    }


}
