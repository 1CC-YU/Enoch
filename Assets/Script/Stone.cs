using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private int mMining;


    public DBManager mDBItem;
    Rigidbody2D mRigid;

    public enum MineralState {Stone, Iron, Copper, Ruby, Diamond};
    public MineralState state;


    private void Awake()
    {
        mRigid = GetComponent<Rigidbody2D>();

        CheckState();
    }

    private void FixedUpdate()
    {
        
    }

    public void OnMined()
    {
        
        mMining--;
        if(mMining == 0)
        {
            gameObject.SetActive(false);
        }
        

    }

    public void CheckState()
    {
        switch (state)
        {
            case MineralState.Stone:
                mMining = mDBItem.itemList[0].miningDurablility;
                break;
        }

    }
}
