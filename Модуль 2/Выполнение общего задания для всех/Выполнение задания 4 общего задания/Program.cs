using System; // подключение пространства имён для работы с Console

// Интерфейс — набор методов без реализации
interface IDrawable
{
    void Draw(); // метод, который обязаны реализовать все наследники
}
// Круг реализует интерфейс IDrawable
class Circle : IDrawable
{
    public double Radius { get; set; } // радиус круга

    // Конструктор — принимает радиус
    public Circle(double r) { Radius = r; }

    // Реализация метода Draw для круга
    public void Draw()
    {
        Console.WriteLine($"Рисуется круг с радиусом {Radius}");
    }
}
// Прямоугольник реализует интерфейс IDrawable
class Rectangle : IDrawable
{
    public double Width { get; set; }   // ширина
    public double Height { get; set; }  // высота

    // Конструктор — принимает ширину и высоту
    public Rectangle(double w, double h)
    {
        Width = w;
        Height = h;
    }
    // Реализация метода Draw для прямоугольника
    public void Draw()
    {
        Console.WriteLine($"Рисуется прямоугольник {Width}x{Height}");
    }
}
// Треугольник реализует интерфейс IDrawable
class Triangle : IDrawable
{
    public double SideA { get; set; } // первая сторона
    public double SideB { get; set; } // вторая сторона
    public double SideC { get; set; } // третья сторона

    // Конструктор — принимает три стороны
    public Triangle(double a, double b, double c)
    {
        SideA = a;
        SideB = b;
        SideC = c;
    }

    // Реализация метода Draw для треугольника
    public void Draw()
    {
        Console.WriteLine($"Рисуется треугольник со сторонами {SideA}, {SideB}, {SideC}");
    }
}
class Program
{
    static void Main()
    {
        // Массив типа интерфейса IDrawable может хранить любые объекты,
        // которые реализуют этот интерфейс
        IDrawable[] figures = new IDrawable[3];
        figures[0] = new Circle(5);        // круг
        figures[1] = new Rectangle(4, 6);  // прямоугольник
        figures[2] = new Triangle(3, 4, 5);// треугольник
        // Полиморфизм: у каждого объекта вызовется своя версия Draw()
        foreach (IDrawable fig in figures)
        {
            fig.Draw();
        }
    }
}