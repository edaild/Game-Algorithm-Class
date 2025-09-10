using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LestTest : MonoBehaviour
{
    private void Start()
    {
        List<string> iventory = new List<string>();
        iventory.Add("Potion");
        iventory.Add("Sword");

        Debug.Log(iventory[0]);                  // Potion
        Debug.Log(iventory[1]);                  // sword
        Debug.Log(iventory[2]);                 // null

        foreach(string item in iventory)
        {
            Debug.Log(item);
        }
    }
}
