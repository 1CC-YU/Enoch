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
    public int mMoney;

    private float mCurrTime;

    private Animator mAnim;
    [SerializeField]
    private SaveSaver mSave;
    [SerializeField]
    private DBManager mDBManager;
    [SerializeField]
    private GameObject mHitZone;

    GameObject nearobjet;
    GameObject gemobject;

    public float horizontal;
    public float vertical;
    bool swing;
    bool pickup;

    private void Awake()
    {
        mAnim = GetComponent<Animator>();

        //Save만 해야하는지 Load & Save 해야하는지..
        StartCoroutine(Load());
        StartCoroutine(Save());
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
    
    private void Update()
    {
        getInput();
        movePlayer();
        pickupItem();
    }
    private void getInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        swing = Input.GetButtonDown("Jump");
        pickup = Input.GetButtonDown("Pickup");
    }
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
    private void pickupItem()
    {
        if (pickup && nearobjet != null)
        {
            if (nearobjet.tag == "Gem")
            {
                Stone_gem gem = gemobject.GetComponent<Stone_gem>();
                Debug.Log(gem.mPrice);
                Destroy(nearobjet);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
           
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {

            nearobjet = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Gem")
        {

            nearobjet = null;
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
