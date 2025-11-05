using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICArdCost : MonoBehaviour
{
    [Header("카드 정보")]
    public int qickCost = 2;
    public int habiCost = 3;
    public int multiCost = 5;
    public int trufleCost = 7;

    public int qickDamege = 6;
    public int habiDamemge = 8;
    public int multiDamege = 16;
    public int trufleDamege = 7;

    public int qickCount = 0;
    public int habiCount = 0;
    public int multCount = 0;
    public int trufleCount = 0;

    [Header("AI")]
    public int aiCost = 15;

    private void Start()
    {
        trufleCard();
    }

    void trufleCard()
    {
        for (int t = 0; t < 2; t++)
        {
            aiCost -= trufleCount;
            trufleCount += 1;
            Debug.Log($"trufleCount aiCost: {aiCost}");
            if (aiCost < 0)
            {
                habiCount -= 1;
                break;
            }
        }
        multCard();
    }

    void multCard()
    {
        for (int m = 0; m < 2; m++)
        {
            aiCost -= habiCost;
            qickCount += 1;
            Debug.Log($"habiCost aiCost: {aiCost}");
            if (aiCost < 0)
            {
                habiCount -= 1;
                break;
            }
        }
    }

    void habiCard()
    {
        for (int h = 0; h < 2; h++)
        {
            aiCost -= habiCost;
            qickCount += 1;
            Debug.Log($"habiCost aiCost: {aiCost}");
            if (aiCost < 0)
            {
                habiCount -= 1;
                break;
            }
        }
        habiCard();
    }

    void qickCard()
    {
        for (int q = 0; q < 2; q++)
        {
            aiCost -= qickCost;
            qickCount += 1;
            Debug.Log($"qickCost aiCost: {aiCost}");
            if (aiCost < 0)
            {
                qickCount -= 1;
                break;
            }
        }
        qickCard();
    }
}
