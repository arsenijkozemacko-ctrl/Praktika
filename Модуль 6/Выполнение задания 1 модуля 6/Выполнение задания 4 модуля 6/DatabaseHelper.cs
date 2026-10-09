using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Выполнение_задания_4_модуля_6
{
    // Класс для работы с базой данных финансов
    public class DatabaseHelper
    {
        private string dbPath = "finance.db";
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

                string sql = @"CREATE TABLE IF NOT EXISTS Transactions (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Type TEXT NOT NULL,
                                Category TEXT NOT NULL,
                                Amount REAL NOT NULL,
                                Description TEXT
                              )";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Получить все записи 
        public DataTable GetAllTransactions()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT * FROM Transactions";

                DataTable dt = new DataTable();

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }

                return dt;
            }
        }

        // Добавить запись
        public void AddTransaction(string type, string category, double amount, string description)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = "INSERT INTO Transactions (Type, Category, Amount, Description) VALUES (@type, @cat, @amt, @desc)";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@cat", category);
                    cmd.Parameters.AddWithValue("@amt", amount);
                    cmd.Parameters.AddWithValue("@desc", description ?? "");

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Обновить запись 
        public void UpdateTransaction(int id, string type, string category, double amount, string description)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = @"UPDATE Transactions 
                               SET Type = @type, Category = @cat, Amount = @amt, Description = @desc 
                               WHERE Id = @id";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@cat", category);
                    cmd.Parameters.AddWithValue("@amt", amount);
                    cmd.Parameters.AddWithValue("@desc", description ?? "");
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удалить запись 
        public void DeleteTransaction(int id)
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string sql = "DELETE FROM Transactions WHERE Id = @id";

                using (SqliteCommand cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Подсчёт баланса 
        // Возвращает: доходы, расходы, баланс
        public (double income, double expense, double balance) CalculateBalance()
        {
            double income = 0;
            double expense = 0;

            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // Сумма доходов
                using (SqliteCommand cmd = new SqliteCommand("SELECT IFNULL(SUM(Amount), 0) FROM Transactions WHERE Type = 'Доход'", conn))
                {
                    income = Convert.ToDouble(cmd.ExecuteScalar());
                }

                // Сумма расходов
                using (SqliteCommand cmd = new SqliteCommand("SELECT IFNULL(SUM(Amount), 0) FROM Transactions WHERE Type = 'Расход'", conn))
                {
                    expense = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }

            return (income, expense, income - expense);
        }
    }
}