using System.Collections.Generic;

namespace Выполнение_задания_3_модуля_5
{
   // Класс для урпавления списком задач
   public class TaskManager
    {
        // Список задач
        private List<TaskItem> tasks = new List<TaskItem>();

        // Добавить задачу
        public void Add(string title)
        {
            tasks.Add(new TaskItem(title));
        }

        // Удалить задачу по индексу
        public void RemoveAt(int index)
        {
            if (index >= 0  && index < tasks.Count)
                tasks.RemoveAt(index);
        }

        // Отметить задачу выполненной
        public void MarkDone(int index)
        {
            if ( index >= 0 && index < tasks.Count)
                tasks[index].IsDone = true;
        }

        // Получить список задач
        public List<TaskItem> GetAll()
        {
            return tasks;
        }

        // Сколько задач
        public int Count
        {
            get { return tasks.Count; }
        }
    }
}
