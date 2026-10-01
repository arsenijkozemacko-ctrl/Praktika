using System;
using System.Security.Cryptography.X509Certificates;

// Интерфей "Книга" - общий контракт
interface IBook
{
    bool IsAvailable(); // проверка доступности
    string GetBookInfo(); // информация о книге
}

// Художественная литература
class FictionBook : IBook
{
    public string Title { get; set; } // название книги
    public string Author { get; set; } // автор книги
    public bool Available { get; set; } // доступность

    public FictionBook(string title, string author, bool available)
    {
        Title = title;
        Author = author;
        Available = available;
    }

    public bool IsAvailable() { return Available; }

    public string GetBookInfo()
    {
        return $"Художественная: \"{Title}\" - {Author}";
    }
}

// Учебник
class TextBook : IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool Available { get; set; }

    public TextBook(string title, string author, bool available)
    {
        Title = title;
        Author = author;
        Available = available;
    }

    public bool IsAvailable() { return Available; }

    public string GetBookInfo()
    {
        return $"Учебник: \"{Title}\" - {Author}";
    }
}

class Program
{
    static void Main()
    {
        // Массив книг разных типов
        IBook[] books = new IBook[3];
        books[0] = new FictionBook("Война и мир", "Л. Толстой", true);
        books[1] = new TextBook("Алгебра 9 класс", "Макарычев", false);
        books[2] = new FictionBook("Претупление и наказание ", "Ф. Достоевский", true);

        // Обход всех книг
        foreach (IBook b in  books)
        {
            string status = b.IsAvailable() ? "доступна" : "выдана";
            Console.WriteLine($"{b.GetBookInfo()} - {status}");
        }
    }
}