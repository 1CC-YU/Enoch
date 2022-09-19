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
    private Player player;
    private int mMastery;

    private bool isMasteryChange;
    private void Start()
    {

        mInitialPosition = transform.position;
        mMining = mMiningDug;
        mMastery = player.mMastery;

    }
    //mMiningDug의 값은 제대로 변하는데 mMining의 값이 0으로 변함.
    //숙련도 값이 변할때 mMiningDug의 값을 mMining이 받도록 해야함.
    //Start문에 mMining값을 주면 0이 됨.
    //숙련도 값이 변할때 CheckState()와 mMining = mMiningDug 를 사용해야할 것 같음.
    //CheckState()를 Awake()에 두게 되면, 숙련도 값이 변하지 않음. 
    private void Awake()
    {
        CheckState();


        mRigid = GetComponent<Rigidbody2D>();
        mBoxCollider = GetComponent<BoxCollider2D>();
        mStoneImage = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();
        isMasteryChange = false;
        mGem.SetActive(false);


    }
    private void Update()
    {
        if (mMastery != player.mMastery)
        {
            isMasteryChange = true;
            StartCoroutine(changeMastery());
        }
        isMasteryChange = false;
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
    IEnumerator changeMastery()
    {
        mMastery = player.mMastery;
        CheckState();
        mMining = mMiningDug;
        Debug.Log(mMastery);
        Debug.Log(mMining);
        yield return new WaitWhile(() => isMasteryChange == true);
    }
    // Luck도 똑같이 하면됨.

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
                switch (player.mMastery)
                {
                    case 1:
                    case 2:
                        mMiningDug = mDBItem.itemList[0].miningDurablility;
                        break;

                    case 3:
                    case 4:
                        mMiningDug = mDBItem.itemList[0].miningDurablility - 1;
                        break;

                    case 5:
                    case 6:
                        mMiningDug = mDBItem.itemList[0].miningDurablility - 2;
                        break;

                    case 7:
                    case 8:
                        mMiningDug = mDBItem.itemList[0].miningDurablility - 3;
                        break;

                    case 9:
                    case 10:
                        mMiningDug = mDBItem.itemList[0].miningDurablility - 4;
                        break;
                }


                break;
            case MineralState.Iron:
                switch (player.mMastery)
                {
                    case 1:
                    case 2:
                        mMiningDug = mDBItem.itemList[1].miningDurablility;
                        break;

                    case 3:
                    case 4:
                        mMiningDug = mDBItem.itemList[1].miningDurablility - 1;
                        break;

                    case 5:
                    case 6:
                        mMiningDug = mDBItem.itemList[1].miningDurablility - 2;
                        break;

                    case 7:
                    case 8:
                        mMiningDug = mDBItem.itemList[1].miningDurablility - 3;
                        break;

                    case 9:
                    case 10:
                        mMiningDug = mDBItem.itemList[1].miningDurablility - 4;
                        break;
                }


                break;
            case MineralState.Copper:
                switch (player.mMastery)
                {
                    case 1:
                    case 2:
                        mMiningDug = mDBItem.itemList[2].miningDurablility;
                        break;

                    case 3:
                    case 4:
                        mMiningDug = mDBItem.itemList[2].miningDurablility - 1;
                        break;

                    case 5:
                    case 6:
                        mMiningDug = mDBItem.itemList[2].miningDurablility - 2;
                        break;

                    case 7:
                    case 8:
                        mMiningDug = mDBItem.itemList[2].miningDurablility - 3;
                        break;

                    case 9:
                    case 10:
                        mMiningDug = mDBItem.itemList[2].miningDurablility - 4;
                        break;

                }


                break;
            case MineralState.Ruby:
                switch (player.mMastery)
                {
                    case 1:
                    case 2:
                        mMiningDug = 100012;
                        break;

                    case 3:
                    case 4:
                        mMiningDug = 100034;
                        break;

                    case 5:
                        mMiningDug = mDBItem.itemList[3].miningDurablility;
                        break;
                    case 6:
                    case 7:
                        mMiningDug = mDBItem.itemList[3].miningDurablility - 1;
                        break;

                    case 8:
                    case 9:
                        mMiningDug = mDBItem.itemList[3].miningDurablility - 3;
                        break;

                    case 10:
                        mMiningDug = mDBItem.itemList[3].miningDurablility - 4;
                        break;

                }


                break;
            case MineralState.Diamond:
                if (player.mMastery == 8)
                {
                    mMiningDug = mDBItem.itemList[4].miningDurablility;

                }
                else if (player.mMastery == 9)
                {
                    mMiningDug = mDBItem.itemList[4].miningDurablility - 1;
                }
                else if (player.mMastery == 10)
                {
                    mMiningDug = mDBItem.itemList[4].miningDurablility - 2;
                }
                else
                {
                    mMiningDug = 10456;
                }


                break;
        }
    }
}
