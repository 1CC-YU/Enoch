using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone_gem : MonoBehaviour
{
    public enum MineralState { Stone_gem, Iron_gem, Copper_gem, Ruby_gem, Diamond_gem};
    public MineralState state;

    private void Awake()
    {
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
}
