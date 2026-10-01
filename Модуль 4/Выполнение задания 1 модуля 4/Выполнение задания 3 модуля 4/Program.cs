using System;

// Интерфейс "Студент" - общий контракт
interface IStudent
{
    double GetAverage(); // средний балл
    string GetCourse(); // информация о курсе
}

// Студент бакалавриата
class Bachelor : IStudent
{
    public string Name { get; set; } // имя
    public int[] Grades { get; set; } // массив оценок
    public int Course { get; set; } // номер курса

    public Bachelor(string name, int[] grades, int course)
    {
        Name = name;
        Grades = grades;
        Course = course;
    }

    // Средний балл = сумма оценок / колучество
    public double GetAverage()
    {
        int sum = 0;
        for (int i = 0; i < Grades.Length; i++) sum += Grades[i];
        return (double)sum / Grades.Length; // приведение к double
    }

    public string GetCourse() { return $"Бакалавриат, {Course} курс";}
}

// Студен магистратуры
class Master : IStudent
{
    public string Name { get; set; }
    public int[] Grades { get; set; }
    public int Course { get; set; }

    public Master(string name, int[] grades, int course)
    {
        Name = name;
        Grades = grades;
        Course = course;
    }

    public double GetAverage()
    {
        int sum = 0;
        for (int i = 0; i < Grades.Length; i++) sum += Grades[i];
        return (double)sum / Grades.Length;
    }

    public string GetCourse() { return $"Магистратура, {Course} курс"; }
}

class Program
{
    static void Main()
    {
        // Массив студентов разных типов
        IStudent[] students = new IStudent[2];
        students[0] = new Bachelor("Иван", new int[] { 5, 4, 5, 3, 4 }, 3);
        students[1] = new Master("Мария", new int[] { 5, 5, 4, 5, }, 1);

       foreach (IStudent s in students)
        {
            Console.WriteLine($"{s.GetCourse()}, средний балл: {s.GetAverage():F2}");
        }
    }
}