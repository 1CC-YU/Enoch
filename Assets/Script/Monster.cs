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


    void Awake()
    {
        Chase = false;
        mRB = GetComponent<Rigidbody2D>();
        mAnim = GetComponent<Animator>();

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
        }
    }

    public void onDamage()
    {
        if (mHp > 0)
        {
            mHp--;
            mAnim.SetTrigger("onHit");
        }
        else if (mHp <= 0)
        {
            doDie();
        }
    }

    private void doDie()
    {
        mAnim.SetTrigger("doDie");
        Invoke("DeActive", 1);
    }
    private void DeActive()
    {
        Chase = false;
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Chase = true;
            StopCoroutine("movingMonster");
            StartCoroutine("chasingMonster");
        }
    }

    //by재그, 2023-07-17
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
