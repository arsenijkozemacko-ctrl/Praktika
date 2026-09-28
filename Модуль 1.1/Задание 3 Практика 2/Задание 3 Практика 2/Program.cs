using System;
class Program
{
   static void Main()
    {
        Console.Write("Введите имя: ");
        string firstName = Console.ReadLine();

        Console.Write("Введите Фамилию: ");
        string lastName = Console.ReadLine();

        //Вывод в формате "Фамилии, Имя"
        Console.WriteLine($"{lastName}, {firstName}");
    }
}