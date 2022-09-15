using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private float mMiningDug;
    private float mMining;

    [SerializeField]
    private DBManager mDBItem;
    private Rigidbody2D mRigid;
    private BoxCollider2D mBoxCollider;
    private SpriteRenderer mStoneImage;

    [SerializeField]
    private GameObject mStone;

    [SerializeField]
    private GameObject mGem;

    [SerializeField]
    private Sprite mDestroy_mid;
    [SerializeField]
    private Sprite mDestroy_end;

    public enum MineralState { Stone, Iron, Copper, Ruby, Diamond };
    public MineralState state;

    private float mShakeTime = 2f;
    private float mShakeAmount = 0.05f;
    private Vector3 mInitialPosition;

    Rigidbody2D mGemRigid;
    Vector2 DropPow;

    Player player;

    private void Start()
    {
        mInitialPosition = transform.position;
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
        Shake();
        Debug.Log(mMining + "/" + mMiningDug);

        int updown = Random.Range(1, 3);
        int leftright = Random.Range(-2, 3);


        if ((mMining / mMiningDug) <= 0.7)
        {
            mStoneImage.sprite = mDestroy_mid;
        }
        if ((mMining / mMiningDug) <= 0.2)
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

                    GameObject mStoneGem = Instantiate(mGem);
                    mStoneGem.transform.position = transform.position;
                    mGemRigid = mStoneGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;


                    break;
                case MineralState.Iron:
                    GameObject mIronGem = Instantiate(mGem);
                    mIronGem.transform.position = transform.position;
                    mGemRigid = mIronGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    break;
                case MineralState.Copper:
                    GameObject mCopperGem = Instantiate(mGem);
                    mCopperGem.transform.position = transform.position;
                    mGemRigid = mCopperGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    break;
                case MineralState.Ruby:
                    GameObject mRubyGem = Instantiate(mGem);
                    mRubyGem.transform.position = transform.position;
                    mGemRigid = mRubyGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    break;
                case MineralState.Diamond:
                    GameObject mDiamondGem = Instantiate(mGem);
                    mDiamondGem.transform.position = transform.position;
                    mGemRigid = mDiamondGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    break;
            }
        }
    }


    private void Shake()
    {
        if (mShakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * mShakeAmount + mInitialPosition;
            mShakeTime -= Time.deltaTime;
        }
        else if (mShakeTime <= 0)
        {
            transform.position = mInitialPosition;
            mShakeTime = 2.0f;
        }
    }
    private void CheckState()
    {
        switch (state)
        {
            case MineralState.Stone:
                if (player.mMastery >= 1 && player.mMastery > 2)
                {
                    mMiningDug = mDBItem.itemList[0].miningDurablility;
                }
                else if (player.mMastery >= 3 && player.mMastery < 5)
                {
                    mMiningDug = mDBItem.itemList[0].miningDurablility - 1;
                }
                else if (player.mMastery >= 5 && player.mMastery < 7)
                {
                    mMiningDug = mDBItem.itemList[0].miningDurablility - 2;
                }
                else if (player.mMastery >= 7 && player.mMastery < 9)
                {
                    mMiningDug = mDBItem.itemList[0].miningDurablility - 3;
                }
                else if (player.mMastery >= 9 && player.mMastery <= 10)
                {
                    mMiningDug = mDBItem.itemList[0].miningDurablility - 4;
                }
                break;
            case MineralState.Iron:
                if (player.mMastery >= 1 && player.mMastery < 2)
                {
                    mMiningDug = mDBItem.itemList[1].miningDurablility;
                }
                else if (player.mMastery >= 3 && player.mMastery < 5)
                {
                    mMiningDug = mDBItem.itemList[1].miningDurablility - 1;

                }
                else if (player.mMastery >= 5 && player.mMastery < 7)
                {
                    mMiningDug = mDBItem.itemList[1].miningDurablility - 2;
                }
                else if (player.mMastery >= 7 && player.mMastery < 9)
                {
                    mMiningDug = mDBItem.itemList[1].miningDurablility - 3;
                }
                else if (player.mMastery >= 9 && player.mMastery <= 10)
                {
                    mMiningDug = mDBItem.itemList[1].miningDurablility - 4;
                }
                break;
            case MineralState.Copper:
                if (player.mMastery >= 1 && player.mMastery < 2)
                {
                    mMiningDug = mDBItem.itemList[2].miningDurablility;
                }
                else if (player.mMastery >= 3 && player.mMastery < 5)
                {
                    mMiningDug = mDBItem.itemList[2].miningDurablility - 1;

                }
                else if (player.mMastery >= 5 && player.mMastery < 7)
                {
                    mMiningDug = mDBItem.itemList[2].miningDurablility - 2;
                }
                else if (player.mMastery >= 7 && player.mMastery < 9)
                {
                    mMiningDug = mDBItem.itemList[2].miningDurablility - 3;
                }
                else if (player.mMastery >= 9 && player.mMastery <= 10)
                {
                    mMiningDug = mDBItem.itemList[2].miningDurablility - 4;
                }
                break;
            case MineralState.Ruby:
                if (player.mMastery >= 5 && player.mMastery < 6)
                {
                    mMiningDug = mDBItem.itemList[3].miningDurablility;
                }
                else if (player.mMastery >= 6 && player.mMastery < 8)
                {
                    mMiningDug = mDBItem.itemList[3].miningDurablility - 1;
                }
                else if (player.mMastery >= 8 && player.mMastery < 10)
                {
                    mMiningDug = mDBItem.itemList[3].miningDurablility - 2;
                }
                else if (player.mMastery >= 10 && player.mMastery < 11)
                {
                    mMiningDug = mDBItem.itemList[3].miningDurablility - 3;
                }
                else
                {
                    mMining = 10000;
                }
                break;
            case MineralState.Diamond:
                if (player.mMastery >= 8 && player.mMastery < 9)
                {
                    mMiningDug = mDBItem.itemList[4].miningDurablility;
                }
                else if (player.mMastery >= 9 && player.mMastery < 10)
                {
                    mMiningDug = mDBItem.itemList[4].miningDurablility - 1;
                }
                else if (player.mMastery >= 10 && player.mMastery < 11)
                {
                    mMiningDug = mDBItem.itemList[4].miningDurablility - 2;

                }
                else
                {
                    mMining = 10000;
                }
                break;
        }
    }
}
