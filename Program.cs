using System;
using System.Diagnostics;

class Program
{
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];


        Array.Copy(arr, left, leftArr, 0, n1);
        Array.Copy(arr, mid + 1, rightArr, 0, n2);

        int i = 0, j = 0, k = left;


        while (i < n1 && j < n2)
        {
            if (leftArr[i] <= rightArr[j])
                arr[k++] = leftArr[i++];
            else
                arr[k++] = rightArr[j++];
        }


        while (i < n1)
            arr[k++] = leftArr[i++];


        while (j < n2)
            arr[k++] = rightArr[j++];
    }


    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;


            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);


            Merge(arr, left, mid, right);
        }
    }


    static void TestMergeSort()
    {
        int size = 1000000;
        int[] arr = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(0, 1000000);
        }

        Console.WriteLine("Starting MergeSort on large array...");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        MergeSort(arr, 0, arr.Length - 1);

        stopwatch.Stop();

        Console.WriteLine($"Time taken for sorting: {stopwatch.Elapsed.TotalSeconds} seconds");


        if (IsSorted(arr))
        {
            Console.WriteLine("Array sorted successfully.");
        }
        else
        {
            Console.WriteLine("Array is not sorted.");
        }
    }


    static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
                return false;
        }
        return true;
    }

    static void Main()
    {
        TestMergeSort();
    }
}
