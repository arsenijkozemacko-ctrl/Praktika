using System;
    class Program
{
    static void Main()
    {
        int[] numbers = new int[20];
        Random rnd = new Random();
        Console.WriteLine("Сгенерированный массив:");

        //Заполняем массив случайными числами от 1 до 100
        for (int i = 0; i < numbers.Length; i++)
        {
            //Заполнение массива случайными числами от 1 до 100
            numbers[i] = rnd.Next(1, 101);
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine(); //Перенос строки

        // Инииализация min и max первым элементом массива
        int max = numbers[0];
        int min = numbers[0];

        //Проход по массиву, начиная со второго элемента
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
                max = numbers[i];

            if (numbers[i] < min)
                min = numbers[i];
        }
        Console.WriteLine($"Максимальное значение: {max}");
        Console.WriteLine($"Минимальное значение: {min}");
    }
}