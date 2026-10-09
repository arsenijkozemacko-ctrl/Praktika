using System;                   // базовые типы (Convert, double)
using System.Data;              // для DataTable
using System.Windows.Forms;     // для формы и её элементов

namespace Выполнение_задания_1_модуля_6
{
    // Частичный класс формы (вторая часть — в Form1.Designer.cs)
    public partial class Form1 : Form
    {
        // Создаём объект для работы с базой данных
        private DatabaseHelper db = new DatabaseHelper();

        // Конструктор формы — вызывается при запуске
        public Form1()
        {
            InitializeComponent(); // создаёт все элементы на форме
        }

        // Событие загрузки формы
        // Вызывается, когда форма появляется на экране
        private void Form1_Load(object sender, EventArgs e)
        {
            db.CreateDatabase();  // создаём БД и таблицу, если их ещё нет
            LoadEmployees();      // загружаем список сотрудников в таблицу
        }

        // Загрузка сотрудников в DataGridView
        private void LoadEmployees()
        {
            // Получаем данные из БД и привязываем их к таблице
            dataGridView.DataSource = db.GetAllEmployees();
        }

        // Кнопка "Добавить"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (txtName.Text == "" || txtPosition.Text == "" || txtSalary.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
                return; // выходим из метода, если что-то не заполнено
            }

            // Пробуем преобразовать зарплату в число
            double salary;
            if (!double.TryParse(txtSalary.Text, out salary))
            {
                MessageBox.Show("Зарплата должна быть числом!");
                return;
            }

            // Добавляем сотрудника через DatabaseHelper
            db.AddEmployee(txtName.Text, txtPosition.Text, salary);

            // Очищаем поля ввода
            txtName.Clear();
            txtPosition.Clear();
            txtSalary.Clear();

            // Обновляем таблицу на форме
            LoadEmployees();

            // Уведомляем пользователя
            MessageBox.Show("Сотрудник добавлен!");
        }

        // Кнопка "Обновить"
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в таблице
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            // Получаем Id выбранной строки из столбца "Id"
            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);

            // Проверяем зарплату
            double salary;
            if (!double.TryParse(txtSalary.Text, out salary))
            {
                MessageBox.Show("Зарплата должна быть числом!");
                return;
            }

            // Обновляем запись в БД
            db.UpdateEmployee(id, txtName.Text, txtPosition.Text, salary);

            // Обновляем таблицу
            LoadEmployees();

            MessageBox.Show("Данные обновлены!");
        }

        // Кнопка "Удалить"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника!");
                return;
            }

            // Спрашиваем подтверждение у пользователя
            DialogResult result = MessageBox.Show(
                "Удалить выбранного сотрудника?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            // Если пользователь нажал "Нет" — выходим
            if (result == DialogResult.No) return;

            // Получаем Id выбранной строки
            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);

            // Удаляем запись из БД
            db.DeleteEmployee(id);

            // Обновляем таблицу
            LoadEmployees();

            MessageBox.Show("Сотрудник удалён!");
        }
    }
}