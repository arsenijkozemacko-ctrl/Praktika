using System;

// Класс, описывающий автора книги
class Author
{
    public string Name { get; set; }        // имя автора
    public int BirthYear { get; set; }      // год рождения
    // Конструктор — принимает имя и год рождения
    public Author(string name, int birthYear)
    {
        Name = name;
        BirthYear = birthYear;
    }

    // Метод вывода информации об авторе
    public void PrintInfo()
    {
        Console.WriteLine($"Автор: {Name}, год рождения: {BirthYear}");
    }
}
// Класс, описывающий книгу
class Book
{
    public string Title { get; set; }        // название книги
    public int ReleaseYear { get; set; }     // год выпуска

    // Композиция: книга содержит автора как поле
    public Author Author { get; set; }

    // Конструктор — принимает название, год выпуска и объект автора
    public Book(string title, int releaseYear, Author author)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Author = author;
    }
    // Метод вывода информации о книге
    public void PrintInfo()
    {
        Console.WriteLine($"Книга: \"{Title}\", год выпуска: {ReleaseYear}");
        Author.PrintInfo(); // вызов метода автора для вывода его данных
    }
}

class Program
{
    static void Main()
    {
        // Создаём двух авторов
        Author a1 = new Author("Лев Толстой", 1828);
        Author a2 = new Author("Фёдор Достоевский", 1821);

        // Создаём две книги, передавая в них авторов
        Book b1 = new Book("Война и мир", 1861, a1);
        Book b2 = new Book("Преступление и наказание", 1866, a2);

        // Выводим информацию о книгах
        b1.PrintInfo();
        Console.WriteLine(); // пустая строка для разделения
        b2.PrintInfo();
    }
}