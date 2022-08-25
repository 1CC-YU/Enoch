using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{

    void Start()
    {
        
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
            attackMonster();
        }
    }
    private void miningStone(Transform pStone)
    {
        Stone stone = pStone.GetComponent<Stone>();
        stone.OnMined();
    }

    private void attackMonster()
    {

    }
}
