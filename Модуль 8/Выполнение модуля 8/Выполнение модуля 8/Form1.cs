#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Выполнение_модуля_8
{
    public partial class Form1 : Form
    {
        private MapManager mapManager = new MapManager();
        private MapMarker selectedMarker = null;

        // Переменные для перетаскивания карты
        private bool isDragging = false;
        private bool hasDragged = false;
        private Point dragStartPoint;
        private Point mapOffset = Point.Empty;

        // Переменные для масштабирования (ЗУМ)
        private double zoom = 1.0;
        private const double ZoomStep = 0.1;

        public Form1()
        {
            InitializeComponent();

            // Подписываем события мыши (включая колесико)
            picMap.MouseDown += picMap_MouseDown;
            picMap.MouseUp += picMap_MouseUp;
            picMap.MouseMove += picMap_MouseMove;
            picMap.MouseClick += picMap_MouseClick;
            picMap.MouseWheel += picMap_MouseWheel; // Колесико мыши
            picMap.Paint += picMap_Paint;

            // Добавляем тестовые точки (X, Y, Название, Описание)
            mapManager.AddMarker(150, 150, "Кафе", "Ул. Пушкина, 10");
            mapManager.AddMarker(350, 250, "Парк", "Центральный вход");

            UpdateList();
        }

        // Обновление списка точек слева
        private void UpdateList()
        {
            lstMarkers.Items.Clear();
            foreach (var m in mapManager.GetAllMarkers())
            {
                lstMarkers.Items.Add(m.Title);
            }
            picMap.Invalidate(); // Перерисовываем карту
        }

        // Удаление выбранной точки
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstMarkers.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите точку в списке!");
                return;
            }

            mapManager.RemoveMarkerAt(lstMarkers.SelectedIndex);
            selectedMarker = null;
            lblInfo.Text = "Кликните по карте...";
            UpdateList();
        }

        // === ПРОКРУТКА КОЛЕСИКА (ЗУМ) ===
        private void picMap_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) // Приближаем
            {
                zoom += ZoomStep;
            }
            else if (e.Delta < 0 && zoom > 0.2) // Отдаляем
            {
                zoom -= ZoomStep;
            }

            picMap.Invalidate(); // Перерисовываем
        }

        // === ОТРИСОВКА СЕТКИ И МАРКЕРОВ ===
        private void picMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.WhiteSmoke);

            // 1. Сетка с учетом масштаба
            Pen gridPen = new Pen(Color.LightGray, 1);
            int step = (int)(50 * zoom);
            if (step < 5) step = 5;

            int startX = (mapOffset.X % step) - step;
            int startY = (mapOffset.Y % step) - step;

            for (int i = startX; i < picMap.Width; i += step)
                g.DrawLine(gridPen, i, 0, i, picMap.Height);
            for (int j = startY; j < picMap.Height; j += step)
                g.DrawLine(gridPen, 0, j, picMap.Width, j);

            // 2. Маркеры с учетом масштаба
            foreach (var m in mapManager.GetAllMarkers())
            {
                int drawX = (int)(m.X * zoom) + mapOffset.X;
                int drawY = (int)(m.Y * zoom) + mapOffset.Y;
                int currentRadius = (int)(MapMarker.Radius * zoom);

                if (drawX > -100 && drawX < picMap.Width + 100 && drawY > -100 && drawY < picMap.Height + 100)
                {
                    Brush brush = (m == selectedMarker) ? Brushes.Red : Brushes.Blue;
                    g.FillEllipse(brush, drawX - currentRadius, drawY - currentRadius, currentRadius * 2, currentRadius * 2);

                    // Подпись маркера
                    g.DrawString(m.Title, this.Font, Brushes.Black, drawX + currentRadius, drawY - 10);
                }
            }
        }

        // === НАЖАТИЕ МЫШИ ===
        private void picMap_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                hasDragged = false;
                dragStartPoint = e.Location;
                picMap.Cursor = Cursors.Hand;
            }
        }

        // === ОТПУСКАНИЕ МЫШИ ===
        private void picMap_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            picMap.Cursor = Cursors.Default;
        }

        private void picMap_MouseMove(object sender, MouseEventArgs e)
        {
            // --- 1. ОБНОВЛЕНИЕ КООРДИНАТ В РЕАЛЬНОМ ВРЕМЕНИ ---
            // Вычисляем координаты курсора (учитывая зум и сдвиг)
            int currentMapX = (int)((e.X - mapOffset.X) / zoom);
            int currentMapY = (int)((e.Y - mapOffset.Y) / zoom);

            // Переводим в "реальные" координаты (например, 1 пиксель = 0.01)
            double realX = Math.Round(currentMapX * 0.01, 2);
            double realY = Math.Round(currentMapY * 0.01, 2);

            // Выводим в Label
            lblCoords.Text = $"X: {realX} | Y: {realY}";

            // --- 2. ЛОГИКА ПЕРЕТАСКИВАНИЯ КАРТЫ ---
            if (isDragging)
            {
                int dx = e.X - dragStartPoint.X;
                int dy = e.Y - dragStartPoint.Y;

                // Если сдвиг больше 2 пикселей — это перетаскивание
                if (Math.Abs(dx) > 2 || Math.Abs(dy) > 2)
                    hasDragged = true;

                mapOffset.X += dx;
                mapOffset.Y += dy;
                dragStartPoint = e.Location;

                picMap.Invalidate();
            }
        }

        // === КЛИК ПО КАРТЕ (ДОБАВЛЕНИЕ ИЛИ ВЫДЕЛЕНИЕ) ===
        private void picMap_MouseClick(object sender, MouseEventArgs e)
        {
            // Заставляем PictureBox получить фокус, чтобы ловить колесико
            picMap.Focus();

            if (hasDragged) return;

            // Переводим клик в координаты карты (с учетом зума и смещения)
            int clickMapX = (int)((e.X - mapOffset.X) / zoom);
            int clickMapY = (int)((e.Y - mapOffset.Y) / zoom);

            selectedMarker = mapManager.FindMarkerAt(clickMapX, clickMapY);

            if (selectedMarker != null)
            {
                lblInfo.Text = $"Выбрано: {selectedMarker.Title}\nОписание: {selectedMarker.Description}";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    lblInfo.Text = "Для добавления точки введите название слева.";
                    return;
                }

                mapManager.AddMarker(clickMapX, clickMapY, txtTitle.Text, txtDescription.Text);
                txtTitle.Clear();
                txtDescription.Clear();
                lblInfo.Text = "Новая точка добавлена!";
                UpdateList();
            }

            picMap.Invalidate();
        }
    }
}