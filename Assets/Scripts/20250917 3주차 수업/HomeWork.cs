using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class HomeWork : MonoBehaviour
{
    public Text text;

    private bool Quickclick;
    private bool SlelctionSortclick;
    private bool BubbleSortclick;

    void Awake()
    {
        int[] data = GenrateRandomArray(1000);
        Stopwatch sw = new Stopwatch();

        SelectSortTest.StartSelectionSort(data);
        long selectionTime = sw.ElapsedMilliseconds;
        if (Quickclick)
        {
            sw.Restart();
            sw.Start();
            StartQuickSort(data, 0, data.Length - 1);
            sw.Stop();
        }
        if (SlelctionSortclick)
        {
            sw.Restart();
            sw.Start();
            StartSelectionSort(data);
            sw.Stop();
            text.text = $"{sw.ElapsedMilliseconds}";
        }
        if (!BubbleSortclick)
        {
            sw.Restart();
            sw.Start();
            StartBubbleSort(data);
            sw.Stop();
            text.text = $"{sw.ElapsedMilliseconds}";
        }
       

        foreach (var item in data)
        {
           UnityEngine.Debug.Log(item);
        }
    }

    public void OnButtonClickQuickSort()
    {
        Quickclick = true;
        SlelctionSortclick = false;
        BubbleSortclick = false;
    }

    public void OnButtonClickSlelctionSort()
    {
        SlelctionSortclick = true;
        Quickclick = false;
        BubbleSortclick = false;
    }

    public void OnButtonClickBubbleSort()
    {
        BubbleSortclick = true;
        Quickclick = false;
        BubbleSortclick = false;
    }

    int[] GenrateRandomArray(int size)
    {
        int[] arr = new int[size];
        System.Random rand = new System.Random();
        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(0, 10000);
        }
        return arr;
    }

    public static void StartQuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);

            StartQuickSort(arr, low, pivotIndex - 1);               // 피벗 왼쪽 정렬
            StartQuickSort(arr, pivotIndex + 1, high);              // 피벗 오른쪽 정렬
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                //swop
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        // privot 자리 교환
        int temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;
        return i + 1;

    }

    public static void StartSelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                minIndex = j;
            }
            //swap
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }

    }

    public static void StartBubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // swap
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    swapped = true;
                }
            }
            // 이미 정렬된 경우 조기 종료
            if (!swapped) break;
        }
    }
}
