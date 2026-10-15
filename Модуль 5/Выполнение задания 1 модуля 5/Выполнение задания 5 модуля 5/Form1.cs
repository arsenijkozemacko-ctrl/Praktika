#nullable disable
using System;
using System.Windows.Forms;

namespace Выполнение_задания_5_модуля_5
{
    public partial class Form1 : Form
    {
        // Переменные состояния
        private double firstNumber = 0;      // первое число
        private string currentOp = "";       // текущая операция
        private bool newInput = true;        // флаг нового ввода
        private Operation operation = null;  // объект операции (полиморфизм)

        public Form1()
        {
            InitializeComponent();
        }

        // === ОБЩИЙ ОБРАБОТЧИК ДЛЯ ВСЕХ 17 КНОПОК ===
        private void btnClear_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string text = btn.Text;

            // === Кнопка "C" — очистка ===
            if (text == "С" || text == "C")
            {
                txtDisplay.Text = "";
                firstNumber = 0;
                currentOp = "";
                operation = null;
                newInput = true;
                return;
            }

            // === Кнопка "=" — вычисление ===
            if (text == "=")
            {
                if (operation == null) return;

                try
                {
                    // Берём второе число из дисплея
                    double secondNumber = double.Parse(txtDisplay.Text);

                    // Вызываем метод Calculate через объект операции (полиморфизм)
                    double result = operation.Calculate(firstNumber, secondNumber);

                    // Показываем результат
                    txtDisplay.Text = result.ToString();

                    // Сбрасываем операцию
                    operation = null;
                    newInput = true;
                }
                catch (DivideByZeroException)
                {
                    txtDisplay.Text = "Ошибка: деление на ноль";
                    operation = null;
                    newInput = true;
                }
                catch
                {
                    txtDisplay.Text = "Ошибка";
                    operation = null;
                    newInput = true;
                }
                return;
            }

            // === Кнопки операций (+, −, ×, ÷) ===
            if (text == "+" || text == "−" || text == "*" || text == "/")
            {
                if (txtDisplay.Text == "") return;

                // Запоминаем первое число
                firstNumber = double.Parse(txtDisplay.Text);

                // Создаём объект нужного класса (полиморфизм)
                if (text == "+") operation = new Addition();
                else if (text == "−") operation = new Subtraction();
                else if (text == "*") operation = new Multiplication();
                else if (text == "/") operation = new Division();

                currentOp = text;
                newInput = true;
                return;
            }

            // === Цифры и точка ===
            if (char.IsDigit(text[0]) || text == "," || text == ".")
            {
                if (newInput)
                {
                    txtDisplay.Text = "";
                    newInput = false;
                }
                txtDisplay.Text += text;
            }
        }
    }
}