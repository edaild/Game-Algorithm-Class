using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvnetoryArraey : MonoBehaviour
{
    public int inventorySize = 10;  // �κ��丮 �� ����

    public Item[] item;

    private void Start()
    {
        item = new Item[inventorySize];

    }

    public void AddItem(string itemName)
    {
       // �� ĭ ã��
       for(int i = 0; i < item.Length; i++)
        {
            if (item[i] == null)
            {
                item[i] = new Item(itemName, 1);
                Debug.Log(itemName + " �߰��� (���� " + i + ")");
                return;
            } 
        }
        Debug.Log("�κ��丮�� ���� á���ϴ�.");
    }

   public void RemoveItem(string itemName)
    {
        for(int i = 0; i < item.Length; i++)
        {
            if (item[i] != null && item[i].itemName == itemName)
            {
                Debug.Log(itemName + "������ (���� " + i + ")");
                item[i] = null;
                return;
            }
        }
    }

    public void PrintInventory()
    {
        Debug.Log("=== �迭 �κ��丮 ���� ===");
        for(int i = 0; i < item.Length; i++)
        {
            if (item[i] != null)
                Debug.Log(i + "�� ����: " + item[i].itemName + "x" + item[i].quantity);
            else
                Debug.Log(i + "�� ����: �������");
        }
    }
}
