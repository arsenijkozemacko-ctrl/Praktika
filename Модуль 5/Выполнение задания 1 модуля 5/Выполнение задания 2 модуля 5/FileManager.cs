#nullable disable
using System;
using System.IO;
using System.Windows.Forms;

namespace Выполнение_задания_2_модуля_5
{
    // Класс для работы с файлами (открытие и сохранение)
    public class FileManager
    {
        // Путь к текущему файлу (null, если не сохранён)
        public string CurrentFilePath { get; set; }

        // Конструктор
        public FileManager()
        {
            CurrentFilePath = null;
        }

        // Открыть файл 
        public string OpenFile()
        {
            // Создаём диалог открытия
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            // Если пользователь выбрал файл
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Запоминаем путь
                    CurrentFilePath = ofd.FileName;

                    // Читаем текст и возвращаем
                    return File.ReadAllText(ofd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при открытии: " + ex.Message);
                }
            }

            return null; // если пользователь отменил
        }

        // Сохранить файл 
        public bool SaveFile(string text)
        {
            // Если путь уже есть — сохраняем туда
            if (CurrentFilePath != null)
            {
                return WriteToFile(CurrentFilePath, text);
            }
            // Иначе — вызываем "Сохранить как"
            else
            {
                return SaveFileAs(text);
            }
        }

        //  Сохранить как
        public bool SaveFileAs(string text)
        {
            // Создаём диалог сохранения
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            // Если пользователь указал путь
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                CurrentFilePath = sfd.FileName;
                return WriteToFile(sfd.FileName, text);
            }

            return false;
        }

        // Записать текст в файл (приватный метод)
        private bool WriteToFile(string path, string text)
        {
            try
            {
                File.WriteAllText(path, text);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                return false;
            }
        }
    }
}