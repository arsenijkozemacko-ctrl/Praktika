using System.Drawing;

namespace Выполнение_задания_1_модуля_5
{
    // Класс для рисования квадрата
    public class RectangleFigure : Figure
    {
        public override void Draw(Graphics g, Point startPoint)
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawRectangle(pen, startPoint.X, startPoint.Y, 100, 100);
        }
    }
}