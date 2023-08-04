using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player를 움직이는 script
public class Player : MonoBehaviour
{
    public float mSpeed; //player 이동 속도
    public int mHealth; //player 체력
    public int mDepend; //player 방어도
    public int mMastery; //player 숙련도
    public int mPower; //player 힘
    public int mLuck; //player 운
    public int mLevel; //player 레벨
    public int mExp; //player 경험치
    public int mMoney; //player 돈

    private float mCurrTime;

    private Animator mAnim;
    private Animation mAnimation;
    [SerializeField]
    private SaveSaver mSave;
    [SerializeField]
    private DBManager mDBManager;
    [SerializeField]
    private GameObject mHitZone;

    GameObject nearobject;


    public float horizontal;
    public float vertical;
    bool swing;
    bool pickup;

    private void Awake()
    {
        mAnim = GetComponent<Animator>();
        mAnimation = GetComponent<Animation>();
        StartCoroutine(Load());
        StartCoroutine(Save());
    }

    private void FixedUpdate()
    {
        mCurrTime += Time.deltaTime;
        if (mCurrTime > 3)
        {
            StartCoroutine(Save());
            StartCoroutine(Load());
            mCurrTime = 0;
        }
    }

    private void Update()
    {
        getInput();
        movePlayer();
        pickupItem();
    }
    //by으니, getInput() - 230703
    //Input.Get~ 는 한곳에 모아두는게 좋을 것 같다고 판단.
    //한곳에 모아두는 메소드
    private void getInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        swing = Input.GetButtonDown("Jump");
        pickup = Input.GetButtonDown("Pickup");
    }

    //by으니, movePlayer() - 230622
    //Player 움직임 구현
    //키보드를 이용하여 움직임
    private void movePlayer()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(horizontal, vertical, 0).normalized * mSpeed * Time.deltaTime;
        transform.position = curPos + nextPos;

        Vector3 direction = new Vector3(horizontal, vertical);
        mAnim.SetBool("Right", false);
        mAnim.SetBool("Left", false);
        mAnim.SetBool("Down", false);
        mAnim.SetBool("Up", false);

        if (direction != Vector3.zero)
        {
            if (direction.y > 0)
            {
                mAnim.SetBool("Up", true);
                mHitZone.transform.position = new Vector3(transform.position.x + (-0.02f), transform.position.y + 0.75f, 0);
            }
            else if (direction.y < 0)
            {
                mAnim.SetBool("Down", true);
                mHitZone.transform.position = new Vector3(transform.position.x + (-0.02f), transform.position.y + (-0.75f), 0);
            }
            else if (direction.x > 0)
            {
                mAnim.SetBool("Right", true);
                mHitZone.transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + (-0.2f), 0);
            }
            else if (direction.x < 0)
            {
                mAnim.SetBool("Left", true);
                mHitZone.transform.position = new Vector3(transform.position.x + (-0.5f), transform.position.y + (-0.2f), 0);
            }
        }
        if (swing)
        {
            mAnim.SetTrigger("doMining");
        }
    }

    

    private void OnAttack(Transform enemy)
    {
        //damaged
    }

    private void diePlayer()
    {
        if (mHealth > 0)
        {
            //Damaged
        }
        else if(mHealth <= 0)
        {
            //die
        }
    }

    private void OnDamaged(Vector2 targetPos)
    {
        //맞는 애니메이션이랑 죽는 모션 없음
    }

    //by으니, pickupItem() - 230625
    private void pickupItem()
    {
        if (pickup && nearobject != null)
        {
            if (nearobject.tag == "Gem")
            {
                Destroy(nearobject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {

        }
    }

    //by재그, 드롭된 아이템 먹기
    //gem 먹기
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {
            nearobject = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {
            nearobject = null;
        }
    }

    //by재그, Save() && Load() 구현 - 230521
    //Player 스탯들을 저장&로드
    //5분마다 자동 저장
    IEnumerator Save()
    {
        mSave.Saver();
        yield return new WaitForSeconds(300f);
    }
    IEnumerator Load()
    {
        mSave.Loader();
        yield return new WaitForSeconds(300f);
    }
}
