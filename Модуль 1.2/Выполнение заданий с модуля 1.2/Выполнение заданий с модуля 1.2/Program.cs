using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер массива N: ");
        int n = int.Parse(Console.ReadLine());

        double[] arr = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введите элемент [{i}]: ");
            arr[i] = double.Parse(Console.ReadLine());
        }

        // Находим максимальный по модулю элемент
        double maxAbs = Math.Abs(arr[0]);
        for (int i = 1; i < n; i++)
        {
            if (Math.Abs(arr[i]) > maxAbs)
                maxAbs = Math.Abs(arr[i]);
        }

        Console.WriteLine("Изменённый массив:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = arr[i] / maxAbs;
            Console.Write($"{arr[i]:F2} ");
        }
    }
}