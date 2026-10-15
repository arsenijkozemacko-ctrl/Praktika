namespace Выполнение_задания_3_модуля_5
{
    // Класс, описывающий одну задачу
    public class TaskItem
    {
        public string Title { get; set; } // название задачи
        public bool IsDone { get; set; } // выполнена ли данная задача

        // Конструктор
        public TaskItem(string title)
        {
            Title = title;
            IsDone = false;
        }

        // Переопределяем ToString, чтобы listBox показывал задачу красиво
        public override string ToString()
        {
            return IsDone ? "[✔]" + Title : Title;
        }
    }
}
