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
    private float mMiningTime;
    bool mlAttack;
    bool zDown;
    bool isMining;

    private Rigidbody2D mRB;
    private Animator mAnim;
    public SaveSaver mSave;
    public DBManager mDBManager;
    private void Awake()
    {
        mAnim = GetComponent<Animator>();
        mRB = gameObject.GetComponent<Rigidbody2D>();
        //Save만 해야하는지 Load & Save 해야하는지..
        StartCoroutine(Load());
        StartCoroutine(Save());
    }
    private void Update()
    {
        movePlayer();
        miningPlayer();
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
            }
            else if (direction.y < 0)
            {
                mAnim.SetBool("Down", true);
            }
            else if (direction.x > 0)
            {
                mAnim.SetBool("Right", true);
            }
            else if (direction.x < 0)
            {
                mAnim.SetBool("Left", true);
            }

        }
        
    }
    private void miningPlayer()
    {
        if (Input.GetButtonDown("Jump"))
        {
            mAnim.SetTrigger("doMining");
        }
    }

    private void mining(Transform stones)
    {
        
        Stone stone = stones.GetComponent<Stone>();
        stone.OnMined();
    }


    private void OnAttack()
    {

    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {

        }
        if(collision.gameObject.tag == "Stone")
        {
            Debug.Log("마이닝");
            mining(collision.transform);
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
