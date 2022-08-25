using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gems
{
    public int gemID;
    public string gemName;
    public string gemDescription;
    public int gemPrice;
    public Gems(int _gemID, string _gemName, string _gemDes, int _gemPrice)
    {
        gemID = _gemID;
        gemName = _gemName;
        gemDescription = _gemDes;
        gemPrice = _gemPrice;
    }
}