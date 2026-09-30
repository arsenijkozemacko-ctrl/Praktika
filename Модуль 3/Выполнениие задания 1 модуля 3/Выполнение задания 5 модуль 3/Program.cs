using System;
using System.Security.AccessControl;

// Делагат для сортировки - принимает массив
delegate void SortDelegate(int[] arr);

class Program
{
    static void Main()
    {
        int[] data = { 5, 2, 9, 1, 7, 3, 8, 4, 6 };

        Console.WriteLine("Исходный массив: " + string.Join(" ", data));

        Console.WriteLine("Выберите метод сортировки:");
        Console.WriteLine("1 - пузырьком");
        Console.WriteLine("2 - быстрая");
        int choice = int.Parse(Console.ReadLine());

        // Выбираем делегат
        SortDelegate sort;

        if (choice == 1)
            sort = BubbleSort;
        else
            sort = QuickSort;

        // Выполняем сортировку через делегат
        sort(data);

        Console.WriteLine("Отсортированный массив: " + string.Join(' ', data));
    }

    // Сортировка пузырьком
    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Быстрая сортировка (обёртка)
    static void QuickSort(int[] arr)
    {
        QuickSortRecursive(arr, 0, arr.Length - 1);
    }

    // Рекурсивная реализация быстрой сортировки
    static void QuickSortRecursive(int[] arr, int left, int right)
    {
        if (left >= right) return;

        int pivot = arr[(left + right) / 2];
        int i = left, j = right;

        while (i <= j)
        {
            while (arr[i] < pivot) i++;
            while (arr[j] > pivot) j--;

            if (i <= j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
        }

        QuickSortRecursive(arr, left, j);
        QuickSortRecursive(arr, i, right);
    }
}