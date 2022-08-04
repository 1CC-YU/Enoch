using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Items
{
   public int itemID;
   public string itemName;
   public string itemDescription;
   public int miningDurablility;


   public Items(int _itemID, string _itemName, string _itemDes)
   {
    itemID = _itemID;
    itemName = _itemName;
    itemDescription = _itemDes;
   }
}
