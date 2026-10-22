namespace Выполнение_задания_1_модуля_9
{
    // Класс, описывающий одного студента (модель данных)
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

        public Student(string name, int age, double grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }
    }
}