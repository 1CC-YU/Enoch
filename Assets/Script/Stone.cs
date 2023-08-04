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
    private GameObject mGem_1;
    [SerializeField]
    private GameObject mGem_2;
    [SerializeField]
    private GameObject mGem_3;
    [SerializeField]
    private GameObject mGem_4;


    [SerializeField]
    private Sprite mDestroy_mid;
    [SerializeField]
    private Sprite mDestroy_end;

    public enum MineralState { Stone, Iron, Copper, Ruby, Diamond };
    public MineralState state;

    private float mShakeTime = 2f;
    private float mShakeAmount = 0.05f;
    private float DestroyTime = 30.0f;

    private Vector3 mInitialPosition;

    private Rigidbody2D mGemRigid;
    private Rigidbody2D mGem_1Rigid;
    private Rigidbody2D mGem_2Rigid;
    private Rigidbody2D mGem_3Rigid;
    private Rigidbody2D mGem_4Rigid;

    private Vector2 DropPow;
    private Vector2 DropPow1;
    private Vector2 DropPow2;
    private Vector2 DropPow3;
    private Vector2 DropPow4;


    [SerializeField]
    private Player player;
    private int mMastery;
    private int mLuck;

    private bool isMasteryChange;
    private bool isLuckChange;
    private void Start()
    {
        CheckState();

        mInitialPosition = transform.position;
        mMining = mMiningDug;
        mMastery = player.mMastery;
        mLuck = player.mLuck;
    }
    //mMiningDug�� ���� ����� ���ϴµ� mMining�� ���� 0���� ����.
    //���õ� ���� ���Ҷ� mMiningDug�� ���� mMining�� �޵��� �ؾ���.
    //Start���� mMining���� �ָ� 0�� ��.
    //���õ� ���� ���Ҷ� CheckState()�� mMining = mMiningDug �� ����ؾ��� �� ����.
    //CheckState()�� Awake()�� �ΰ� �Ǹ�, ���õ� ���� ������ ����. 
    private void Awake()
    {
        CheckState();

        mRigid = GetComponent<Rigidbody2D>();
        mBoxCollider = GetComponent<BoxCollider2D>();
        mStoneImage = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();

        isMasteryChange = false;
        isLuckChange = false;

        mGem.SetActive(false);
        mGem_1.SetActive(false);
        mGem_2.SetActive(false);
        mGem_3.SetActive(false);
        mGem_4.SetActive(false);
    }
    private void Update()
    {
        if (mMastery != player.mMastery)
        {
            isMasteryChange = true;
            StartCoroutine(changeMastery());
        }
        isMasteryChange = false;

        if(mLuck != player.mLuck)
        {
            isLuckChange = true;
            StartCoroutine(changeLuck());
        }
        isLuckChange = false;
    }


    //by����, OnMined() - 230621
    //ä�� ����
    //Player�� Luck������ ���� ������ ��� ���� ����
    //pooling�� �ƴϱ� ������ destroy�� SetActive(true),SetActive(false)�� ����
    //DestroyTime = 60 : 60�� �Ŀ� Stone Object �ı�
    //����ȭ �ʿ���. (DB ���� ������ ���� �Ұ��Ͽ� �̷��� ����.)
    public void OnMined()
    {

        mMining--;
        Shake();
        Debug.Log(mMining + "/" + mMiningDug);

        int updown = Random.Range(1, 3);
        int leftright = Random.Range(-2, 3);
        int updown1 = Random.Range(1, 3);
        int leftright1 = Random.Range(-2, 3);
        int updown2 = Random.Range(1, 3);
        int leftright2 = Random.Range(-2, 3);
        int updown3 = Random.Range(1, 3);
        int leftright3 = Random.Range(-2, 3);
        int updown4 = Random.Range(1, 3);
        int leftright4 = Random.Range(-2, 3);

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
                    switch (player.mLuck)
                    {
                        case 1:
                        case 2:
                            mGem.SetActive(true);
                            Destroy(mGem_1);
                            Destroy(mGem_2);
                            Destroy(mGem_3);
                            Destroy(mGem_4);

                            break;
                        case 3:
                        case 4:
                            mGem.SetActive(true);
                            mGem_1.SetActive(true);
                            Destroy(mGem_2);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                        case 5:
                        case 6:
                            mGem.SetActive(true);
                            mGem_1.SetActive(true);
                            mGem_2.SetActive(true);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                        case 7:
                        case 8:
                            mGem.SetActive(true);
                            mGem_1.SetActive(true);
                            mGem_2.SetActive(true);
                            mGem_3.SetActive(true);
                            Destroy(mGem_4);
                            break;
                        case 9:
                        case 10:
                            mGem.SetActive(true);
                            mGem_1.SetActive(true);
                            mGem_2.SetActive(true);
                            mGem_3.SetActive(true);
                            mGem_4.SetActive(true);
                            break;
                    }

                    mGem.transform.position = transform.position;
                    mGemRigid = mGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    mGem_1.transform.position = transform.position;
                    mGem_1Rigid = mGem_1.GetComponent<Rigidbody2D>();
                    DropPow1 = new Vector2(leftright1, updown1);
                    mGem_1Rigid.AddForce(DropPow1, ForceMode2D.Impulse);
                    mGem_1Rigid.drag = 1.8f;
                    mGem_2.transform.position = transform.position;
                    mGem_2Rigid = mGem_2.GetComponent<Rigidbody2D>();
                    DropPow2 = new Vector2(leftright2, updown2);
                    mGem_2Rigid.AddForce(DropPow2, ForceMode2D.Impulse);
                    mGem_2Rigid.drag = 1.8f;
                    mGem_3.transform.position = transform.position;
                    mGem_3Rigid = mGem_3.GetComponent<Rigidbody2D>();
                    DropPow3 = new Vector2(leftright3, updown3);
                    mGem_3Rigid.AddForce(DropPow3, ForceMode2D.Impulse);
                    mGem_3Rigid.drag = 1.8f;
                    mGem_4.transform.position = transform.position;
                    mGem_4Rigid = mGem_4.GetComponent<Rigidbody2D>();
                    DropPow4 = new Vector2(leftright4, updown4);
                    mGem_4Rigid.AddForce(DropPow4, ForceMode2D.Impulse);
                    mGem_4Rigid.drag = 1.8f;
                    break;
                case MineralState.Iron:
                    switch (player.mLuck)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            mGem.SetActive(true);
                            Destroy(mGem_1);
                            Destroy(mGem_2);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                        case 5:
                        case 6:
                            mGem.SetActive(true);
                            mGem_1.SetActive(true);
                            Destroy(mGem_2);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                        case 7:
                        case 8:
                            mGem.SetActive(true);
                            mGem_1.SetActive(true);
                            mGem_2.SetActive(true);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                        case 9:
                        case 10:
                            mGem.SetActive(true);
                            mGem_1.SetActive(true);
                            mGem_2.SetActive(true);
                            mGem_3.SetActive(true);
                            Destroy(mGem_4);
                            break;
                    }
                    mGem.transform.position = transform.position;
                    mGemRigid = mGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    mGem_1.transform.position = transform.position;
                    mGem_1Rigid = mGem_1.GetComponent<Rigidbody2D>();
                    DropPow1 = new Vector2(leftright1, updown1);
                    mGem_1Rigid.AddForce(DropPow1, ForceMode2D.Impulse);
                    mGem_1Rigid.drag = 1.8f;
                    mGem_2.transform.position = transform.position;
                    mGem_2Rigid = mGem_2.GetComponent<Rigidbody2D>();
                    DropPow2 = new Vector2(leftright2, updown2);
                    mGem_2Rigid.AddForce(DropPow2, ForceMode2D.Impulse);
                    mGem_2Rigid.drag = 1.8f;
                    mGem_3.transform.position = transform.position;
                    mGem_3Rigid = mGem_3.GetComponent<Rigidbody2D>();
                    DropPow3 = new Vector2(leftright3, updown3);
                    mGem_3Rigid.AddForce(DropPow3, ForceMode2D.Impulse);
                    mGem_3Rigid.drag = 1.8f;

                    break;
                case MineralState.Copper:
                    switch (player.mLuck)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            mGem.SetActive(true);
                            Destroy(mGem_1);
                            Destroy(mGem_2);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                        case 7:
                        case 8:
                            mGem.SetActive(true);
                            mGem_1.SetActive(true);
                            Destroy(mGem_2);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                        case 9:
                        case 10:
                            mGem.SetActive(true);
                            mGem_1.SetActive(true);
                            mGem_2.SetActive(true);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                    }
                    mGem.transform.position = transform.position;
                    mGemRigid = mGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    mGem_1.transform.position = transform.position;
                    mGem_1Rigid = mGem_1.GetComponent<Rigidbody2D>();
                    DropPow1 = new Vector2(leftright1, updown1);
                    mGem_1Rigid.AddForce(DropPow1, ForceMode2D.Impulse);
                    mGem_1Rigid.drag = 1.8f;
                    mGem_2.transform.position = transform.position;
                    mGem_2Rigid = mGem_2.GetComponent<Rigidbody2D>();
                    DropPow2 = new Vector2(leftright2, updown2);
                    mGem_2Rigid.AddForce(DropPow2, ForceMode2D.Impulse);
                    mGem_2Rigid.drag = 1.8f;
                    
                    break;
                case MineralState.Ruby:
                    switch (player.mLuck)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            mGem.SetActive(true);
                            Destroy(mGem_1);
                            Destroy(mGem_2);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                        case 9:
                        case 10:
                            mGem.SetActive(true);
                            mGem_1.SetActive(true);
                            Destroy(mGem_2);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                    }
                    mGem.transform.position = transform.position;
                    mGemRigid = mGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    mGem_1.transform.position = transform.position;
                    mGem_1Rigid = mGem_1.GetComponent<Rigidbody2D>();
                    DropPow1 = new Vector2(leftright1, updown1);
                    mGem_1Rigid.AddForce(DropPow1, ForceMode2D.Impulse);
                    mGem_1Rigid.drag = 1.8f;
                    break;
                case MineralState.Diamond:
                    switch (player.mLuck)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            mGem.SetActive(true);
                            Destroy(mGem_1);
                            Destroy(mGem_2);
                            Destroy(mGem_3);
                            Destroy(mGem_4);
                            break;
                    }
                    mGem.transform.position = transform.position;
                    mGemRigid = mGem.GetComponent<Rigidbody2D>();
                    DropPow = new Vector2(leftright, updown);
                    mGemRigid.AddForce(DropPow, ForceMode2D.Impulse);
                    mGemRigid.drag = 1.8f;
                    
                    break;


            }
            Destroy(gameObject, DestroyTime);
        }
    }

    //by ����, ���õ�&�� ���� ���� �� CheckState() ���� - 230621
    //Player�� ������ ����ɶ� �ٷιٷ� CheckState()�� �ݿ����� �ʾ�, 
    //������ �����ϴ� �޼ҵ� ����
    IEnumerator changeMastery()
    {
        mMastery = player.mMastery;
        CheckState();
        mMining = mMiningDug;
        yield return new WaitWhile(() => isMasteryChange == true);
    }
    IEnumerator changeLuck()
    {
        mLuck = player.mLuck;
        CheckState();
        yield return new WaitWhile(() => isLuckChange == true);
    }

    //by����, Shake()
    //���� �¾�����, ��鸲 ���� - 220902
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
                switch (player.mMastery)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        mMiningDug = 10456;
                        break;
                    case 8:
                        mMiningDug = mDBItem.itemList[4].miningDurablility;
                        break;
                    case 9:
                        mMiningDug = mDBItem.itemList[4].miningDurablility - 1;
                        break;
                    case 10:
                        mMiningDug = mDBItem.itemList[4].miningDurablility - 2;
                        break;
                }
                break;
        }
    }
}
