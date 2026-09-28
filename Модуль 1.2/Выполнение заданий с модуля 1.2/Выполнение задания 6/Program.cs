using System;

class Program
{
    static void Main()
    {
        double[] arr = new double[10];
        int[] indices = new int[10];
        Random rnd = new Random();

        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < 10; i++)
        {
            // NextDouble() даёт [0, 1), умножаем на 20 [0, 20), вычитаем 10 [-10, 10)
            arr[i] = rnd.NextDouble() * 20 - 10;
            indices[i] = i;
            Console.Write($"{arr[i]:F2} ");
        }
        Console.WriteLine();

        // Сортировка индексов по значениям элементов (метод "пузырька")
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9 - i; j++)
            {
                if (arr[indices[j]] > arr[indices[j + 1]])
                {
                    int temp = indices[j];
                    indices[j] = indices[j + 1];
                    indices[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Индексы в порядке возрастания значений:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(indices[i] + " ");
        }
    }
}