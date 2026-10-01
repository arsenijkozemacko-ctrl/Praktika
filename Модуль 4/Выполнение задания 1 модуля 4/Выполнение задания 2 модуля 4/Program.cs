using System;

// Интерфейс "Товар" - общий окнтракт для всех товаров
interface IProduct
{
    double GetCost(); // стоимость товара
    int GetStock(); // остаток на складе
}

// Продукт питания - реализует IProduct
class Food : IProduct
{
    public string Name { get; set; } // название
    public double Price { get; set; } // цена за единицу
    public int Quantity { get; set; } // остаток на складе

    public Food(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    // Стоимость = цена * количество
    public double GetCost() { return Price * Quantity; }

    // Остаток на складе
    public int GetStock() { return Quantity; }
}

// Бытовая химия
class Chemistry : IProduct
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Chemistry(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public double GetCost() { return Price * Quantity; }
    public int GetStock() { return Quantity; }
}

class Program
{
    static void Main()
    {
        // Массив товаров разных типов 
        IProduct[] products = new IProduct[3];
        products[0] = new Food("Хлеб", 1.5, 20);
        products[1] = new Chemistry("Порошок", 12.0, 5);
        products[2] = new Food("Молоко", 2.0, 15);

        // Вывод информации по каждому товару
        foreach (IProduct p in products)
        {
            Console.WriteLine($"Стоимость: {p.GetCost():F2}, Остаток: {p.GetStock()}");
        }
    }
}