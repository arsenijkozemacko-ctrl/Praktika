using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите предельное число: ");
        int limit = int.Parse(Console.ReadLine());

        Random rnd = new Random();
        int[] arr = new int[1];
        arr[0] = rnd.Next(1, 10);

        int sum = arr[0];

        while (true)
        {
            int next = rnd.Next(1, 10);

            if (sum + next > limit)
                break;

            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = next;
            sum += next;
        }

        Console.WriteLine("Полученный массив:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine($"\nСумма элементов: {sum}");
    }
}