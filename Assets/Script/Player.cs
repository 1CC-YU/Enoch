using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //���� =>[ü��, ��, ���õ�, ��, ��]
    // => [health, depend, mastery, power, luck]
    //ä�� => [��, ����, ö, ���, ���̾�]
    // => [stone, copper, steel, ruby, diamond]
    
    [SerializeField]
<<<<<<< Updated upstream
    public float mSpeed;
    public int mHealth;
    public int mDepend;
    public int mMastery;
    public int mPower;
    public int mLuck;
    public int mLevel;
=======
    private float mSpeed;
    private int mHealth;
    private int mDepend;
    private int mMastery;
    private int mPower;
    private int mLuck;
    private int mLevel;
    private int mExp;
>>>>>>> Stashed changes
    private Animator mAnim;

    Rigidbody2D rigid;
    CapsuleCollider2D capCollider;

    void Awake()
    {
        mAnim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        movePlayer();
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

    private void mining()
    {
<<<<<<< HEAD

        // ä�� ���� ���� �±�(tag)�� �ٰ�����, ����Ʈȭ(enum) ��ų ������

=======
        // ä�� ���� ���� �±�(tag)�� �ٰ�����, ����Ʈȭ(enum) ��ų ������
>>>>>>> bdd046e06cc1d47e1884252618625c0c1bcfd67e
    }

    private void attack(Transform monster)
    {
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        Monster monsterscript = monster.GetComponent<Monster>();
        mExp += 10;

    }
    private void damage(Vector2 targetPos)
    {
        mHealth -= 5;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            //Attack
            if(rigid.velocity.y<0 && transform.position.y > collision.transform.position.y)
            {
                attack(collision.transform);
               

            }
            else
            {
                damage(collision.transform.position);
            }
        }
    }
}
