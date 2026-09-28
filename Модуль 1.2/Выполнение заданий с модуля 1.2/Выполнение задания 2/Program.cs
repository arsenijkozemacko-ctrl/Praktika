using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[10];

        Console.WriteLine("Введите 10 целых чисел:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Элемент [{i}]: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Введите число для замены максимума: ");
        int replacement = int.Parse(Console.ReadLine());

        // Находим индекс максимального элемента
        int maxIndex = 0;
        for (int i = 1; i < 10; i++)
        {
            if (arr[i] > arr[maxIndex])
                maxIndex = i;
        }

        arr[maxIndex] = replacement;

        Console.WriteLine("Изменённый массив:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}