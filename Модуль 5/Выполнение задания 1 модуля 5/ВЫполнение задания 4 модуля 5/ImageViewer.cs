#nullable disable
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Выполнение_задания_4_модуля_5
{
    public class ImageViewer
    {
        public Image OriginalImage { get; private set; }

        public ImageViewer()
        {
            OriginalImage = null;
        }

        public Image Load()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Все файлы (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OriginalImage = Image.FromFile(ofd.FileName);
                    return OriginalImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке: " + ex.Message);
                }
            }
            return null;
        }

        public Image Zoom(int percent)
        {
            if (OriginalImage == null) return null;

            int newWidth = OriginalImage.Width * percent / 100;
            int newHeight = OriginalImage.Height * percent / 100;

            return new Bitmap(OriginalImage, newWidth, newHeight);
        }
    }
}