using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;

    public int quantity;                // ¼ö·®

    public Item(string name, int qty = 1)
    {
        this.itemName = name;
        this.quantity = qty;
    }

    
}
