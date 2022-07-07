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
        // ä�� ���� ���� �±�(tag)�� �ٰ�����, ����Ʈȭ(enum) ��ų ������
    }


    void attack()
    {

    }
}
