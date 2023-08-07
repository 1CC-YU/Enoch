using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// player�� �����̴� script
public class Player : MonoBehaviour
{
    public float mSpeed; //player �̵� �ӵ�
    public int mHealth; //player ü��
    public int mDepend; //player ��
    public int mMastery; //player ���õ�
    public int mPower; //player ��
    public int mLuck; //player ��
    public int mLevel; //player ����
    public int mExp; //player ����ġ
    public int mMoney; //player ��

    private float mCurrTime;

    private Animator mAnim;
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
    bool isDead = false;

    private void Awake()
    {
        mAnim = GetComponent<Animator>();
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
        if (isDead) return;

        getInput();
        movePlayer();
        pickupItem();
    }
    //by����, getInput() - 230703
    //Input.Get~ �� �Ѱ��� ��Ƶδ°� ���� �� ���ٰ� �Ǵ�.
    //�Ѱ��� ��Ƶδ� �޼ҵ�
    private void getInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        swing = Input.GetButtonDown("Jump");
        pickup = Input.GetButtonDown("Pickup");
    }

    //by����, movePlayer() - 230622
    //Player ������ ����
    //Ű���带 �̿��Ͽ� ������
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
                mHitZone.transform.position = new Vector3(transform.position.x + (-0.02f), transform.position.y + 1f, 0);
            }
            else if (direction.y < 0)
            {
                mAnim.SetBool("Down", true);
                mHitZone.transform.position = new Vector3(transform.position.x + (-0.02f), transform.position.y + (-1.5f), 0);
            }
            else if (direction.x > 0)
            {
                mAnim.SetBool("Right", true);
                mHitZone.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y + (-0.2f), 0);
            }
            else if (direction.x < 0)
            {
                mAnim.SetBool("Left", true);
                mHitZone.transform.position = new Vector3(transform.position.x + (-1f), transform.position.y + (-0.2f), 0);
            }
        }
        if (swing)
        {
            mAnim.SetTrigger("doMining");
        }
    }


    //by����, OnDamaged() - 230807
    //Monster�� ����� �� �±�. (Collider �ϳ� �� �ؾ��ҵ�(���� ������Ʈ))
    //������ �����鼭 ����...
    //Monster�� �浹���� ��, hp--

    public void OnDamaged()
    {
        if (mHealth > 0)
        {
            //Damaged
            mHealth--;
            mAnim.SetTrigger("OnDamaged");
        }
        else if(mHealth <= 0)
        {
            //die
            doDie();
        }
    }
    

    private void doDie()
    {
        isDead = true;
        mAnim.SetTrigger("DoDie");
    }

    //by����, pickupItem() - 230625
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
        if(collision.gameObject.tag == "Monster")
        {
            OnDamaged();
        }
    }
    //by����, ��ӵ� ������ �Ա� - 230520
    //gem �Ա�
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

    //by����, Save() && Load() ���� - 230521
    //Player ���ȵ��� ����&�ε�
    //5�и��� �ڵ� ����
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
