using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private float mMiningDug;
    private float mMining;

    [SerializeField]
    private DBManager mDBItem;
    private BoxCollider2D mBoxCollider;
    private Rigidbody2D mRigid;
    private SpriteRenderer mStoneImage;

    [SerializeField]
    private GameObject mStone;

    [SerializeField]
    private GameObject mStoneGem;
   



    [SerializeField]
    private ObjectManager objectManager;

    [SerializeField]
    private Sprite mDestroy_mid;
    [SerializeField]
    private Sprite mDestroy_end;

    public enum MineralState { Stone, Iron, Copper, Ruby, Diamond };
    public MineralState state;


    private void Start()
    {
        mMining = mMiningDug;
    }

    private void Awake()
    {
        mRigid = GetComponent<Rigidbody2D>();
        mBoxCollider = GetComponent<BoxCollider2D>();
        mStoneImage = GetComponent<SpriteRenderer>();
        CheckState();
    }

    

    public void OnMined()
    {
        mMining--;
        Debug.Log(mMining+"/"+mMiningDug);
        
        if((mMining/mMiningDug)<=0.7)
        {
            mStoneImage.sprite = mDestroy_mid;
        }
        if((mMining / mMiningDug) <= 0.2)
        {
            mStoneImage.sprite = mDestroy_end;
        }
        if ((mMining / mMiningDug) == 0)
        {
            mBoxCollider.enabled = false;
            Destroy(mStone);

            switch (state)
            {
                case MineralState.Stone:
                    GameObject mStoneGem = objectManager.MakeObj(Stone_gem.MineralState.Stone_gem);
                    mStoneGem.transform.position = transform.position;
                    break;
                case MineralState.Iron:
                    GameObject mIronGem = objectManager.MakeObj(Stone_gem.MineralState.Iron_gem);
                    mIronGem.transform.position = transform.position;
                    break;
                case MineralState.Copper:
                    GameObject mCopperGem = objectManager.MakeObj(Stone_gem.MineralState.Copper_gem);
                    mCopperGem.transform.position = transform.position;
                    break;
                case MineralState.Ruby:
                    GameObject mRubyGem = objectManager.MakeObj(Stone_gem.MineralState.Ruby_gem);
                    mRubyGem.transform.position = transform.position;
                    break;
                case MineralState.Diamond:
                    GameObject mDiamondGem = objectManager.MakeObj(Stone_gem.MineralState.Diamond_gem);
                    mDiamondGem.transform.position = transform.position;
                    break;
            }
        }
    }



    public void CheckState()
    {
        switch (state)
        {
            case MineralState.Stone:
                mMiningDug = mDBItem.itemList[0].miningDurablility;
                break;
            case MineralState.Iron:
                mMiningDug = mDBItem.itemList[1].miningDurablility;
                break;
            case MineralState.Copper:
                mMiningDug = mDBItem.itemList[2].miningDurablility;
                break;
            case MineralState.Ruby:
                mMiningDug = mDBItem.itemList[3].miningDurablility;
                break;
            case MineralState.Diamond:
                mMiningDug = mDBItem.itemList[4].miningDurablility;
                break;
        }
    }
}
