#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Выполнение_задания_1_модуля_5
{
    public partial class Form1 : Form
    {
        // Текущая фигура — объект класса Figure
        private Figure currentFigure = new LineFigure();

        // Точка нажатия мыши
        private Point startPoint;

        public Form1()
        {
            InitializeComponent();

            // Включаем двойную буферизацию — чтобы не мерцало
            this.DoubleBuffered = true;
        }

        // Кнопка "Линия" 
        private void btnLine_Click(object sender, EventArgs e)
        {
            currentFigure = new LineFigure();
        }

        // Кнопка "Круг" 
        private void btnCircle_Click(object sender, EventArgs e)
        {
            currentFigure = new CircleFigure();
        }

        // Кнопка "Квадрат"
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            currentFigure = new RectangleFigure();
        }

        // Нажатие мыши — запоминаем начальную точку 
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
        }

        // Отпускание мыши — перерисовываем форму
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Invalidate();
        }

        // Отрисовка — вызываем метод Draw у текущей фигуры 
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Полиморфизм: каждая фигура рисует себя по-своему
            currentFigure.Draw(e.Graphics, startPoint);
        }
    }
}