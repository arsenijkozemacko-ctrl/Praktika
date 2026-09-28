using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество элементов K: ");
        int k = int.Parse(Console.ReadLine());

        char[] arr = new char[k];
        Random rnd = new Random();

        // Все буквы русского алфавита
        string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        // Только согласные
        string consonants = "бвгджзйклмнпрстфхцчшщ";

        // Заполняем массив случайными буквами русского алфавита
        for (int i = 0; i < k; i++)
        {
            arr[i] = alphabet[rnd.Next(0, alphabet.Length)];
        }

        // Вывод исходного массива
        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < k; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();

        // Формируем новый массив только из согласных
        char[] result = new char[k];
        int count = 0;

        for (int i = 0; i < k; i++)
        {
            if (consonants.Contains(arr[i]))
            {
                result[count] = arr[i];
                count++;
            }
        }

        // Вывод массива согласных
        Console.WriteLine("Массив согласных:");
        for (int i = 0; i < count; i++)
        {
            Console.Write(result[i] + " ");
        }
    }
}