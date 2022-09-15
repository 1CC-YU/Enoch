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

    private Rigidbody2D mGemRigid;
    private Vector2 DropPow;

    [SerializeField]
    private SaveSaver save;
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
        save = FindObjectOfType<SaveSaver>();
        CheckState();
        Debug.Log(save.data.mastery);

        mGem.SetActive(false);
    }
    
    private void Update()
    {
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

            switch (state)
            {
                case MineralState.Stone:
                    mGem.SetActive(true);
                    mGem.transform.position = transform.position;
                    mGemRigid = mGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    break;
                case MineralState.Iron:
                    mGem.SetActive(true);
                    mGem.transform.position = transform.position;
                    mGemRigid = mGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    break;
                case MineralState.Copper:
                    mGem.SetActive(true);
                    mGem.transform.position = transform.position;
                    mGemRigid = mGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    break;
                case MineralState.Ruby:
                    mGem.SetActive(true);
                    mGem.transform.position = transform.position;
                    mGemRigid = mGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    break;
                case MineralState.Diamond:
                    mGem.SetActive(true);
                    mGem.transform.position = transform.position;
                    mGemRigid = mGem.GetComponent<Rigidbody2D>();
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
                if (save.data.mastery == 1 && save.data.mastery == 2)
                {
                    mMiningDug = mDBItem.itemList[0].miningDurablility;
                }
                else if(save.data.mastery == 3 && save.data.mastery == 4)
                {
                    mMiningDug = mDBItem.itemList[0].miningDurablility-1;
                }
                else if(save.data.mastery == 5&& save.data.mastery == 6)
                {
                    mMiningDug = mDBItem.itemList[0].miningDurablility-2;
                }
                else if (save.data.mastery == 7 && save.data.mastery == 8)
                {
                    mMiningDug = mDBItem.itemList[0].miningDurablility-3;
                }
                else if (save.data.mastery == 9 && save.data.mastery == 10)
                {
                    mMiningDug = mDBItem.itemList[0].miningDurablility-4;
                }
                
                break;
            case MineralState.Iron:
                if (save.data.mastery == 1 && save.data.mastery == 2)
                {
                    mMiningDug = mDBItem.itemList[1].miningDurablility;
                }
                else if (save.data.mastery == 3 && save.data.mastery == 4)
                {
                    mMiningDug = mDBItem.itemList[1].miningDurablility-1;
                }
                else if (save.data.mastery == 5 && save.data.mastery == 6)
                {
                    mMiningDug = mDBItem.itemList[1].miningDurablility-2;
                }
                else if (save.data.mastery == 7 && save.data.mastery == 8)
                {
                    mMiningDug = mDBItem.itemList[1].miningDurablility-3;
                }
                else if (save.data.mastery == 9 && save.data.mastery == 10)
                {
                    mMiningDug = mDBItem.itemList[1].miningDurablility-4;
                }
                break;
            case MineralState.Copper:
                if (save.data.mastery == 1 && save.data.mastery == 2)
                {
                    mMiningDug = mDBItem.itemList[2].miningDurablility;
                }
                else if (save.data.mastery == 3 && save.data.mastery == 4)
                {
                    mMiningDug = mDBItem.itemList[2].miningDurablility-1;
                }
                else if (save.data.mastery == 5 && save.data.mastery == 6)
                {
                    mMiningDug = mDBItem.itemList[2].miningDurablility-2;
                }
                else if (save.data.mastery == 7 && save.data.mastery == 8)
                {
                    mMiningDug = mDBItem.itemList[2].miningDurablility-3;
                }
                else if (save.data.mastery == 9 && save.data.mastery == 10)
                {
                    mMiningDug = mDBItem.itemList[2].miningDurablility-4;
                }
                break;
            case MineralState.Ruby:
                if(save.data.mastery == 5)
                {
                    mMiningDug = mDBItem.itemList[3].miningDurablility;
                }
                else if(save.data.mastery == 6&& save.data.mastery == 7)
                {
                    mMiningDug = mDBItem.itemList[3].miningDurablility-1;
                }
                else if(save.data.mastery == 8&& save.data.mastery == 9)
                {
                    mMiningDug = mDBItem.itemList[3].miningDurablility-2;
                }
                else if(save.data.mastery == 10)
                {
                    mMiningDug = mDBItem.itemList[3].miningDurablility-3;
                }
                else
                {
                    mMiningDug = 100000;
                }
                break;
            case MineralState.Diamond:
                if(save.data.mastery == 8)
                {
                    mMiningDug = mDBItem.itemList[4].miningDurablility;
                }
                else if(save.data.mastery == 9)
                {
                    mMiningDug = mDBItem.itemList[4].miningDurablility-1;
                }
                else if(save.data.mastery == 10)
                {
                    mMiningDug = mDBItem.itemList[4].miningDurablility-2;
                }
                else
                {
                    mMiningDug = 100000;
                }
                break;
        }
    }
}
