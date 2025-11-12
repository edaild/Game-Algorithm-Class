using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class ScarchBacktracking : MonoBehaviour
{

    int[] cards = { 2, 3, 5, 7, 9 };

    int limit = 15;
    void Start()
    {
        Search(0, new List<int>(), 0);
    }

    void Search(int i, List<int> list, int sum)
    {
        if (sum > limit) return;
        if(i == cards.Length)
        {
            Debug.Log($"{string.Join(",", list)} = {sum}");
            return;

        }
        // 현제 카드 선택
        list.Add(cards[i]);
        Search(i + 1, list, sum + cards[i]);
        list.Remove(list.Count - 1);

        // 현재 카드 미선택
        Search(i + 1, list, sum);
    }

 
}
