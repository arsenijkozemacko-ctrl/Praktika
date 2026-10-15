#nullable disable
using System;
using System.Windows.Forms;

namespace Выполнение_задания_5_модуля_5
{
    public partial class Form1 : Form
    {
        private double firstNumber = 0;
        private Operation operation = null;
        private bool newInput = true;

        public Form1()
        {
            InitializeComponent();
        }

        // ОБЩИЙ ОБРАБОТЧИК ДЛЯ ВСЕХ КНОПОК
        private void btnClear_Click(object sender, EventArgs e)
        {
            string text = ((Button)sender).Text;

            // C — очистка
            if (text == "C" || text == "С")
            {
                txtDisplay.Text = ""; // очищение дисплея
                operation = null; // сбрасывание операции
                newInput = true; // следующий ввод - новое число
                return;
            }

            // = — вычисление
            if (text == "=")
            {
                // Выполнение рачсёта если если операция выбрана
                if (operation != null)
                {
                    try
                    {
                        // Преобразования текст дисплея во второе число
                        double second = double.Parse(txtDisplay.Text);
                        txtDisplay.Text = operation.Calculate(firstNumber, second).ToString();
                    }
                    // Деление на ноль появляется ошибка
                    catch { txtDisplay.Text = "Ошибка"; }
                    operation = null; // сбрасывание операции
                    newInput = true; // следующий ввод - новое число
                }
                return;
            }

            // Операции +, −, *, /
            if (text == "+" || text == "−" || text == "*" || text == "/")
            {
                // Калькулятор работает только если есть число
                if (txtDisplay.Text == "") return;

                // Запоминание первого числа
                firstNumber = double.Parse(txtDisplay.Text);

                // Создание объекта нужного класса в зависимости от кнопки
                if (text == "+") operation = new Addition(); // сложение
                if (text == "−") operation = new Subtraction(); // вычитание
                if (text == "*") operation = new Multiplication(); // умножение
                if (text == "/") operation = new Division(); // деление

                newInput = true; // следующая цифра начнёт новое число
                return;
            }

            // Добавляем цифру или точку к текущему числу
            if (newInput) { txtDisplay.Text = ""; newInput = false; }
            txtDisplay.Text += text;
        }
    }
}