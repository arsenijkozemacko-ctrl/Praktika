using System;
using Microsoft.Data.Sqlite;

namespace Выполнение_задания_2_модуля_9
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=projects.db";

        // 1. Создание базы данных и таблиц
        public void InitializeDatabase()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // Таблица сотрудников
                string sqlEmployees = @"CREATE TABLE IF NOT EXISTS Employees (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                        Name TEXT NOT NULL)";

                // Таблица проектов
                string sqlProjects = @"CREATE TABLE IF NOT EXISTS Projects (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                        Title TEXT NOT NULL)";

                // Таблица задач
                string sqlTasks = @"CREATE TABLE IF NOT EXISTS Tasks (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                    Title TEXT NOT NULL,
                                    ProjectId INTEGER,
                                    EmployeeId INTEGER,
                                    IsCompleted INTEGER DEFAULT 0)";

                using (SqliteCommand cmd = new SqliteCommand(sqlEmployees, conn)) cmd.ExecuteNonQuery();
                using (SqliteCommand cmd = new SqliteCommand(sqlProjects, conn)) cmd.ExecuteNonQuery();
                using (SqliteCommand cmd = new SqliteCommand(sqlTasks, conn)) cmd.ExecuteNonQuery();
            }
        }

        // 2. Добавление сотрудника
        public void AddEmployee(string name)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Employees (Name) VALUES (@name)";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 3. Добавление проекта
        public void AddProject(string title)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Projects (Title) VALUES (@title)";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 4. Добавление задачи (с привязкой к проекту и сотруднику)
        public void AddTask(string title, int projectId, int employeeId)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Tasks (Title, ProjectId, EmployeeId) VALUES (@title, @proj, @emp)";
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@proj", projectId);
                    cmd.Parameters.AddWithValue("@emp", employeeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}