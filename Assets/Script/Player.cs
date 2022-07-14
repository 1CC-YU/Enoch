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
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

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



        if(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetInteger("WalkUD",0);
            anim.SetInteger("WalkRL", 0);
        }
        else
        {
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                anim.SetInteger("WalkUD", -1);
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                anim.SetInteger("WalkUD", 1);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                anim.SetInteger("WalkRL", -1);
            }
            else if (Input.GetAxisRaw("Horizontal") >0)
            {
                anim.SetInteger("WalkRL", 1);
            }
        }

        
    }


    void mining()
    {
        // ä�� ���� ���� �±�(tag)�� �ٰ�����, ����Ʈȭ(enum) ��ų ������
    }


    void attack()
    {

    }
}
