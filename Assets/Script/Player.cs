using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //스탯 =>[체력, 방어도, 숙련도, 힘, 운]
    // => [health, depend, mastery, power, luck]
    //채광 => [돌, 구리, 철, 루비, 다이아]
    // => [stone, copper, steel, ruby, diamond]
    
    [SerializeField]
    private float mSpeed;
    private int health;
    private int depend;
    private int mastery;
    private int power;
    private int luck;


    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * mSpeed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }


    void mining()
    {
        // 채광 종류 별로 태그(tag)로 줄것인지, 리스트화(enum) 시킬 것인지
    }


    void attack()
    {

    }
}
