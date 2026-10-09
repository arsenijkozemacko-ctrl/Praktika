using System;                          // для базовых типов (string, int, double)
using System.Data;                     // для DataTable
using Microsoft.Data.Sqlite;           // для работы с SQLite (SqliteConnection, SqliteCommand, SqliteDataReader)

namespace Выполнение_задания_1_модуля_6
{
    // Класс для работы с базой данных SQLite
    public class DatabaseHelper
    {
        // Путь к файлу базы данных (создастся рядом с .exe)
        private string dbPath = "employees.db";

        // Строка подключения к базе
        private string connectionString;

        // Конструктор — формирует строку подключения
        public DatabaseHelper()
        {
            connectionString = $"Data Source={dbPath}";
        }

        // Создание базы данных и таблицы
        public void CreateDatabase()
        {
            // Открываем подключение к БД
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // SQL-запрос на создание таблицы, если её ещё нет
                string sql = @"CREATE TABLE IF NOT EXISTS Employees (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Name TEXT NOT NULL,
                                Position TEXT NOT NULL,
                                Salary REAL NOT NULL
                              )";

                // Выполняем SQL-запрос
                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery(); // для CREATE/INSERT/UPDATE/DELETE
                }
            }
        }

        // Получить всех сотрудников
        public DataTable GetAllEmployees()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // SQL-запрос на выборку всех записей
                string sql = "SELECT * FROM Employees";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                using (SqliteDataReader reader = cmd.ExecuteReader()) // выполняем запрос и получаем читатель
                {
                    DataTable dt = new DataTable();

                    // Загружаем данные из читателя в таблицу
                    dt.Load(reader);

                    // Возвращаем таблицу в форму
                    return dt;
                }
            }
        }

        // Добавить сотрудника
        public void AddEmployee(string name, string position, double salary)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // SQL-запрос на вставку новой записи
                // Параметры @name, @pos, @sal — защита от SQL-инъекций
                string sql = "INSERT INTO Employees (Name, Position, Salary) VALUES (@name, @pos, @sal)";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    // Подставляем значения в параметры
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@pos", position);
                    cmd.Parameters.AddWithValue("@sal", salary);

                    // Выполняем запрос
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Обновить данные сотрудника 
        public void UpdateEmployee(int id, string name, string position, double salary)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // SQL-запрос на обновление записи по Id
                string sql = @"UPDATE Employees 
                               SET Name = @name, Position = @pos, Salary = @sal 
                               WHERE Id = @id";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@pos", position);
                    cmd.Parameters.AddWithValue("@sal", salary);
                    cmd.Parameters.AddWithValue("@id", id); // Id сотрудника, которого обновляем

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удалить сотрудника
        public void DeleteEmployee(int id)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // SQL-запрос на удаление записи по Id
                string sql = "DELETE FROM Employees WHERE Id = @id";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id); // Id сотрудника, которого удаляем
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}