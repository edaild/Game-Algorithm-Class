using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PriorityQueue : MonoBehaviour
{
    public SimplePriorityQueue<string> queue;
    // Start is called before the first frame update
    void Start()
    {
        queue = new SimplePriorityQueue<string>();
        queue.Enqueue("도적" ,3);
        queue.Enqueue("마법사", 1);
        queue.Enqueue("궁수", 2);
        queue.Enqueue("전사", 4);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(queue.Dequeus());
        }
    }
}
