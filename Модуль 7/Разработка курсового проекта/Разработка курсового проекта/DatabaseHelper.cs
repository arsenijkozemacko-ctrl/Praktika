#nullable disable
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Разработка_курсового_проекта
{
    // Класс, представляющий одну идеологию (модель данных)
    public class Ideology
    {
        public int Id { get; set; }           // Уникальный идентификатор (первичный ключ)
        public string Name { get; set; }      // Название идеологии
        public string CoreValues { get; set; } // Базовые ценности
        public string RoleOfState { get; set; } // Роль государства
        public string Economy { get; set; }    // Экономическая модель
        public string Countries { get; set; }  // Страны-представители
        public string KeyFigures { get; set; } // Личности (ключевые фигуры) - НОВОЕ ПОЛЕ
    }

    // Класс для работы с базой данных SQLite
    public class DatabaseHelper
    {
        // Строка подключения к файлу базы данных (создаётся в папке с программой)
        private string connectionString = "Data Source=ideologies.db;Version=3;";

        // Конструктор. При создании объекта автоматически создаёт БД и добавляет примеры
        public DatabaseHelper()
        {
            CreateDatabase();           // Создание таблицы, если её нет
            AddSampleDataIfEmpty();     // Добавление примеров, если таблица пустая
        }

        // Создание таблицы Ideologies в базе данных, если она ещё не существует
        private void CreateDatabase()
        {
            try
            {
                // Открытие подключения к БД
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // SQL-запрос для создания таблицы
                    // Добавлен столбец KeyFigures
                    string sql = @"CREATE TABLE IF NOT EXISTS Ideologies (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE,
                        CoreValues TEXT NOT NULL,
                        RoleOfState TEXT NOT NULL,
                        Economy TEXT NOT NULL,
                        Countries TEXT,
                        KeyFigures TEXT
                    )";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery(); // Выполнение запроса
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка БД: " + ex.Message);
            }
        }

        // Добавление примеров идеологий, если таблица пустая
        private void AddSampleDataIfEmpty()
        {
            List<Ideology> existing = GetAll();
            if (existing.Count > 0) return;

            // Добавление 6 примеров идеологий с указанием личностей
            Add(new Ideology
            {
                Name = "Либерализм",
                CoreValues = "Свобода, права человека, равенство возможностей",
                RoleOfState = "Минимальная (ночной сторож)",
                Economy = "Рыночная",
                Countries = "США, Великобритания",
                KeyFigures = "Джон Локк, Адам Смит, Джон Стюарт Милль"
            });

            Add(new Ideology
            {
                Name = "Консерватизм",
                CoreValues = "Традиции, порядок, стабильность, семья",
                RoleOfState = "Сильное государство",
                Economy = "Рыночная",
                Countries = "Великобритания, Россия",
                KeyFigures = "Эдмунд Бёрк, Отто фон Бисмарк, Жозеф де Местр"
            });

            Add(new Ideology
            {
                Name = "Социализм",
                CoreValues = "Равенство, справедливость, коллективизм",
                RoleOfState = "Активное регулирование",
                Economy = "Смешанная",
                Countries = "Швеция, Норвегия, Дания",
                KeyFigures = "Клод Анри Сен-Симон, Роберт Оуэн, Фердинанд Лассаль"
            });

            Add(new Ideology
            {
                Name = "Коммунизм",
                CoreValues = "Полное равенство, уничтожение классов, общая собственность",
                RoleOfState = "Тотальное (диктатура пролетариата)",
                Economy = "Плановая",
                Countries = "СССР, Китай, Куба",
                KeyFigures = "Карл Маркс, Фридрих Энгельс, Владимир Ленин"
            });

            Add(new Ideology
            {
                Name = "Анархизм",
                CoreValues = "Свобода, отрицание государства, самоуправление",
                RoleOfState = "Отсутствует",
                Economy = "Различные формы",
                Countries = "Испания (1936), Украина",
                KeyFigures = "Михаил Бакунин, Пётр Кропоткин, Эррико Малатеста"
            });

            Add(new Ideology
            {
                Name = "Фашизм",
                CoreValues = "Нация превыше всего, культ вождя, милитаризм",
                RoleOfState = "Тотальное",
                Economy = "Корпоративная",
                Countries = "Италия (Муссолини), Германия",
                KeyFigures = "Бенито Муссолини, Адольф Гитлер, Альфредо Рокко"
            });
        }

        // Получение списка всех идеологий из базы данных
        public List<Ideology> GetAll()
        {
            List<Ideology> list = new List<Ideology>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    // Выбор всех записей, включая KeyFigures
                    string sql = "SELECT Id, Name, CoreValues, RoleOfState, Economy, Countries, KeyFigures FROM Ideologies";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Ideology
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                CoreValues = reader.GetString(2),
                                RoleOfState = reader.GetString(3),
                                Economy = reader.GetString(4),
                                Countries = reader.IsDBNull(5) ? "" : reader.GetString(5),
                                KeyFigures = reader.IsDBNull(6) ? "" : reader.GetString(6) // НОВОЕ ПОЛЕ
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
            return list;
        }

        // Добавление новой идеологии в базу данных
        public void Add(Ideology ideo)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                // Добавлен параметр KeyFigures
                string sql = @"INSERT INTO Ideologies (Name, CoreValues, RoleOfState, Economy, Countries, KeyFigures) 
                               VALUES (@Name, @CoreValues, @RoleOfState, @Economy, @Countries, @KeyFigures)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", ideo.Name);
                    cmd.Parameters.AddWithValue("@CoreValues", ideo.CoreValues);
                    cmd.Parameters.AddWithValue("@RoleOfState", ideo.RoleOfState);
                    cmd.Parameters.AddWithValue("@Economy", ideo.Economy);
                    cmd.Parameters.AddWithValue("@Countries", ideo.Countries ?? "");
                    cmd.Parameters.AddWithValue("@KeyFigures", ideo.KeyFigures ?? ""); // НОВОЕ ПОЛЕ
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Обновление существующих идеологий в базе данных
        public void Update(Ideology ideo)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                // Добавлен параметр KeyFigures
                string sql = @"UPDATE Ideologies SET Name=@Name, CoreValues=@CoreValues, RoleOfState=@RoleOfState, 
                               Economy=@Economy, Countries=@Countries, KeyFigures=@KeyFigures WHERE Id=@Id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", ideo.Id);
                    cmd.Parameters.AddWithValue("@Name", ideo.Name);
                    cmd.Parameters.AddWithValue("@CoreValues", ideo.CoreValues);
                    cmd.Parameters.AddWithValue("@RoleOfState", ideo.RoleOfState);
                    cmd.Parameters.AddWithValue("@Economy", ideo.Economy);
                    cmd.Parameters.AddWithValue("@Countries", ideo.Countries ?? "");
                    cmd.Parameters.AddWithValue("@KeyFigures", ideo.KeyFigures ?? ""); // НОВОЕ ПОЛЕ
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удаление идеологии из базы данных по Id
        public void Delete(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Ideologies WHERE Id=@Id";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}