using System;

// Структура — значимый тип для хранения данных о студенте
struct Student
{
    public string Name;      // фамилия и инициалы
    public string Group;     // номер группы
    public int[] Grades;     // массив из 5 оценок

    // Метод расчёта среднего балла
    public double Average()
    {
        int sum = 0;

        // Складываем все оценки
        for (int i = 0; i < Grades.Length; i++)
        {
            sum += Grades[i];
        }

        // Делим сумму на количество оценок
        return (double)sum / Grades.Length;
    }

    // Метод проверки: все оценки только 4 или 5
    public bool OnlyGoodMarks()
    {
        for (int i = 0; i < Grades.Length; i++)
        {
            // Если хоть одна оценка ниже 4 — возвращаем false
            if (Grades[i] < 4) return false;
        }
        return true;
    }

    // Метод вывода информации о студенте
    public void PrintInfo()
    {
        Console.WriteLine($"{Name}, группа {Group}, средний балл: {Average():F2}");
    }
}

class Program
{
    static void Main()
    {
        // Массив из 10 студентов
        Student[] students = new Student[10];
        Random rnd = new Random();

        // Заполняем каждого студента случайными данными
        for (int i = 0; i < 10; i++)
        {
            students[i].Name = "Студент" + (i + 1);
            students[i].Group = "ГР-" + rnd.Next(100, 999);

            // Выделяем память под массив оценок
            students[i].Grades = new int[5];

            // Заполняем оценки случайными значениями от 2 до 5
            for (int j = 0; j < 5; j++)
            {
                students[i].Grades[j] = rnd.Next(2, 6);
            }
        }

        // Сортировка методом "пузырька" по возрастанию среднего балла
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9 - i; j++)
            {
                // Если средний балл текущего больше следующего — меняем местами
                if (students[j].Average() > students[j + 1].Average())
                {
                    Student temp = students[j];
                    students[j] = students[j + 1];
                    students[j + 1] = temp;
                }
            }
        }

        // Вывод отсортированного списка
        Console.WriteLine("Студенты, упорядоченные по среднему баллу:");
        for (int i = 0; i < 10; i++)
        {
            students[i].PrintInfo();
        }

        // Вывод студентов с оценками только 4 и 5
        Console.WriteLine("\nСтуденты с оценками только 4 и 5:");
        for (int i = 0; i < 10; i++)
        {
            if (students[i].OnlyGoodMarks())
            {
                Console.WriteLine($"{students[i].Name}, группа {students[i].Group}");
            }
        }
    }
}