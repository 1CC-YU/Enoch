using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{

    private Animator mAnim;

    void Start()
    {
        mAnim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            miningStone(collision.transform);
        }

        if(collision.gameObject.tag == "Monster")
        {
            attackMonster(collision.transform);
        }
    }
    private void miningStone(Transform pStone)
    {
        Stone stone = pStone.GetComponent<Stone>();
        stone.OnMined();
    }

    private void attackMonster(Transform pMonster)
    {
        Monster monster = pMonster.GetComponent<Monster>();
        monster.onHit();
        
    }
}
