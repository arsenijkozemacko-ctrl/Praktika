using System;
using System.Data;
using System.Windows.Forms;
namespace Выполнение_задания_4_модуля_6
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
            LoadTransactions();
        }

        // Загрузка записей
        private void LoadTransactions()
        {
            dataGridView.DataSource = db.GetAllTransactions();
        }

        // Добавить запись 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbType.Text == "" || txtCategory.Text == "" || txtAmount.Text == "")
            {
                MessageBox.Show("Заполните тип, категорию и сумму!");
                return;
            }

            double amount;
            if (!double.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Сумма должна быть положительным числом!");
                return;
            }

            db.AddTransaction(cmbType.Text, txtCategory.Text, amount, txtDescription.Text);

            // Очищаем поля
            txtCategory.Clear();
            txtAmount.Clear();
            txtDescription.Clear();
            cmbType.SelectedIndex = -1;

            LoadTransactions();
            MessageBox.Show("Запись добавлена!");
        }

        // Обновить запись 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }

            double amount;
            if (!double.TryParse(txtAmount.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Сумма должна быть положительным числом!");
                return;
            }

            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);

            db.UpdateTransaction(id, cmbType.Text, txtCategory.Text, amount, txtDescription.Text);

            LoadTransactions();
            MessageBox.Show("Запись обновлена!");
        }

        // Удалить запись 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Удалить выбранную запись?",
                "Подтверждение",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;

            int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["Id"].Value);
            db.DeleteTransaction(id);

            LoadTransactions();
            MessageBox.Show("Запись удалена!");
        }

        // Подсчёт баланса 
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var (income, expense, balance) = db.CalculateBalance();

            lblBalance.Text = $"Доходы: {income:F2} руб. | Расходы: {expense:F2} руб. | Баланс: {balance:F2} руб.";
        }

        // Клик по строке — заполняем поля 
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
            cmbType.Text = row.Cells["Type"].Value?.ToString();
            txtCategory.Text = row.Cells["Category"].Value?.ToString();
            txtAmount.Text = row.Cells["Amount"].Value?.ToString();
            txtDescription.Text = row.Cells["Description"].Value?.ToString();
        }
    }
}