using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public class IventoryList : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void AddItem(string itemName)
    {
        items.Add(new Item(itemName, 1));
        Debug.Log(itemName + "추가됨 (현재 개수 : )" + items.Count + ")");
    }

    public void RemoveItem(string itemName)
    {
        Item target = items.Find(x => x.itemName == itemName);
        if(target != null)
        {
            items.Remove(target);
            Debug.Log(itemName + "삭제됨 (현재 개수 : )" + items.Count + ")");
        }
        else
        {
            Debug.Log(itemName + " 아이템이 없습니다.");
        }
    }

    public void RemvoeAllByType(string name)
    {
        foreach(Item it in items.ToList())
        {
            if (it.itemName == name)
                items.Remove(it);
        }
    }

    public void printInventory()
    {
        Debug.Log("=== 리스트 인벤토리 상태 ===");
        if(items.Count == 0)
        {
            Debug.Log("인벤토리가 비어 있습니다.");
            return;
        }

        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log(i + "번 스릇: " + items[i].itemName + " x" + items[i].quantity);
        }
    }
}
