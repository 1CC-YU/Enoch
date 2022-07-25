using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float mMonsterIdleTime;
    [SerializeField]
    private float mMonsterMoveTime;
    [SerializeField]
    private Transform mPlayerPos;
    private Rigidbody2D mRB;
    private Animator mMonsterMoveAnimator;
    private IEnumerator mMoveCoroutine, mChaseCoroutine;
    private void Awake()
    {
        mMonsterMoveAnimator = gameObject.GetComponentInChildren<Animator>();
        mRB = GetComponent<Rigidbody2D>();
        mMoveCoroutine = moveMonster();
        mChaseCoroutine = chasePlayer();
        StartCoroutine(mMoveCoroutine);
    }
    private IEnumerator moveMonster()
    {
        Debug.Log("moving");
        float horizontal = Random.Range(StringHelper.MONTER_MIN_VECTOR, StringHelper.MONTER_MAX_VECTOR);
        float vertical = Random.Range(StringHelper.MONTER_MIN_VECTOR, StringHelper.MONTER_MAX_VECTOR);
        if(horizontal == StringHelper.MONTER_STOP && vertical == StringHelper.MONTER_STOP)
        {
            mMonsterMoveAnimator.SetBool("isMoving", false);
        }
        else
        {
            mMonsterMoveAnimator.SetBool("isMoving", true);
        }
        mRB.velocity = new Vector2(horizontal, vertical).normalized;
        yield return new WaitForSeconds(mMonsterMoveTime);
        mMonsterMoveAnimator.SetBool("isMoving", false);
        mRB.velocity = Vector2.zero;
        yield return new WaitForSeconds(mMonsterIdleTime);
       
        StartCoroutine(moveMonster());
    }
    private IEnumerator chasePlayer()
    {
        Debug.Log("chasing");
        float monsterPosX = transform.position.x;
        float monsterPosY = transform.position.y;
        float playerPosX = transform.position.x;
        float playerPosY = transform.position.y;
        mMonsterMoveAnimator.SetBool("isMoving", true);
        if (transform.position.x <= mPlayerPos.position.x && transform.position.y <= mPlayerPos.position.y)//1사분면
        {
            mRB.velocity = new Vector2(playerPosX-monsterPosX, playerPosY-monsterPosY).normalized;
        }
        else if(transform.position.x > mPlayerPos.position.x && transform.position.y < mPlayerPos.position.y)//2사분면
        {
            mRB.velocity = new Vector2(monsterPosX- playerPosX, playerPosY- monsterPosY).normalized;
        }
        else if(transform.position.x < mPlayerPos.position.x && transform.position.y > mPlayerPos.position.y)//3사분면
        {
            mRB.velocity = new Vector2(playerPosX- monsterPosX, monsterPosY-playerPosY).normalized;
        }
        else if (transform.position.x >= mPlayerPos.position.x && transform.position.y >= mPlayerPos.position.y)//4사분면
        {
            mRB.velocity = new Vector2(monsterPosX- playerPosX, monsterPosY- playerPosY).normalized;
        }
        yield return new WaitForSeconds(mMonsterMoveTime);
        mMonsterMoveAnimator.SetBool("isMoving", false);
        mRB.velocity = Vector2.zero;
        yield return new WaitForSeconds(mMonsterIdleTime);
        StartCoroutine(chasePlayer());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("chasing Area");
            StopCoroutine(mMoveCoroutine);
            StartCoroutine(chasePlayer());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Exit");
            StopCoroutine(mChaseCoroutine);
            StartCoroutine(moveMonster());
        }
    }
}

