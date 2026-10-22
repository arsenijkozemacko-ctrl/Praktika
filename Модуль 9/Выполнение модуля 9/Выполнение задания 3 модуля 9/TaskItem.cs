using System;
namespace Выполнение_задания_3_модуля_9
{
    public class TaskItem
    {
        public string Title { get; set; }
        public string Priority { get; set; }
        public System.DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string title, string priority, System.DateTime dueDate)
        {
            Title = title;
            Priority = priority;
            DueDate = dueDate;
            IsCompleted = false;
        }

        public override string ToString()
        {
            string status = IsCompleted ? "[V] " : "[ ] ";
            return $"{status}{Title} | Приоритет: {Priority} | До: {DueDate:dd.MM.yyyy}";
        }
    }
}