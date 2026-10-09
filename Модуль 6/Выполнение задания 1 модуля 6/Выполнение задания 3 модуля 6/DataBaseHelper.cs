using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Выполнение_задания_3_модуля_6
{
    // Класс для работы с базой данных библиотеки
    public class DatabaseHelper
    {
        private string dbPath = "library.db";
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = $"Data Source={dbPath}";
        }

        // Создание БД и таблицы 
        public void CreateDatabase()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = @"CREATE TABLE IF NOT EXISTS Books (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Author TEXT NOT NULL,
                Year INTEGER NOT NULL,
                Status TEXT NOT NULL      -- ← проверь здесь
              )";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Получить все книги 
        public DataTable GetAllBooks()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM Books";

                DataTable dt = new DataTable();

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }

                return dt;
            }
        }

        // Добавить книгу 
        public void AddBook(string title, string author, int year, string status)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = "INSERT INTO Books (Title, Author, Year, Status) VALUES (@title, @author, @year, @status)";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@status", status);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Обновить книгу
        public void UpdateBook(int id, string title, string author, int year, string status)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = @"UPDATE Books 
               SET Title = @title, Author = @author, Year = @year, Status = @status 
               WHERE Id = @id";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удалить книгу 
        public void DeleteBook(int id)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = "DELETE FROM Books WHERE Id = @id";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Поиск книг по названию или автору 
        public DataTable SearchBooks(string query)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // LIKE с % — ищет совпадения по части строки
                string sql = "SELECT * FROM Books";

                DataTable dt = new DataTable();

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@q", "%" + query + "%");
                    
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }

                return dt;
            }
        }

        // Изменить статус книги (аренда / возврат)
        public void ChangeStatus(int id, string newStatus)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = "UPDATE Books SET Status = @status WHERE Id = @id";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}