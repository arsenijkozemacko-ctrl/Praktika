using System.Drawing;

namespace Выполнение_задания_1_модуля_5
{
    // Класс для рисования линии
    public class LineFigure : Figure
    {
        public override void Draw(Graphics g, Point startPoint)
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, startPoint.X, startPoint.Y,
                startPoint.X + 100, startPoint.Y + 100);
        }
    }
}
