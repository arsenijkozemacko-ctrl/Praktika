using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Выполнение_задания_3_модуля_9
{
    public partial class Form1 : Form
    {
        // Список для хранения задач
        private List<TaskItem> tasks = new List<TaskItem>();

        public Form1()
        {
            InitializeComponent();

            // Начальные настройки
            cmbPriority.SelectedIndex = 1; // "Средний"
            dtpDueDate.Value = DateTime.Now; // Текущая дата
        }

        // 1. Кнопка "Добавить"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название задачи!", "Ошибка");
                return;
            }

            // Создаем задачу
            TaskItem newTask = new TaskItem(txtTitle.Text, cmbPriority.Text, dtpDueDate.Value);
            tasks.Add(newTask);

            UpdateTaskList();
            txtTitle.Clear();
        }

        // 2. Кнопка "Отметить выполненной"
        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите задачу из списка!", "Ошибка");
                return;
            }

            // Меняем статус на противоположный
            tasks[lstTasks.SelectedIndex].IsCompleted = !tasks[lstTasks.SelectedIndex].IsCompleted;
            UpdateTaskList();
        }

        // 3. Кнопка "Удалить"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите задачу из списка!", "Ошибка");
                return;
            }

            tasks.RemoveAt(lstTasks.SelectedIndex);
            UpdateTaskList();
        }

        // Вспомогательный метод для обновления списка на экране
        private void UpdateTaskList()
        {
            lstTasks.Items.Clear();
            foreach (var task in tasks)
            {
                lstTasks.Items.Add(task); // Добавляем задачу (сработает ToString)
            }
            CheckDeadlines(); // Проверяем сроки
        }

        // Проверка на просроченные задачи
        private void CheckDeadlines()
        {
            DateTime today = DateTime.Now.Date;
            int urgentCount = 0;

            foreach (var task in tasks)
            {
                if (!task.IsCompleted && task.DueDate.Date <= today)
                {
                    urgentCount++;
                }
            }

            if (urgentCount > 0)
            {
                lblWarning.Text = $"Внимание! {urgentCount} задач(и) требуют срочного выполнения!";
                lblWarning.ForeColor = Color.Red;
            }
            else
            {
                lblWarning.Text = "Срочных задач нет.";
                lblWarning.ForeColor = Color.Green;
            }
        }
    }
}