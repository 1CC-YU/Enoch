using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���͸� �����ų�, ������ ĳ�� collider�� ���� ���� script
// ���Ⱑ ĳ���Ϳ� ���� ������ �Ǿ��ִ°��� �ƴϱ� ������ HitZone �̶�� object�� �߰��Ͽ� ����
public class HitZone : MonoBehaviour
{

    private Animator mAnim;
    private float mHorizontal;
    private float mVertical;

    void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    //by���, 2023-07-17
    //�������� ����� �ʿ���� �浹���̶� OnTrigger ���
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            mAnim.SetBool("Right", false);
            mAnim.SetBool("Left", false);
            mAnim.SetBool("Down", false);
            mAnim.SetBool("Up", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            miningStone(collision.transform);
        }

        if (collision.gameObject.tag == "Monster")
        {
            mHorizontal = Input.GetAxisRaw("Horizontal");
            mVertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(mHorizontal, mVertical);
            mAnim.SetBool("Right", false);
            mAnim.SetBool("Left", false);
            mAnim.SetBool("Down", false);
            mAnim.SetBool("Up", false);

            if (direction != Vector3.zero)
            {
                if (direction.y > 0)
                {
                    attackMonster(collision.transform);
                    mAnim.SetBool("Up", true);
                }
                else if (direction.y < 0)
                {
                    attackMonster(collision.transform);
                    mAnim.SetBool("Down", true);
                }
                else if (direction.x > 0)
                {
                    attackMonster(collision.transform);
                    mAnim.SetBool("Right", true);
                }
                else if (direction.x < 0)
                {
                    attackMonster(collision.transform);
                    mAnim.SetBool("Left", true);
                }
            }
        }
    }

    //by���,2023-07-17
    //�� ĳ��
    private void miningStone(Transform pStone)
    {
        Stone stone = pStone.GetComponent<Stone>();
        stone.OnMined();

    }

    //by���, 2023-07-17
    //���� ������
    private void attackMonster(Transform pMonster)
    {
        Monster monster = pMonster.GetComponent<Monster>();
        monster.onDamage();
    }
}
