using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MazeBFS : MonoBehaviour
{


    int[,] map =
    {
        {1,1,1,1,1,1},
        {1,0,0,0,1,1},
        {1,0,1,1,1,1},
        {1,0,0,0,1,1},
        {1,1,1,0,1,1},
        {1,1,1,1,1,1},
    };

    Vector2Int start = new Vector2Int(1, 1);
    Vector2Int goal = new Vector2Int(4, 3);
    bool[,] visited;
    Vector2Int?[,] parent;
    Vector2Int[] dirs =
    {
       new Vector2Int(1, 0),
       new Vector2Int(-1, 0),
       new Vector2Int(0, 1),
       new Vector2Int(0, -1),
    };

    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public float cellSize = 1;

    void Start()
    {
        List<Vector2Int> path = FindpathBFS();
        CreateMap();
    }
    List<Vector2Int> FindpathBFS()
    {
        int w = map.GetLength(0);   // X ũ��
        int h = map.GetLength(1);   // y ũ��

        visited = new bool[w, h];
        parent = new Vector2Int? [w, h];
        Queue<Vector2Int> q = new Queue<Vector2Int>();
        q.Enqueue(start);
        visited[start.x, start.y] = true;
        while(q.Count > 0)
        {
            Vector2Int cur = q.Dequeue();

            // ��ǥ ����
            if(cur == goal)
            {
                Debug.Log("BFS: Goal ����");
                return ReconstructPath();
            }

            // �� ���� �̿� Ž��
            foreach(var d in dirs)
            {
                int nx = cur.x + d.x;
                int ny = cur.y + d.y;

                if (!InBounds(nx, ny)) continue;         // ��ü �ٿ����
                if (map[nx, ny] == 1) continue;          // ��
                if (visited[nx, ny]) continue;           // �̹� �湮

                visited[nx, ny] = true;
                parent[nx, ny] = cur;
                q.Enqueue(new Vector2Int(nx, ny));
            }
        }
        Debug.Log("BFS: ��� ����");
        return null;
    }

    bool InBounds(int x, int y)
    {
        return x >= 0 && y >= 0 && x < map.GetLength(0) && y < map.GetLength(1);
    }

    List<Vector2Int> ReconstructPath()
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Vector2Int? cur = goal;
        // goal -> Start �������� parent ���󰡱�
        while (cur.HasValue)
        {
            path.Add(cur.Value);
            cur = parent[cur.Value.x, cur.Value.y];
        }
        path.Reverse();         // start -> goal ������ ����
        Debug.Log($"��� ����: {path.Count}");
        foreach (var p in path)
        {
            Debug.Log(p);
        }
        return path;
    }

    void CreateMap()
    {
        int w = map.GetLength(0);
        int h = map.GetLength(1);

        for(int x = 0; x < w; x++)
        {
            for(int y = 0; y < h; y++)
            {
                float floorHeight = 0f;
                Vector3 spawnPosition = new Vector3(x * cellSize, floorHeight, y * cellSize);

                GameObject prefabToInstantiate = null;

                if (map[x,y] == 1)
                {
                    prefabToInstantiate = wallPrefab;
                }
                else
                {
                    prefabToInstantiate = floorPrefab;
                }
                if (prefabToInstantiate != null)
                {
                    Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
                }
            }
        }
    }

}
