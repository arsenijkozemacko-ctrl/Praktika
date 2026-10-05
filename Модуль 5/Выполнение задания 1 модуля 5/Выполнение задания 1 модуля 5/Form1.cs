using System;
using System.Data;
using System.Drawing;          // для Graphics, Pen, Color, Point
using System.Windows.Forms;

namespace Выполнение_задания_1_модуля_5
{
    public partial class Form1 : Form
    {
        // Переменная хранит текущий инструмент: "line", "circle", "rect"
        private string currentTool = "line";

        // Точка, где пользователь нажал мышью
        private Point startPoint;

        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик загрузки формы — оставляем пустым
        private void Form1_Load(object sender, EventArgs e)
        {
            // здесь ничего не нужно
        }

        // === Кнопки выбора инструмента ===

        // Кнопка 1 — Линия
        private void button1_Click(object sender, EventArgs e)
        {
            currentTool = "line";
        }

        // Кнопка 2 — Круг
        private void button2_Click(object sender, EventArgs e)
        {
            currentTool = "circle";
        }

        // Кнопка 3 — Квадрат
        private void button3_Click(object sender, EventArgs e)
        {
            currentTool = "rect";
        }

        // === Обработчики формы ===

        // Нажатие мыши — запоминаем начальную точку
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }

        // Отпускание мыши — перерисовываем форму
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Invalidate(); // "перерисуй форму"
        }

        // Отрисовка графики
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;                // получаем холст
            Pen pen = new Pen(Color.Black, 2);      // чёрная ручка толщиной 2

            // Рисуем фигуру по выбранному инструменту
            if (currentTool == "line")
            {
                // Линия длиной 100 по диагонали
                g.DrawLine(pen, startPoint.X, startPoint.Y,
                                startPoint.X + 100, startPoint.Y + 100);
            }
            else if (currentTool == "circle")
            {
                // Круг диаметром 100
                g.DrawEllipse(pen, startPoint.X, startPoint.Y, 100, 100);
            }
            else if (currentTool == "rect")
            {
                // Квадрат 100×100
                g.DrawRectangle(pen, startPoint.X, startPoint.Y, 100, 100);
            }
        }
    }
}