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

        float _dirX = Input.GetAxisRaw("Horizontal");
        float _dirY = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(_dirX, _dirY);
        anim.SetBool("Right", false);
        anim.SetBool("Left", false);
        anim.SetBool("Down", false);
        anim.SetBool("Up", false);


        if (direction != Vector3.zero)
        {
            this.transform.Translate(direction.normalized * mSpeed * Time.deltaTime);

            if (direction.y > 0)
            {
                anim.SetBool("Up", true);
            }
            else if (direction.y < 0)
            {
                anim.SetBool("Down", true);
            }
            else if (direction.x > 0)
            {
                anim.SetBool("Right", true);
            }
            else if (direction.x < 0)
            {
                anim.SetBool("Left", true);
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
