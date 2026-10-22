#nullable disable
using System;

namespace Выполнение_задания_1_модуля_9
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            string filePath = "students.txt";

            // Загружаем данные при запуске
            manager.Load(filePath);

            while (true)
            {
                Console.WriteLine("\n--- УПРАВЛЕНИЕ СТУДЕНТАМИ ---");
                Console.WriteLine("1. Показать всех");
                Console.WriteLine("2. Добавить студента");
                Console.WriteLine("3. Удалить студента");
                Console.WriteLine("4. Сохранить в файл");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    ShowList(manager.Students);
                }
                else if (choice == "2")
                {
                    Console.Write("Имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Возраст: ");
                    int age = int.Parse(Console.ReadLine());
                    Console.Write("Средний балл: ");
                    double grade = double.Parse(Console.ReadLine());

                    manager.Add(name, age, grade);
                    Console.WriteLine("Студент успешно добавлен!");
                }
                else if (choice == "3")
                {
                    ShowList(manager.Students);
                    Console.Write("Введите номер для удаления: ");
                    int index = int.Parse(Console.ReadLine()) - 1; // -1, т.к. индексы с 0
                    manager.Remove(index);
                    Console.WriteLine("Студент удален!");
                }
                else if (choice == "4")
                {
                    manager.Save(filePath);
                    Console.WriteLine("Данные сохранены в файл students.txt!");
                }
                else if (choice == "0")
                {
                    manager.Save(filePath); // Автосохранение при выходе
                    break;
                }
            }
        }

        // Вспомогательный метод для вывода списка на экран
        static void ShowList(System.Collections.Generic.List<Student> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Name} | Возраст: {list[i].Age} | Балл: {list[i].Grade}");
            }
        }
    }
}