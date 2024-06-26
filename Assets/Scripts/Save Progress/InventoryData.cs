using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData
{
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public int coins;
    public Dictionary<string, int> BuyiedItems = new Dictionary<string, int>();

    public InventoryData(Inventory Inventory){
        inventory = Inventory.inventory;
        BuyiedItems = Inventory.BuyiedItems;
        coins = Inventory.coins;

    }
}