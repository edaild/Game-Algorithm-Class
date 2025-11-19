using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeShell : MonoBehaviour
{
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    public GameObject bottonWall;
    public GameObject Pool;

    public bool visitedvisited = false;
    public int x;
    public int z;

    public void ShowAllWalls()
    {
        leftWall.SetActive(true);
        rightWall.SetActive(true);
        topWall.SetActive(true);
        bottonWall.SetActive(true);
        Pool.SetActive(true);
    }

    void RemoveShell(string direction)
    {
        switch (direction)
        {
            case "left":
                leftWall.SetActive(false);
                break;
            case "right":
                rightWall.SetActive(false);
                break;
            case "top":
                topWall.SetActive(false);
                break;
            case "botton":
                bottonWall.SetActive(false);
                break;
        }
    }

    void Initialaze(int Xpos, int Ypos)
    {
        x = Xpos;
        z = Ypos;

        ShowAllWalls();
    }
}
