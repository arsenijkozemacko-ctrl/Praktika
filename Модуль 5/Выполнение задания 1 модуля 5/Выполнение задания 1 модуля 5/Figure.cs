using System.Drawing;

namespace Выполнение_задания_1_модуля_5
{
    // Базовый абстрактный класс для всех фигур
    public abstract class Figure
    {
        // Абстрактный метод - каждая фигура рисует себя по-своему
        public abstract void Draw(Graphics g, Point startPoint);
    }
}
