using System;
using System.Windows.Forms;

namespace Выполнение_задания_3_модуля_5
{
    public partial class Form1 : Form
    {
        // Объект класса TaskManager
        private TaskManager manager = new TaskManager();

        public Form1()
        {
            InitializeComponent();
        }

        // Кнопка "Добавить" 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Проверяем, что поле не пустое
            if (txtTask.Text.Trim() == "")
            {
                MessageBox.Show("Введите текст задачи!");
                return;
            }

            // Добавляем задачу
            manager.Add(txtTask.Text);

            // Обновляем список
            RefreshList();

            // Очищаем поле
            txtTask.Clear();
        }

        // Кнопка "Удалить" 
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (LstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите задачу!");
                return;
            }

            manager.RemoveAt(LstTasks.SelectedIndex);
            RefreshList();
        }

        // Кнопка "Выполнено"
        private void btnDone_Click(object sender, EventArgs e)
        {
            if (LstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите задачу!");
                return;
            }

            manager.MarkDone(LstTasks.SelectedIndex);
            RefreshList();
        }

        // Обновление ListBox 
        private void RefreshList()
        {
            LstTasks.Items.Clear();

            foreach (TaskItem task in manager.GetAll())
            {
                LstTasks.Items.Add(task);   // вызовется ToString()
            }
        }
    }
}