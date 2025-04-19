using System.Diagnostics;

class Program
{
    static void Main()
    {
        // task one init th arr
        int size = 10000;
        int[] originalArray = new int[size];

        
        Stopwatch stopwatch = Stopwatch.StartNew();
        // u can use a FillArrayWithRandomData 4a 0 ms 
        ManualRandom(originalArray);
        stopwatch.Stop();
        Console.WriteLine($"Time random {stopwatch.ElapsedMilliseconds} ms");

        int[] arrayForBubbleSort = (int[])originalArray.Clone();
        int[] arrayForMergeSort = (int[])originalArray.Clone();

        stopwatch.Restart();
        BubbleSort(arrayForBubbleSort);
        stopwatch.Stop();
        Console.WriteLine($"Time ^ {stopwatch.ElapsedMilliseconds} ms");

        stopwatch.Restart();
        MergeSort(arrayForMergeSort, 0, arrayForMergeSort.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"Time log {stopwatch.ElapsedMilliseconds} ms");

        Console.ReadLine();
    }
    //
    //
    // Task 2Fill array
    // i do 2 method
    static void FillArrayWithRandomData(int[] arr)
    {
        Random rand = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rand.Next(0, 1000000);
        }
    }
    static void ManualRandom(int[] arr)
    {
        long seed = DateTime.Now.Ticks;
        for (int i = 0; i < arr.Length; i++)
        {
            seed = (seed * 6364136223846793005L + 1) % long.MaxValue;
            arr[i] = (int)(seed % 100000); // Keep values in a reasonable range
        }
    }

    //
    //
    //
    //
    // Task 4 S(n^2)
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    //
    //
    //
    //
    //
    //
    // Task 5 S(n log n)
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
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
