using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер квадратной матрицы N: ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        Random rnd = new Random();

        // Заполнение матрицы случайными значениями от -50 до 50
        Console.WriteLine("Исходная матрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rnd.Next(-50, 51);
                Console.Write($"{matrix[i, j],5} ");
            }
            Console.WriteLine();
        }

        // Вычисление суммы строк
        int[] sums = new int[n];
        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = 0; j < n; j++)
            {
                sum += matrix[i, j];
            }
            sums[i] = sum;
        }

        // Сортировка строки методом "пузырька" по возрастанию сумм
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {
                if (sums[j] > sums[j + 1])
                {
                    // Изменение суммы местами
                    int tempSum = sums[j];
                    sums[j] = sums[j + 1];
                    sums[j + 1] = tempSum;

                    // Изменение строки местами
                    for (int k = 0; k < n; k++)
                    {
                        int temp = matrix[j, k];
                        matrix[j, k] = matrix[j + 1, k];
                        matrix[j + 1, k] = temp;
                    }
                }
            }
        }

        // Вывод отсортированной матрицы
        Console.WriteLine("\nМатрица после сортировки строк по сумме:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{matrix[i, j],5} ");
            }
            Console.WriteLine();
        }
    }
}