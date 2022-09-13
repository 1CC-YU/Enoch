using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    GameObject itemGem;
    GameObject targetPool;

    [SerializeField]
    GameObject stoneGemProfab;
    [SerializeField]
    GameObject ironGemProfab;
    [SerializeField]
    GameObject copperGemProfab;
    [SerializeField]
    GameObject rubyGemProfab;
    [SerializeField]
    GameObject diamondGemProfab;



    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        itemGem = Instantiate(stoneGemProfab);
        itemGem.SetActive(false);
    }
    public GameObject MakeObj(Stone_gem.MineralState type)
    {
        switch (type)
        {
            case Stone_gem.MineralState.Stone_gem:
                targetPool = itemGem;
                break;
            case Stone_gem.MineralState.Iron_gem:
                targetPool = itemGem;
                break;
            case Stone_gem.MineralState.Copper_gem:
                targetPool = itemGem;
                break;
            case Stone_gem.MineralState.Ruby_gem:
                targetPool = itemGem;
                break;
            case Stone_gem.MineralState.Diamond_gem:
                targetPool = itemGem;
                break;
        }
        if (!targetPool.activeSelf)
        {
            targetPool.SetActive(true);
            return targetPool;
        }

        return null;
    }

    public GameObject GetPool(Stone_gem.MineralState type)
    {
        switch (type)
        {
            case Stone_gem.MineralState.Stone_gem:
                targetPool = itemGem;
                break;
            case Stone_gem.MineralState.Iron_gem:
                targetPool = itemGem;
                break;
            case Stone_gem.MineralState.Copper_gem:
                targetPool = itemGem;
                break;
            case Stone_gem.MineralState.Ruby_gem:
                targetPool = itemGem;
                break;
            case Stone_gem.MineralState.Diamond_gem:
                targetPool = itemGem;
                break;
        }
        return targetPool;
    }
}
