using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    GameObject[] stoneGem;
    GameObject[] ironGem;
    GameObject[] copperGem;
    GameObject[] rubyGem;
    GameObject[] diamondGem;
    GameObject[] targetPool;


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
        stoneGem = new GameObject[20];
        ironGem = new GameObject[20];
        copperGem = new GameObject[20];
        rubyGem = new GameObject[20];
        diamondGem = new GameObject[20];

        Generate();
    }

    private void Generate()
    {
        for(int index = 0; index < stoneGem.Length; index++)
        {
            stoneGem[index] = Instantiate(stoneGemProfab);
            stoneGem[index].SetActive(false);
        }
        for (int index = 0; index < ironGem.Length; index++)
        {
            ironGem[index] = Instantiate(ironGemProfab);
            ironGem[index].SetActive(false);
        }
        for (int index = 0; index < copperGem.Length; index++)
        {
            copperGem[index] = Instantiate(copperGemProfab);
            copperGem[index].SetActive(false);
        }
        for (int index = 0; index < rubyGem.Length; index++)
        {
            rubyGem[index] = Instantiate(rubyGemProfab);
            rubyGem[index].SetActive(false);
        }
        for (int index = 0; index < diamondGem.Length; index++)
        {
            diamondGem[index] = Instantiate(diamondGemProfab);
            diamondGem[index].SetActive(false);
        }

    }
    public GameObject MakeObj(Stone_gem.MineralState type)
    {
        switch (type)
        {
            case Stone_gem.MineralState.Stone_gem:
                targetPool = stoneGem;
                break;
            case Stone_gem.MineralState.Iron_gem:
                targetPool = ironGem;
                break;
            case Stone_gem.MineralState.Copper_gem:
                targetPool = copperGem;
                break;
            case Stone_gem.MineralState.Ruby_gem:
                targetPool = rubyGem;
                break;
            case Stone_gem.MineralState.Diamond_gem:
                targetPool = diamondGem;
                break;
        }
        for(int index = 0; index<targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf && targetPool[index]!= null)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        
        return null;
    }

    public GameObject []GetPool(Stone_gem.MineralState type)
    {
        switch (type)
        {
            case Stone_gem.MineralState.Stone_gem:
                targetPool = stoneGem;
                break;
            case Stone_gem.MineralState.Iron_gem:
                targetPool = ironGem;
                break;
            case Stone_gem.MineralState.Copper_gem:
                targetPool = copperGem;
                break;
            case Stone_gem.MineralState.Ruby_gem:
                targetPool = rubyGem;
                break;
            case Stone_gem.MineralState.Diamond_gem:
                targetPool = diamondGem;
                break;
        }
        return targetPool;
    }
}
