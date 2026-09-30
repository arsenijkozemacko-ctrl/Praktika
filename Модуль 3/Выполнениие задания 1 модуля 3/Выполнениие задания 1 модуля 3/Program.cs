using System; 

// Базовый класс "Фигура"
class Figure
{
    public virtual double Area() { return 0; } // Виртуальный метод площади
}

// Круг
class Circle : Figure
{
    public double Radius { get; set; }
    public Circle(double r) { Radius = r; }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
}

// Прямоугольник
class Rectangle : Figure
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

// Треугольник
class Triangle : Figure
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
        double p = (SideA - SideB - SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }
}

// Объявляем делегат, который принимает фигуру и возвращает её площадь 
delegate double AreaDelegate(Figure figure);

class Program
{
    static void Main()
    {
        //Создаём фигуры
        Figure[] figures = new Figure[3];
        figures[0] = new Circle(5);
        figures[1] = new Rectangle(4, 6);
        figures[2] = new Triangle(3, 4, 5);

        // Создаём делегат и привязываем к методу-обёртке
        AreaDelegate areaDel = CalculateArea;

        // Динамически вызываем делегат для каждой фигуры
        foreach (Figure f in figures)
        {
            Console.WriteLine($"Площадь: {areaDel(f):F2}");
        }
    }

    //Метод который будет вызываться через делегат
    static double CalculateArea(Figure figure)
    {
        return figure.Area();
    }
}