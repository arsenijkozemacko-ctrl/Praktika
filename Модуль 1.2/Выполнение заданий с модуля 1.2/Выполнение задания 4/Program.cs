using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов K: ");
        int k = int.Parse(Console.ReadLine());

        Console.Write("Введите A: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите B: ");
        int b = int.Parse(Console.ReadLine());

        int[] arr = new int[k];
        Random rnd = new Random();

        for (int i = 0; i < k; i++)
        {
            arr[i] = rnd.Next(a, b + 1);
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();

        // Поиск индексов min и max
        int minIndex = 0, maxIndex = 0;
        for (int i = 1; i < k; i++)
        {
            if (arr[i] < arr[minIndex]) minIndex = i;
            if (arr[i] > arr[maxIndex]) maxIndex = i;
        }

        // Определение границы
        int start = Math.Min(minIndex, maxIndex);
        int end = Math.Max(minIndex, maxIndex);

        Console.WriteLine("Элементы между min и max:");
        for (int i = start; i <= end; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}