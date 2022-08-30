using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_gem : MonoBehaviour
{
    public enum MineralState { Stone_gem, Iron_gem, Copper_gem, Ruby_gem, Diamond_gem};
    public MineralState state;

    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

        CheckState();
    }

    public void CheckState()
    {
        switch (state)
        {
            case MineralState.Stone_gem:
                break;
            case MineralState.Iron_gem:
                break;
            case MineralState.Copper_gem:
                break;
            case MineralState.Ruby_gem:
                break;
            case MineralState.Diamond_gem:
                break;
                
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boxCollider2D.enabled = true;
            boxCollider2D.isTrigger = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            boxCollider2D.enabled = true;
            boxCollider2D.isTrigger = true;
        }
    }
    
}
