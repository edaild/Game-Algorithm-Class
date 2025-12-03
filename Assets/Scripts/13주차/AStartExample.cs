using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AStartExample : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject floor02Prefab;
    public GameObject floor03Prefab;
    public GameObject LoodFallowPrefab;
    public float cellSize;

    
    int[,] map;

    Vector2Int start = new Vector2Int(1, 1);
    Vector2Int goal = new Vector2Int(4, 5);
    void Start()
    {
        int mapx = Random.Range(1, 8);
        int mapy = Random.Range(1, 8);
        map = new int[mapx, mapy];
        for (int x = 0; x < mapx; x++)
        {
            for(int y = 0; y < mapy; y++)
            {

                int grounRandom = Random.Range(1, 100);
                if(grounRandom >= 20)
                {
                    x = 3;
                    y = 3;
                }
                else if (grounRandom >= 30)
                {
                    x = 2;
                    y = 2;
                }
                else if(grounRandom >= 80)
                {
                    x = 1;
                    y = 1;
                }
                else
                {
                    x = 0;
                    y = 0;
                }
            }

        }

        var path = Astar(map, start, goal);

        if (path == null) Debug.Log("경로 없음");
        else
        {
            Debug.Log($"경로 깊이: {path.Count}");
            foreach (var p in path)
                Debug.Log(p);
        }
        CreateMap();
    }

    List<Vector2Int> Astar(int[,] map, Vector2Int start, Vector2Int goal)
    {
        int w = map.GetLength(0);
        int h = map.GetLength(1);

        int[,] gCost = new int[w, h];
        bool[,] visited = new bool[w, h];
        Vector2Int?[,] parent = new Vector2Int?[w, h];

        for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++)
                gCost[x, y] = int.MaxValue;

        gCost[start.x, start.y] = 0;

        Vector2Int[] dirs =
        {
            new Vector2Int(1, 0),
            new Vector2Int(-1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(0, -1),
        };

        List<Vector2Int> open = new List<Vector2Int>();
        open.Add(start);

        while (open.Count > 0)
        {
            int bastIndex = 0;
            int bastF = F(open[0], gCost, goal);
            for (int i = 1; i < open.Count; i++)    // F가 장 작은 노드 선택
            {
                int f = F(open[i], gCost, goal);
                if (f < bastF)
                {
                    bastF = f;
                    bastIndex = i;
                }
            }
            Vector2Int cur = open[bastIndex];
            open.RemoveAt(bastIndex);

            if (visited[cur.x, cur.y]) continue;
            visited[cur.x, cur.y] = true;

            if (cur == goal)    // 도착
                return ReConstructPath(parent, start, goal);

            foreach (var d in dirs) // 이웃 체크
            {
                int nx = cur.x + d.x;
                int ny = cur.y + d.y;

                if (!InBounds(map, nx, ny)) continue;
                if (map[nx, ny] == 0) continue;         // 벽
                if (visited[nx, ny]) continue;

                int moveCost = TileCost(map[nx, ny]);
                int newG = gCost[cur.x, cur.y] + moveCost;

                // 더 좋은 경로 발견
                if (newG < gCost[nx, ny])
                {
                    gCost[nx, ny] = newG;
                    parent[nx, ny] = cur;

                    if (!open.Contains(new Vector2Int(nx, ny)))
                        open.Add(new Vector2Int(nx, ny));
                }
            }
        }
        return null;

    }

    int TileCost(int tile)
    {
        switch (tile)
        {
            case 1: return 1;       // 평지
            case 2: return 3;       // 숲
            case 3: return 5;       // 진흙
            default: return int.MaxValue;   //0~ 벽 포함
        }
    }

    int F(Vector2Int pos, int[,] gCost, Vector2Int goal)
    {
        return gCost[pos.x, pos.y] + H(pos, goal);
    }

    int H(Vector2Int a, Vector2Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    bool InBounds(int[,] map, int x, int y)
    {
        return x >= 0 && y >= 0 &&
            x < map.GetLength(0) &&
            y < map.GetLength(1);
    }

    List<Vector2Int> ReConstructPath(Vector2Int?[,] parent, Vector2Int start, Vector2Int goal)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Vector2Int? cur = goal;

        while (cur.HasValue)
        {
            path.Add(cur.Value);
            if (cur.Value == start) break;
            cur = parent[cur.Value.x, cur.Value.y];
        }
        path.Reverse();
        return path;
    }

    void CreateMap()
    {
        int w = map.GetLength(0);
        int h = map.GetLength(1);

        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {
                float floorHeight = 0f;
                Vector3 spawnPosition = new Vector3(x * cellSize, floorHeight, y * cellSize);

                GameObject prefabToInstantiate = null;

                if (map[x, y] == 0)
                {
                    prefabToInstantiate = wallPrefab;
                }
                else if (map[x, y] == 1)
                {
                    prefabToInstantiate = floorPrefab;
                }
                else if (map[x, y] == 2)
                {
                    prefabToInstantiate = floor02Prefab;
                }
                else if (map[x, y] == 3)
                {
                    prefabToInstantiate = floor03Prefab;
                }
                if (prefabToInstantiate != null)
                {
                    Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity);
                }
            }
        }
    }

}
