using System.Collections.Generic;
using System.IO;

namespace Выполнение_задания_1_модуля_9
{
    // Класс для управления списком студентов
    public class StudentManager
    {
        // Список, где хранятся студенты
        public List<Student> Students = new List<Student>();

        // 1. Добавление
        public void Add(string name, int age, double grade)
        {
            Students.Add(new Student(name, age, grade));
        }

        // 2. Удаление по индексу
        public void Remove(int index)
        {
            if (index >= 0 && index < Students.Count)
            {
                Students.RemoveAt(index);
            }
        }

        // 3. Сохранение в файл
        public void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var s in Students)
                {
                    // Записываем через точку с запятой: Имя;Возраст;Балл
                    sw.WriteLine(s.Name + ";" + s.Age + ";" + s.Grade);
                }
            }
        }

        // 4. Загрузка из файла
        public void Load(string path)
        {
            if (!File.Exists(path)) return; // Если файла нет — ничего не делаем

            Students.Clear();
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 3)
                {
                    string name = parts[0];
                    int age = int.Parse(parts[1]);
                    double grade = double.Parse(parts[2]);
                    Students.Add(new Student(name, age, grade));
                }
            }
        }
    }
}