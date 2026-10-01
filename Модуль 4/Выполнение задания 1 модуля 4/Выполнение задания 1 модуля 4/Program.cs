using System;

// Интерфейс "Фигура" - контракт для всех геоометрических фигур
interface IFigure
{
    double Area(); // Метод вычисления площади
    double Perimetr(); // Метод вычисления периметра
}

// Круг реализует интерфейс IFigure
class Circle : IFigure
{
    public double Radius {  get; set; } // радиус круга

    // Конструктор - принимает радиус
    public Circle(double r) { Radius = r;}

    // Реализация метода площади
    public double Area()
    {
        return Math.PI * Radius * Radius; // Формула вычисления площади круга
    }

    // Реализация метода периметра (длина окружности)
    public double Perimetr()
    {
        return 2 * Math.PI * Radius; // Формула вычисления периметра круга
    }
}

// Прямоугольник реалиует IFigure
class Rectangle : IFigure
{
    public double Width { get; set; } // ширина
    public double Height { get; set; } // высота

    public Rectangle(double w, double h)
    {
        Width = w;
        Height = h;
    }

    public double Area() { return Width * Height; } // Формула вычисления площади прямоугольника
    public double Perimetr() { return 2 * (Width * Height); } // Формула вычисления площади прямоугольника
}

// Треугольник реализует IFigure
class Triangle : IFigure
{
    public double SideA { get; set; } // сторона А
    public double SideB { get; set; } // Сторона Б
    public double SideC { get; set; } // Сторона С 

    public Triangle(double a, double b, double c)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    // Площадь по формуле Герона
    public double Area()
    {
        double p = (SideA + SideB + SideC) / 2; // полупериметр
            return Math.Sqrt(p * (p - SideA) * (p * SideB) * (p * SideC));
    }

    // Периметр - сумма трёх сторон
    public double Perimetr()
    {
        return SideA + SideB + SideC;
    }
}

class Program
{
    static void Main()
    {
        // Массив типа интерфейса - может хранить любые фигуры
        IFigure[] figures = new IFigure[3];
        figures[0] = new Circle(5);
        figures[1] = new Rectangle(7, 5);
        figures[2] = new Triangle(2, 6, 4);

        // У каждой фигуры своя Area() и Perimetr()
        foreach(IFigure f in figures)
        {
            Console.WriteLine($"Площадь: {f.Area():F2}, Периметр: {f.Perimetr():F2}");
        }
    }
}