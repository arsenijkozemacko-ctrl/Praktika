using System.Drawing;

namespace Выполнение_задания_1_модуля_5
{
    // Класс для рисования круга
    public class CircleFigure : Figure
    {
        public override void Draw(Graphics g, Point startPoint)
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawEllipse(pen, startPoint.X, startPoint.Y, 100, 100);
        }
    }
}