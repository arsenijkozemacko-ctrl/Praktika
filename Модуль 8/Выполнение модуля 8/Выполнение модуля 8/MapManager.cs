#nullable disable
using System;
using System.Collections.Generic;
using System.IO; // Обязательно для работы с файлами

namespace Выполнение_модуля_8
{
    public class MapManager
    {
        private List<MapMarker> markers = new List<MapMarker>();

        // Добавление маркера
        public void AddMarker(int x, int y, string title, string desc)
        {
            markers.Add(new MapMarker(x, y, title, desc));
        }

        // Получение всех маркеров
        public List<MapMarker> GetAllMarkers()
        {
            return markers;
        }

        // Поиск маркера по координатам клика
        public MapMarker FindMarkerAt(int x, int y)
        {
            foreach (var m in markers)
            {
                if (m.IsHit(x, y)) return m;
            }
            return null;
        }

        // Удаление маркера по индексу
        public void RemoveMarkerAt(int index)
        {
            if (index >= 0 && index < markers.Count)
            {
                markers.RemoveAt(index);
            }
        }

        // === АВТОСОХРАНЕНИЕ В ФАЙЛ ===
        public void SaveToFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (var m in markers)
                {
                    // Сохраняем: X;Y;Название;Описание
                    sw.WriteLine($"{m.X};{m.Y};{m.Title};{m.Description}");
                }
            }
        }

        // === АВТОЗАГРУЗКА ИЗ ФАЙЛА ===
        public void LoadFromFile(string path)
        {
            // Если файла нет (первый запуск) — просто выходим
            if (!File.Exists(path)) return;

            markers.Clear(); // Очищаем текущий список
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 4)
                {
                    int x = int.Parse(parts[0]);
                    int y = int.Parse(parts[1]);
                    string title = parts[2];
                    string desc = parts[3];

                    // Добавляем загруженную точку в список
                    AddMarker(x, y, title, desc);
                }
            }
        }
    }
}