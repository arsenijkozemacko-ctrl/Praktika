using System;

class Car
{
    //Автосвойства для хранения данных об автомобиле
    public string Brand { get; set; } // Марка
    public string Model { get; set; } // Модель
    public int Year { get; set; } // Год выпуска
    public double Price { get; set; } // Цена

    // Конструктор - вызывается при создании объекта
    public Car(string brand , string model, int year, double price)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Price = price;
    }

    //Метод расчёта со скидкой
    public double GetPriceWithDiscount(double discountPecent)
    {
        // Из цены вычитаем процент скидки
        return Price - (Price * discountPecent / 100);
    }

    // Метод расчёта цены с НДС
    public double GetPriceWithVAT(double vatPercent)
    {
        // К цене прибавляем процент НДС
        return Price + (Price * vatPercent / 100);
    }

    // Метод вывода информации об автомобиле
    public void PrintInfo()
    {
        Console.WriteLine($"{Brand} {Model}, {Year}г., базовая цена: {Price}руб.");
    }
}

class Program
{
    static void Main()
    {
        //Создание объект автомобиля
        Car car = new Car("Toyota", "Camry", 2020, 30000);

        //Выводим базовую информацию
        car.PrintInfo();

        //Считаем выводим цену со скидкой 10%
        Console.WriteLine($"Цена со скидкой 10%: {car.GetPriceWithDiscount(10):F2}руб.");

        // Считаем и выводим цену с НДС 20%
        Console.WriteLine($"Цена с НДС 20%: {car.GetPriceWithVAT(20):F2}руб.");
    }
}