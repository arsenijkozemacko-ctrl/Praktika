using System;
using System.Windows.Forms;

namespace Выполнение_задания_2_модуля_5
{
    public partial class Form1 : Form
    {
        // Объект класса FileManager — вся работа с файлами
        private FileManager fileManager = new FileManager();

        public Form1()
        {
            InitializeComponent();
        }

        // Файл → Открыть 
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = fileManager.OpenFile();

            if (text != null)
                txtEditor.Text = text;
        }

        // Файл → Сохранить 
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileManager.SaveFile(txtEditor.Text);
        }

        // Файл → Выход 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}