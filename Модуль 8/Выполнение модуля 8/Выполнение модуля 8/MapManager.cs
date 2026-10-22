#nullable disable
using System.Collections.Generic;

namespace Выполнение_модуля_8
{
    public class MapManager
    {
        private List<MapMarker> markers = new List<MapMarker>();

        public void AddMarker(int x, int y, string title, string desc)
            => markers.Add(new MapMarker(x, y, title, desc));

        public List<MapMarker> GetAllMarkers() => markers;

        public MapMarker FindMarkerAt(int x, int y)
        {
            foreach (var m in markers)
                if (m.IsHit(x, y)) return m;
            return null;
        }

        public void RemoveMarkerAt(int index)
        {
            if (index >= 0 && index < markers.Count)
                markers.RemoveAt(index);
        }
    }
}