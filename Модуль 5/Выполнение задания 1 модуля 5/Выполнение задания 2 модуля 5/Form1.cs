using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // для работы с файлами
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Выполнение_задания_2_модуля_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Пункт меню файл => открыть
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаём диалог открытия файла
            OpenFileDialog ofd = new OpenFileDialog();

            // фильтр: показывать только .txt или все файлы
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            // Если пользователь нажал "ОК" - читаем файл
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtEditor.Text = File.ReadAllText(ofd.FileName);
            }
        }

        // Пункт меню файл => сохранить
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создаём диалог сохранения файла
            SaveFileDialog sfd = new SaveFileDialog();

            // Фильтр: только .txt
            sfd.Filter = "Текстовые файлы (*.txt)|*.txt";

            // Если пользователь указал путь - записывавем текст
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Записываем содержимое TextBox в файл
                File.WriteAllText(sfd.FileName, txtEditor.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
