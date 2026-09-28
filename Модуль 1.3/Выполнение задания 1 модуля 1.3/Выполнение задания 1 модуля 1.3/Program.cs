using System;

class Program
{
    // Статический метод для вычисления НОД (алгоритм Евклида)
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static void Main()
    {
        Console.Write("Введите числитель (неотрицательный): ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите знаменатель (положительный): ");
        int b = int.Parse(Console.ReadLine());

        if (b == 0)
        {
            Console.WriteLine("Ошибка: знаменатель не может быть равен нулю.");
            return;
        }

        // Нахождения НОД и делим на него числитель и знаменатель
        int gcd = GCD(a, b);
        int newA = a / gcd;
        int newB = b / gcd;

        Console.WriteLine($"Сокращённая дробь: {newA}/{newB}");
    }
}