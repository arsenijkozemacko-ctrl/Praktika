using System;
class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        //Считываем строку и преобразуем её в целое число
        int number = int.Parse(Console.ReadLine());

        //Проверка остатка от деления на 2
        if (number % 2 == 0)
        {
            Console.WriteLine($"Число {number} является четным.");
        }
        else
        {
            Console.WriteLine($"Число {number} является нечетным.");
        }
    }
}
