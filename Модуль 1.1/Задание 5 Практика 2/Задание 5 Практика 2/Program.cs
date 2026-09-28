using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите ваш возраст: ");
        int age = int.Parse(Console.ReadLine());

        //Проверка на больше или равно 18
        if (age >= 18)
        {
            Console.WriteLine("Вы можете получить водительские права.");
        }
        else
        {
            Console.WriteLine("Вы ещё слишком молоды для получения прав");
        }
    }
}