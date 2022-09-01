using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float mMonsterMovingTime;
    [SerializeField]
    private float mMonsterStopTime;
    [SerializeField]
    private Transform mPlayerPos;
    private Rigidbody2D mRB;
    private Animator mAnim;
    private IEnumerator mMovingCoroutine;
    private IEnumerator mChasingCoroutine;

    [SerializeField]
    private int mHp;

    void Awake()
    {
        mRB = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();
        mMovingCoroutine = movingMonster();
        mChasingCoroutine = chasingMonster();
        StartCoroutine(mMovingCoroutine);
    }
    void FixedUpdate()
    {
        
    }
    private IEnumerator movingMonster()
    {
        float horizontal = Random.Range(StringHelper.MIN_VECTOR, StringHelper.MAX_VECTOR);
        float vertical = Random.Range(StringHelper.MIN_VECTOR, StringHelper.MAX_VECTOR);
        if(horizontal == 0 && vertical ==0)
        {
            mAnim.SetBool("IsMoving", false);
        }
        else
        {
            mAnim.SetBool("IsMoving",true);
        }
        mRB.velocity = new Vector2(horizontal, vertical);
        yield return new WaitForSeconds(mMonsterMovingTime);
        mAnim.SetBool("IsMoving", false);
        mRB.velocity = Vector2.zero;
        yield return new WaitForSeconds(mMonsterStopTime);
        StartCoroutine(movingMonster());
    }
    private IEnumerator chasingMonster()
    {
        float monsterPosX = transform.position.x;
        float monsterPosY = transform.position.y;
        float playerPosX = mPlayerPos.transform.position.x;
        float playerPosY = mPlayerPos.transform.position.y;
        mAnim.SetBool("IsMoving", true);
        mRB.velocity = new Vector2(playerPosX - monsterPosX, playerPosY - monsterPosY);
        yield return new WaitForSeconds(mMonsterMovingTime);
        mAnim.SetBool("IsMoving", false);
        mRB.velocity = Vector2.zero;
        yield return new WaitForSeconds(mMonsterStopTime);
        StartCoroutine(chasingMonster());
    }

    public void onHit()
    {
        if (mHp > 0)
        {
            mHp--;
            mAnim.SetTrigger("onHit");
        }
        else if(mHp <= 0)
        {
            mAnim.SetTrigger("doDie");
            gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StopCoroutine(mMovingCoroutine);
            StartCoroutine(mChasingCoroutine);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StopCoroutine(mChasingCoroutine);
            StartCoroutine(mMovingCoroutine);
        }
    }
}
