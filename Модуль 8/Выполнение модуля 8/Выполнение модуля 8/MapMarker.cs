using System.Drawing;

namespace Выполнение_модуля_8
{
    public class MapMarker
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Радиус маркера (чтобы не писать 225 в коде)
        public const int Radius = 15;

        public MapMarker(int x, int y, string title, string description)
        {
            X = x; Y = y; Title = title; Description = description;
        }

        // Проверка попадания клика (теорема Пифагора)
        public bool IsHit(int mouseX, int mouseY)
        {
            int dx = mouseX - X;
            int dy = mouseY - Y;
            return (dx * dx + dy * dy) <= (Radius * Radius);
        }
    }
}