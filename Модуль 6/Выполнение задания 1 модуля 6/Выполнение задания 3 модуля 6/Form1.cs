using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Выполнение_задания_3_модуля_6
{
    public partial class Form1 : Form
    {
        // Объект для работы с БД
        private DatabaseHelper db = new DatabaseHelper();

        public Form1()
        {
            InitializeComponent();
        }

        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            db.CreateDatabase();
            LoadBooks();
        }

        // Загрузка книг
        private void LoadBooks()
        {
            dataGridView.DataSource = db.GetAllBooks();
        }

        // Добавить книгу
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" || txtAuthor.Text == "" || txtYear.Text == "" || cmbStatus.Text == "")
            {
                MessageBox.Show("Заролните все поля!");
                return;
            }

            int year;
            if (!int.TryParse(txtYear.Text, out year))
            {
                MessageBox.Show("Год должен быть числом!");
                return;
            }

            db.AddBook(txtTitle.Text, txtAuthor.Text, year, cmbStatus.Text);

            txtTitle.Clear();
            txtAuthor.Clear();
            txtYear.Clear();
            cmbStatus.SelectedIndex = -1;

            LoadBooks();
            MessageBox.Show("Книга добавлена!");
        }


        // Обновить книгу
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }

            int year;
            if (!int.TryParse(txtYear.Text, out year))
            {
                MessageBox.Show("Год должен быть числом!");
                return;
            }

            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
            db.UpdateBook(id, txtTitle.Text, txtAuthor.Text, year, cmbStatus.Text);

            LoadBooks();
            MessageBox.Show("Данные обновлены!");
        }

        // Удалить книгу
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Удалить выбранную книгу?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;

            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
            db.DeleteBook(id);

            LoadBooks();
            MessageBox.Show("Книга удалена!");
        }

        // Поиск
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                LoadBooks();
                return;
            }

            dataGridView.DataSource = db.SearchBooks(txtSearch.Text);
        }

        // Арендовать книгу
        private void btnRent_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }

            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
            db.ChangeStatus(id, "На руках");

            LoadBooks();
            MessageBox.Show("Книга арендована!");
        }

        // Вернуть книгу
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите книгу!");
                return;
            }

            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
            db.ChangeStatus(id, "Доступна");

            LoadBooks();
            MessageBox.Show("Книга возвращена!");
        }

        // Клик по строке в таблице - заполняем поля
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            txtTitle.Text = row.Cells["Title"].Value?.ToString();
            txtAuthor.Text = row.Cells["Author"].Value?.ToString();
            txtYear.Text = row.Cells["Year"].Value?.ToString();
            cmbStatus.Text = row.Cells["Status"].Value?.ToString();
        }

        // Показать все книги (сброс поиска)
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadBooks();
        }
    }
}
