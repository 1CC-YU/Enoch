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
    private float mSpeed;
    private int mHealth;
    private int mDepend;
    private int mMastery;
    private int mPower;
    private int mLuck;
    private int mLevel;
    private Animator mAnim;

    void Awake()
    {
        mAnim = GetComponent<Animator>();
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
        // ä�� ���� ���� �±�(tag)�� �ٰ�����, ����Ʈȭ(enum) ��ų ������
    }

    private void attack()
    {

    }
}
