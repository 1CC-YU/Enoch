using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    //enum���� �ϴ� �迭�� �ϴ� �÷��� ����, ��� �� �־����.
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
