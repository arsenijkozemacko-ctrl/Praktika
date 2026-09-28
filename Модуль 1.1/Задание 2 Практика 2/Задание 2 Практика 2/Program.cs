using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите радиус круга: ");
        double radius = double.Parse(Console.ReadLine());

        //Формула площади круга S = π * r^2
        //Math.PI - встроенная константа числа ПИ
        double area = Math.PI * Math.Pow(radius, 2);

        Console.WriteLine($"Площадь круга равна: {area:F2}"); //F2 округляет до 2 знаков после запятой
    }
}