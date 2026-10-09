using System;
using System.Data;
using System.Windows.Forms;

namespace Выполнение_задания_2_модуля_6
{
    public partial class Form1 : Form
    {
        // Создаём объект для работы с базой данных
        private DatabaseHelper db = new DatabaseHelper();

        public Form1()
        {
            InitializeComponent();
        }

        // === Загрузка формы ===
        private void Form1_Load(object sender, EventArgs e)
        {
            db.CreateDatabase();   // создаём БД, если её ещё нет
            LoadTasks();           // загружаем задачи в таблицу
        }

        // === Загрузка задач в DataGridView ===
        private void LoadTasks()
        {
            dataGridView.DataSource = db.GetAllTasks();
        }

        // === Кнопка "Добавить" ===
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Проверяем, что название и статус заполнены
            if (txtTitle.Text == "" || cmbStatus.Text == "")
            {
                MessageBox.Show("Заполните название и статус!");
                return;
            }

            // Добавляем задачу в БД
            db.AddTask(txtTitle.Text, txtDescription.Text, cmbStatus.Text);

            // Очищаем поля ввода
            txtTitle.Clear();
            txtDescription.Clear();
            cmbStatus.SelectedIndex = -1;

            // Обновляем таблицу
            LoadTasks();

            MessageBox.Show("Задача добавлена!");
        }

        // === Кнопка "Обновить" ===
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в таблице
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите задачу!");
                return;
            }

            // Проверяем, что поля заполнены
            if (txtTitle.Text == "" || cmbStatus.Text == "")
            {
                MessageBox.Show("Заполните название и статус!");
                return;
            }

            // Получаем Id выбранной задачи
            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);

            // Обновляем в БД
            db.UpdateTask(id, txtTitle.Text, txtDescription.Text, cmbStatus.Text);

            LoadTasks();
            MessageBox.Show("Задача обновлена!");
        }

        // === Кнопка "Удалить" ===
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите задачу!");
                return;
            }

            // Подтверждение удаления
            DialogResult result = MessageBox.Show(
                "Удалить выбранную задачу?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;

            // Получаем Id и удаляем
            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
            db.DeleteTask(id);

            LoadTasks();
            MessageBox.Show("Задача удалена!");
        }

        // === Клик по строке таблицы — заполняем поля для редактирования ===
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Если кликнули по заголовку — ничего не делаем
            if (e.RowIndex < 0) return;

            // Заполняем поля данными выбранной строки
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            txtTitle.Text = row.Cells["Title"].Value?.ToString();
            txtDescription.Text = row.Cells["Description"].Value?.ToString();
            cmbStatus.Text = row.Cells["Status"].Value?.ToString();
        }
    }
}