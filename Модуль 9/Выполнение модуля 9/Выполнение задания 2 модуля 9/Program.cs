#nullable disable
using System;
using Выполнение_задания_2_модуля_9;

namespace Module9_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper db = new DatabaseHelper();
            ReportManager reporter = new ReportManager();

            // Создаем базу и таблицы при запуске
            db.InitializeDatabase();

            while (true)
            {
                Console.WriteLine("\n--- УПРАВЛЕНИЕ ПРОЕКТАМИ (БД) ---");
                Console.WriteLine("1. Добавить сотрудника");
                Console.WriteLine("2. Добавить проект");
                Console.WriteLine("3. Добавить задачу (назначить сотруднику)");
                Console.WriteLine("4. Показать отчет по задачам");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Имя сотрудника: ");
                    db.AddEmployee(Console.ReadLine());
                    Console.WriteLine("Сотрудник добавлен.");
                }
                else if (choice == "2")
                {
                    Console.Write("Название проекта: ");
                    db.AddProject(Console.ReadLine());
                    Console.WriteLine("Проект добавлен.");
                }
                else if (choice == "3")
                {
                    Console.Write("Название задачи: ");
                    string title = Console.ReadLine();

                    Console.Write("ID проекта (цифра): ");
                    int projId = int.Parse(Console.ReadLine());

                    Console.Write("ID сотрудника (цифра): ");
                    int empId = int.Parse(Console.ReadLine());

                    db.AddTask(title, projId, empId);
                    Console.WriteLine("Задача создана и назначена!");
                }
                else if (choice == "4")
                {
                    reporter.PrintFullReport();
                }
                else if (choice == "0")
                {
                    break;
                }
            }
        }
    }
}