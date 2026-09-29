using System;

// Абстрактный класс — нельзя создать объект напрямую
abstract class Shape
{
    // Абстрактный метод — обязателен для переопределения в наследниках
    public abstract double Area();

    // Обычный метод, который использует абстрактный Area()
    public void PrintInfo()
    {
        Console.WriteLine($"Площадь фигуры: {Area():F2}");
    }
}

// Производный класс — круг
class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double r) { Radius = r; }

    // Переопределяем метод расчёта площади
    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
}

// Производный класс — прямоугольник
class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double w, double h)
    {
        Width = w;
        Height = h;
    }

    public override double Area()
    {
        return Width * Height;
    }
}

// Производный класс — треугольник
class Triangle : Shape
{
    public double SideA { get; set; }
    public double SideB { get; set; }
    public double SideC { get; set; }

    public Triangle(double a, double b, double c)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    public override double Area()
    {
        // Формула Герона: S = √(p(p-a)(p-b)(p-c)), где p — полупериметр
        double p = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }
}

class Program
{
    static void Main()
    {
        // Массив типа базового класса — может хранить любые производные объекты
        Shape[] shapes = new Shape[3];
        shapes[0] = new Circle(5);
        shapes[1] = new Rectangle(4, 6);
        shapes[2] = new Triangle(3, 4, 5);

        // Полиморфизм: для каждого объекта вызовется своя версия Area()
        foreach (Shape s in shapes)
        {
            s.PrintInfo();
        }
    }
}