using System;

//Базовый класс - фигура
class Shape
{
    //vurtual - позволяет переопределить метод в наследниках
    public virtual double Area() { return 0; }
    public virtual double Perimetr() { return 0; }
}

// Круг наследуется от Shape
class Circle : Shape
{
    public double Radius { get; set; }

    //Конструктор прннимает радиус
    public Circle(double r) { Radius = r; }

    //Переопределение метода площади
    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }

    //Переопределение меода периметра (длина окружности)
    public override double Perimetr()
    {
        return 2 * Math.PI * Radius;
    }
}

// Прямоугольник наследуется от Shape
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

    public override double Perimetr()
    {
        return 2 * (Width * Height);
    }
}

class Program
{
    static void Main()
    {
        //Создание объектов фигур
        Circle c = new Circle(5);
        Rectangle r = new Rectangle(4, 6);

        //Вывод площади и периметры
        Console.WriteLine($"Круг : площадь = {c.Area():F2}, периметр = {c.Perimetr():F2}");
        Console.WriteLine($"Прямоугольник : площадь = {r.Area():F2}, периметр = {r.Perimetr():F2}");
    }
}

