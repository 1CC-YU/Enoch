using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //½ºÅÈ =>[Ã¼·Â, ¹æ¾îµµ, ¼÷·Ãµµ, Èû, ¿î]
    // => [health, depend, mastery, power, luck]
    //Ã¤±¤ => [µ¹, ±¸¸®, Ã¶, ·çºñ, ´ÙÀÌ¾Æ]
    // => [stone, copper, steel, ruby, diamond]
    
    [SerializeField]
<<<<<<< HEAD
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
>>>>>>> parent of 0794c70 (ì €ìž¥)
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
<<<<<<< HEAD

        // Ã¤±¤ Á¾·ù º°·Î ÅÂ±×(tag)·Î ÁÙ°ÍÀÎÁö, ¸®½ºÆ®È­(enum) ½ÃÅ³ °ÍÀÎÁö

=======
        // Ã¤ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½Â±ï¿½(tag)ï¿½ï¿½ ï¿½Ù°ï¿½ï¿½ï¿½ï¿½ï¿½, ï¿½ï¿½ï¿½ï¿½Æ®È­(enum) ï¿½ï¿½Å³ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½
>>>>>>> bdd046e06cc1d47e1884252618625c0c1bcfd67e
    }

    private void attack()
    {

    }
}
