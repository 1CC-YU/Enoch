using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    //enum으로 하던 배열로 하던 늘려서 구리, 루비 다 넣어야함.
    GameObject itemGem;

    GameObject targetPool;

    public GameObject itemGemProfab;

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        
            itemGem = Instantiate(itemGemProfab);
            itemGem.SetActive(false);
        
    }
    public GameObject MakeObj(Stone_gem.MineralState type)
    {
        switch (type)
        {
            case Stone_gem.MineralState.Stone_gem:
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
        }
        return targetPool;
    }
}
