using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float mSpeed;
    public int mHealth;
    public int mDepend;
    public int mMastery;
    public int mPower;
    public int mLuck;
    public int mLevel;
    public int mExp;

    private float mCurrTime;

    private Rigidbody2D mRB;
    private Animator mAnim;
    public SaveSaver mSave;
    public DBManager mDBManager;
    public GameObject mHitZone;
    private CapsuleCollider2D mCapCollider;

    [SerializeField]
    private GameObject mStoneGem;
    private void Awake()
    {
        mAnim = GetComponent<Animator>();
        mRB = gameObject.GetComponent<Rigidbody2D>();
        mCapCollider = gameObject.GetComponent<CapsuleCollider2D>();


        //Save만 해야하는지 Load & Save 해야하는지..
        StartCoroutine(Load());
        StartCoroutine(Save());
    }
    private void Update()
    {
        movePlayer();
    }

    private void FixedUpdate()
    {
        mCurrTime += Time.deltaTime;
        if (mCurrTime > 300)
        {
            StartCoroutine(Save());
            StartCoroutine(Load());
            mCurrTime = 0;
        }
    }
    private void movePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool swing = Input.GetButtonDown("Jump");

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


    private void OnAttack()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            //공격 당할때 구현
            Debug.Log("악");
        }
       if(collision.gameObject.tag == "Gem")
        {

        }
    }
    





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
