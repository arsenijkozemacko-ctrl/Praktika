using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите количество простых чисел K: ");
        int k = int.Parse(Console.ReadLine());

        int count = 0;
        int number = 2;

        while (count < k)
        {
            bool isPrime = true;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.Write(number + " ");
                count++;

                // Каждые 10 чисел — перевод строки
                if (count % 10 == 0)
                    Console.WriteLine();
            }

            number++;
        }
    }
}