using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; // Для Image, Bitmap
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Выполнение_задания_4_модуля_5
{
    public partial class Form1 : Form
    {
        // Оригинальное изображение (не изменяетсяпри масштабировании)
        private Image originalimage;
        public Form1()
        {
            InitializeComponent();
        }

        // Пункт меню Файл => Открыть
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаём диалог открытия файла 
            OpenFileDialog ofd = new OpenFileDialog();

            // Фильтр показывать только изображения
            ofd.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp;.gif|Все файлы(*.*)|*.*";

            // Если пользователь выбрал файл - загружаем картинку
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Загружаем изображение с диска
                originalimage = Image.FromFile(ofd.FileName);

                // Показываем его в PictureBox
                pictureBox.Image = originalimage;

                // Сбрасываем ползунок на 100%
                trackZoom.Value = 100;
                lblZoom.Text = "100%";
            }
        }

        // Пункт в меню Файл => Выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Закрываем приложение
            Application.Exit();
        }

        private void trackZoom_Scroll(object sender, EventArgs e)
        {
            // Если картинка ешё не загружена - ничего не делаем
            if (originalimage == null) return;

            // Обновляем подпись с текущим масштабом
            lblZoom.Text = trackZoom.Value + "%";

            // Вычисление новые размеры (в процентах от оригинала)
            int newWidth = originalimage.Width * trackZoom.Value / 100;
            int newHeight = originalimage.Height * trackZoom.Value / 100;

            // Создаём уменьшенную/увеличенную копию
            Bitmap resized = new Bitmap(originalimage, newWidth, newHeight);

            // Отображаем её в PictureBox
            pictureBox.Image = resized;
        }
    }
}
