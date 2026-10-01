using System;

// Интерфейс "Рисунок" - контракт для рисования
interface IDrawing
{
    void DrawLine(); // нарисовать линию
    void DrawCircle(); // нарисовать круг
    void DrawRectangle(); // нарисовать прямоугольник
}

// Класс для работы с холстом - реализует интерфейс
class Canvas : IDrawing
{
    // Имитация рисовании линии
    public void DrawLine()
    {
        Console.WriteLine("Нарисована линия");
    }

    // Имитация рисования круга
    public void DrawCircle()
    {
        Console.WriteLine("Нарисован круг");
    }

    // Имитация рисования прямоугольника
    public void DrawRectangle()
    {
        Console.WriteLine("Нарисован прямоугольник");
    }
}


class Program
{
    static void Main()
    {
        // Создание холста
        Canvas canvas = new Canvas();

        // Вызов всех методов рисования
        canvas.DrawLine();
        canvas.DrawCircle();
        canvas.DrawRectangle();
    }
}