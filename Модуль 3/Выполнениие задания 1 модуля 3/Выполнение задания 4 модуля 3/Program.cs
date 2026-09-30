using System;
using System.Collections.Generic;

//Делегат для фильрации - принимает строку и возвращает bool
delegate bool FilterDelegate(string item);

class Program
{
    static void Main()
    {
        // Исходный список данных
        List<string> data = new List<string>
        {
            "яблоко", "банан", "апельсин", "груша", "абрикос"
        };

        Console.WriteLine("Выберите фильтр:");
        Console.WriteLine("1 - по первой букве 'а'");
        Console.WriteLine("2 - по длине больше 5 символов");
        int choice = int.Parse(Console.ReadLine());

        // Выбераем делегат
        FilterDelegate filter;

        if (choice == 1)
            filter = StartsWithA;
        else
            filter = LongerThanFive;

        // Применяем фильтр к каждому элементу
        Console.WriteLine("Результат фильтрации: ");
        foreach (string item in data)
        {
            if(filter(item))
                Console.WriteLine(item);
        }
    }

    // Фильтр по первой букве
    static bool StartsWithA(string s)
    {
        return s.StartsWith("а");
    }

    // Фильтр по длине
    static bool LongerThanFive(string s)
    {
        return s.Length > 5;
    }
}
