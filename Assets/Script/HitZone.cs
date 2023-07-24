using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터를 때리거나, 광석을 캐는 collider를 위해 만든 script
// 무기가 캐릭터와 따로 디자인 되어있는것이 아니기 때문에 HitZone 이라는 object를 추가하여 구현
public class HitZone : MonoBehaviour
{

    private Animator mAnim;
    private float mHorizontal;
    private float mVertical;

    void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    //by재그, 2023-07-17
    //물리적인 계산이 필요없는 충돌뿐이라 OnTrigger 사용
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

    //by재그,2023-07-17
    //돌 캐기
    private void miningStone(Transform pStone)
    {
        Stone stone = pStone.GetComponent<Stone>();
        stone.OnMined();

    }

    //by재그, 2023-07-17
    //몬스터 때리기
    private void attackMonster(Transform pMonster)
    {
        Monster monster = pMonster.GetComponent<Monster>();
        monster.onDamage();
    }
}
