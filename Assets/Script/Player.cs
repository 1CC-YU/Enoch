using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float mSpeed;
    public int mHealth;
    public int mDepend;
    public int mMastery;
    public int mPower;
    public int mLuck;
    public int mLevel;
    public int mExp;

    private float mcurrTime;

    private Animator mAnim;
    public SaveSaver mSave;
    public DBManager mDBManager;

    private void Start()
    {
        //Save만 해야하는지 Load & Save 해야하는지..
        StartCoroutine(Load());
        StartCoroutine(Save());
    }
    private void Awake()
    {
        mAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        movePlayer();

        mcurrTime += Time.deltaTime;
        if (mcurrTime > 300)
        {
            StartCoroutine(Save());
            StartCoroutine(Load());
            mcurrTime = 0;
        }

    }

    private void movePlayer()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0).normalized * mSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;

        Vector3 direction = new Vector3(h, v);
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


    private void mining()
    {
        
        /*if (mDBManager.itemList != null)
        {


            Debug.Log(mDBManager.itemList[4].itemID);

        }*/
    }


    private void attack()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("악!");
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
