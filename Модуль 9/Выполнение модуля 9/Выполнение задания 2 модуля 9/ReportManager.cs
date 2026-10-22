using System;
using Microsoft.Data.Sqlite;

namespace Module9_Database
{
    public class ReportManager
    {
        private string connectionString = "Data Source=projects.db";

        // Генерация отчета по всем задачам (кто делает, в каком проекте, статус)
        public void PrintFullReport()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // Связываем (JOIN) таблицы задач, проектов и сотрудников
                string sql = @"SELECT t.Title, p.Title, e.Name, t.IsCompleted 
                               FROM Tasks t
                               LEFT JOIN Projects p ON t.ProjectId = p.Id
                               LEFT JOIN Employees e ON t.EmployeeId = e.Id";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\n--- ОТЧЕТ ПО ЗАДАЧАМ ---");
                    Console.WriteLine("Задача | Проект | Сотрудник | Статус");
                    Console.WriteLine("-------------------------------------------------");

                    while (reader.Read())
                    {
                        string task = reader.GetString(0);
                        string project = reader.IsDBNull(1) ? "Нет" : reader.GetString(1);
                        string employee = reader.IsDBNull(2) ? "Не назначен" : reader.GetString(2);
                        string status = reader.GetInt32(3) == 1 ? "Выполнена" : "В работе";

                        Console.WriteLine($"{task} | {project} | {employee} | {status}");
                    }
                }
            }
        }
    }
}