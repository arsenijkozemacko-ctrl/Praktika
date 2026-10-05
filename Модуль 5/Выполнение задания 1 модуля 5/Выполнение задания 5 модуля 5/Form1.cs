using System;
using System.Data;              // для DataTable — вычисление выражений
using System.Windows.Forms;

namespace Выполнение_задания_5_модуля_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ОБЩИЙ ОБРАБОТЧИК ДЛЯ ВСЕХ 17 КНОПОК 
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Определяем нажатую кнопку
            Button btn = (Button)sender;
            string text = btn.Text;

            // === Кнопка "C" — очистка ===
            if (text == "С" || text == "C")
            {
                txtDisplay.Text = "";
                return;
            }

            // Кнопка "=" — вычисление
            if (text == "=")
            {
                try
                {
                    // Заменяем юникодный минус на обычный (для вычислений)
                    string expr = txtDisplay.Text.Replace("−", "-");

                    // Считаем выражение через DataTable
                    var result = new DataTable().Compute(expr, null);

                    // Показываем результат
                    txtDisplay.Text = result.ToString();
                }
                catch
                {
                    txtDisplay.Text = "Ошибка";
                }
                return;
            }

            // Все остальные кнопки — просто добавляем текст в дисплей
            txtDisplay.Text += text;
        }
    }
}