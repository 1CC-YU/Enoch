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
    [SerializeField]
    private int mHp;

    private bool Chase;

    Collider2D mCollider;

    void Awake()
    {
        Chase = false;
        mRB = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();
        mCollider = GetComponent<Collider2D>();

        //gameObject의 활성화 여부로 코루틴 실행
        if (gameObject.activeSelf == false)
            return;

        StartCoroutine("movingMonster");
    }

    private IEnumerator movingMonster()
    {
        if (gameObject.activeSelf == false)
            StopAllCoroutines();

        float horizontal = Random.Range(StringHelper.MIN_VECTOR, StringHelper.MAX_VECTOR);
        float vertical = Random.Range(StringHelper.MIN_VECTOR, StringHelper.MAX_VECTOR);
        if (horizontal == 0 && vertical == 0)
        {
            mAnim.SetBool("IsMoving", false);
        }
        else
        {
            mAnim.SetBool("IsMoving", true);
        }
        mRB.velocity = new Vector2(horizontal, vertical);
        yield return new WaitForSeconds(mMonsterMovingTime);

        mAnim.SetBool("IsMoving", false);
        mRB.velocity = Vector2.zero;
        yield return new WaitForSeconds(mMonsterStopTime);

        StartCoroutine("movingMonster");
    }
    private IEnumerator chasingMonster()
    {
        if (Chase == false)
        {
            StartCoroutine("movingMonster");
            StopCoroutine("chasingMonster");
        }
        else
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

            StartCoroutine("chasingMonster");
            OffCollider();
            Invoke("OnCollider", mMonsterStopTime);
        }
    }

    public void onDamage()
    {
        if (mHp > 0)
        {
            mHp--;
            mAnim.SetTrigger("onHit");
            OffCollider();
            Invoke("OnCollider", 2f);
        }
        else if (mHp <= 0)
        {
            doDie();
        }
    }

    //by재은, 몬스터 죽는 모습 구현 - 230718
    
    private void doDie()
    {
        mAnim.SetTrigger("doDie");
        Invoke("DeActive", 2f);
    }
    private void DeActive()
    {
        Chase = false;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnCollider()
    {
        mCollider.enabled = true;
    }
    private void OffCollider()
    {
        mCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Plyaer랑 닿으면 Chasing한다음 5초간 Collider 끄기
        if (collision.gameObject.tag == "Player")
        {
            Chase = true;
            StopCoroutine("movingMonster");
            StartCoroutine("chasingMonster");

        }
    }




    //by재은, 2023-07-17
    //StartCoroutin("movingMonster") 대신에 Awake()로 순회함
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Chase = false;
            StopCoroutine("chasingMonster");
            Awake();
        }
    }
}
