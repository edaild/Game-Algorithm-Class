using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvnetoryArraey : MonoBehaviour
{
    public int inventorySize = 10;  // ÀÎº¥Åä¸® °£ °³¼ö

    public Item[] item;

    private void Start()
    {
        item = new Item[inventorySize];

    }

    public void AddItem(string itemName)
    {
       // ºó Ä­ Ã£±â
       for(int i = 0; i < item.Length; i++)
        {
            if (item[i] == null)
            {
                item[i] = new Item(itemName, 1);
                Debug.Log(itemName + " Ãß°¡µÊ (½½·í " + i + ")");
                return;
            } 
        }
        Debug.Log("ÀÎº¥Åä¸®°¡ °¡µæ Ã¡½À´Ï´Ù.");
    }

   public void RemoveItem(string itemName)
    {
        for(int i = 0; i < item.Length; i++)
        {
            if (item[i] != null && item[i].itemName == itemName)
            {
                Debug.Log(itemName + "»èÁ¦µÊ (½½¸© " + i + ")");
                item[i] = null;
                return;
            }
        }
    }

    public void PrintInventory()
    {
        Debug.Log("=== ¹è¿­ ÀÎº¥Åä¸® »óÅÂ ===");
        for(int i = 0; i < item.Length; i++)
        {
            if (item[i] != null)
                Debug.Log(i + "ºó ½½¸©: " + item[i].itemName + "x" + item[i].quantity);
            else
                Debug.Log(i + "ºó ½½¸©: ºñ¾îÀÖÀ½");
        }
    }
}
