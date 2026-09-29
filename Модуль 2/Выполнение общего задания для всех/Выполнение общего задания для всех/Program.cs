using System;

// Класс, представляющий человека
class Person
{
    // Закрытые поля — доступны только внутри класса (инкапсуляция)
    private string name;      // имя человека
    private int age;          // возраст человека
    private string address;   // адрес человека

    // Методы установки значений (сеттеры)
    public void SetName(string n) { name = n; }             
    public void SetAge(int a) { age = a; }                 
    public void SetAddress(string adr) { address = adr; }  

    // Методы получения значений (геттеры)
    public string GetName() { return name; }        
    public int GetAge() { return age; }             
    public string GetAddress() { return address; }  

    // Метод для вывода информации о человеке
    public void PrintInfo()
    {
        // Вывод значений полей через интерполяцию строк
        Console.WriteLine($"Имя: {name}, Возраст: {age}, Адрес: {address}");
    }
}

class Program
{
    static void Main()
    {
        // Создаём первый объект класса Person
        Person p1 = new Person();
        p1.SetName("Иван");                                      
        p1.SetAge(25);                                          
        p1.SetAddress("г. Минск, ул. Ленина, д. 10");            

        // Создаём второй объект класса Person
        Person p2 = new Person();
        p2.SetName("Мария");                                    
        p2.SetAge(30);                                           
        p2.SetAddress("г. Гомель, ул. Советская, д. 5");        
        // Создаём третий объект класса Person
        Person p3 = new Person();
        p3.SetName("Дмитрий");                                  
        p3.SetAge(50);                                           
        p3.SetAddress("г. Орша, ул. Студенческая, д. 5");        
        // Выводим информацию о каждом человеке
        p1.PrintInfo();
        p2.PrintInfo();
        p3.PrintInfo();
    }
}