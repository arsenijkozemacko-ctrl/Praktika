using System;
using System.Drawing;
using System.Windows.Forms;

namespace Выполнение_задания_4_модуля_5
{
    public partial class Form1 : Form
    {
        // Объект класса ImageViewer
        private ImageViewer viewer = new ImageViewer();

        public Form1()
        {
            InitializeComponent();
        }

        // Файл → Открыть 
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = viewer.Load();

            if (img != null)
            {
                pictureBox.Image = img;
                trackZoom.Value = 100;
                lblZoom.Text = "100%";
            }
        }

        // Файл → Выход 
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Ползунок масштаба
        private void trackZoom_Scroll(object sender, EventArgs e)
        {
            // Обновляем подпись
            lblZoom.Text = trackZoom.Value + "%";

            // Масштабируем через класс
            Image resized = viewer.Zoom(trackZoom.Value);

            if (resized != null)
                pictureBox.Image = resized;
        }
    }
}