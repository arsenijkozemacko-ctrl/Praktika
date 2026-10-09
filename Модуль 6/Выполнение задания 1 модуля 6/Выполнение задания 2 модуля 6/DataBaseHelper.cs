using System;
using System.Data;
using Microsoft.Data.Sqlite;   // пакет Microsoft.Data.Sqlite

namespace Выполнение_задания_2_модуля_6
{
    // Класс для работы с базой данных задач
    public class DatabaseHelper
    {
        private string dbPath = "tasks.db";      // путь к файлу БД
        private string connectionString;         // строка подключения

        public DatabaseHelper()
        {
            // Строка подключения для Microsoft.Data.Sqlite
            connectionString = $"Data Source={dbPath}";
        }

        // Создание БД и таблицы 
        public void CreateDatabase()
        {
            // Файл .db создастся автоматически при первом Open()
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // SQL-запрос на создание таблицы, если её нет
                string sql = @"CREATE TABLE IF NOT EXISTS Tasks (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Title TEXT NOT NULL,
                                Description TEXT,
                                Status TEXT NOT NULL
                              )";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Получить все задачи 
        public DataTable GetAllTasks()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM Tasks";

                DataTable dt = new DataTable();

                // Используем SqliteDataReader, потому что DataAdapter в этом пакете нет
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);  // загружаем данные из reader в DataTable
                }

                return dt;
            }
        }

        // Добавить задачу
        public void AddTask(string title, string description, string status)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // SQL-запрос на добавление записи
                string sql = "INSERT INTO Tasks (Title, Description, Status) VALUES (@title, @desc, @status)";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    // Параметры защищают от SQL-инъекций
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@status", status);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Обновить задачу 
        public void UpdateTask(int id, string title, string description, string status)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = @"UPDATE Tasks 
                               SET Title = @title, Description = @desc, Status = @status 
                               WHERE Id = @id";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удалить задачу
        public void DeleteTask(int id)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = "DELETE FROM Tasks WHERE Id = @id";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}