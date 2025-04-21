using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main()
    {
        int size = 100000; 
        string[] originalArray = new string[size];

        Stopwatch stopwatch = Stopwatch.StartNew();
        FillArrayWithRandomStrings(originalArray);
        stopwatch.Stop();
        Console.WriteLine($"Time to generate random strings: {stopwatch.ElapsedMilliseconds} ms");

        string[] arrayForBubbleSort = (string[])originalArray.Clone();
        string[] arrayForMergeSort = (string[])originalArray.Clone();

        stopwatch.Restart();
        BubbleSort(arrayForBubbleSort);
        stopwatch.Stop();
        Console.WriteLine($"Bubble Sort time: {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();
        MergeSort(arrayForMergeSort, 0, arrayForMergeSort.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"Merge Sort time: {stopwatch.ElapsedMilliseconds} ms");

        Console.ReadLine();
    }

    static void FillArrayWithRandomStrings(string[] arr)
    {
        Random rand = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        for (int i = 0; i < arr.Length; i++)
        {
            int length = rand.Next(5, 15); // string length from 5 to 15
            arr[i] = new string(Enumerable.Repeat(chars, length)
                                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
    }

    static void BubbleSort(string[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (string.Compare(arr[j], arr[j + 1]) > 0)
                {
                    string temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    static void MergeSort(string[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(string[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        string[] L = new string[n1];
        string[] R = new string[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        
        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (string.Compare(L[i], R[j]) <= 0)
                arr[k++] = L[i++];
            else
                arr[k++] = R[j++];
        }

        while (i < n1)
            arr[k++] = L[i++];
        while (j < n2)
            arr[k++] = R[j++];
    }
}
