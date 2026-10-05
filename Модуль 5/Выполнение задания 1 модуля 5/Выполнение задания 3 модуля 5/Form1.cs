using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Выполнение_задания_3_модуля_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // кнопка "Добавить"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Проверяем, что поле не пустое
            if (txtTask.Text.Trim() != "")
            {
                // Добавляем задачу в список
                IstTasks.Items.Add(txtTask.Text);

                // Очищаем поле ввода для следующей задачи
                txtTask.Clear();
            }
            else
            {
                MessageBox.Show("Ввдеите текст задачи!");
            }
            
        }

        // Кнопка "Удалить"
        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Проверяем, что задача выбрана
            if(IstTasks.SelectedIndex !=-1)
            {
                // Удаляем выбранный элемент
                IstTasks.Items.RemoveAt(IstTasks.SelectedIndex);
            }
            else
            {
                MessageBox.Show("выберите задачу для удаления!");
            }
        }

        // Кнопка "Выполнено"
        private void btnDone_Click(object sender, EventArgs e)
        {
            // Проверяем что задача выбрана
            if (IstTasks.SelectedIndex != -1)
            {
                // Получаем текущий текст задачи
                string task = IstTasks.Items[IstTasks.SelectedIndex].ToString();

                // Если задача ещё не помечена - помечаем 
                if (!task.StartsWith("✔"))
                {
                    IstTasks.Items[IstTasks.SelectedIndex] = "✔" + task;
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу!");
            }
        }
    }
}
