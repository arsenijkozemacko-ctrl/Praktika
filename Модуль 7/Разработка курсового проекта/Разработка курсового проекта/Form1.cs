#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Разработка_курсового_проекта
{
    public partial class Form1 : Form
    {
        // Объект для работы с базой данных SQLite
        private DatabaseHelper db;
        // Список всех идеологий, загруженных из базы данных
        private List<Ideology> ideologies;
        // Результат последнего поиска (используется для совместной работы поиска и фильтра)
        private List<Ideology> lastSearchResult;

        // Конструктор формы — выполняется при запуске приложения
        public Form1()
        {
            InitializeComponent();
            db = new DatabaseHelper(); // Создание подключения к БД, при первом запуске создаётся файл ideologies.db
            SetupDataGridView(); // Настройка внешнего вида таблицы
            LoadData(); // Загрузка данных из БД в таблицу
            SetupFilterComboBox(); // Настройка выпадающего списка для фильтрации
            UpdateFilterOptions(); // Обновление списка экономик для фильтра (чтобы при первом запуске были все категории)
        }

        // Настройка таблицы DataGridView: создание столбцов и параметров отображения
        private void SetupDataGridView()
        {
            // Массив названий столбцов. Id — служебный, будет скрыт от пользователя
            string[] columns = { "Id", "Название", "Ценности", "Роль государства", "Экономика", "Страны", "Личности" };
            // Добавление столбцов в таблицу
            foreach (string col in columns)
                dgvIdeologies.Columns.Add(col, col);

            // Столбец Id скрывается, так как используется только для внутренней работы (поиск, обновление, удаление)
            dgvIdeologies.Columns[0].Visible = false;
            // Столбцы автоматически растягиваются по ширине таблицы
            dgvIdeologies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Высота строк автоматически подстраивается под содержимое (для длинных текстов)
            dgvIdeologies.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // Длинный текст переносится на новую строку внутри ячейки
            dgvIdeologies.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // При клике выделяется вся строка, а не отдельная ячейка
            dgvIdeologies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Разрешает выбор нескольких строк для сравнения
            dgvIdeologies.MultiSelect = true;
            // Таблица только для чтения — редактирование через отдельные окна
            dgvIdeologies.ReadOnly = true;
            // Не показывать пустую строку внизу таблицы для добавления новых записей
            dgvIdeologies.AllowUserToAddRows = false;
            // Скрыть левую колонку с номерами строк
            dgvIdeologies.RowHeadersVisible = false;
        }

        // Настройка выпадающего списка для фильтрации
        private void SetupFilterComboBox()
        {
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("Все"); // Пункт "Все" показывает все идеологии без фильтрации
            cmbFilter.SelectedIndex = 0; // По умолчанию выбран "Все"
        }

        // Обновление списка экономик в фильтре (извлекаются уникальные значения из данных)
        private void UpdateFilterOptions()
        {
            // Запоминаем текущий выбранный элемент, чтобы восстановить его после обновления
            string current = cmbFilter.SelectedItem?.ToString() ?? "Все";
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("Все");

            // Получение всех уникальных названий экономик из списка идеологий (исключаем пустые значения)
            var unique = ideologies.Select(i => i.Economy).Where(e => !string.IsNullOrWhiteSpace(e)).Distinct().ToList();
            unique.Sort(); // Сортировка по алфавиту для удобства пользователя
            foreach (var item in unique)
                cmbFilter.Items.Add(item);

            // Восстановление выбранного элемента, если он всё ещё существует в обновлённом списке
            cmbFilter.SelectedItem = cmbFilter.Items.Contains(current) ? current : "Все";
        }

        // Загрузка всех идеологий из базы данных и отображение в таблице
        private void LoadData()
        {
            ideologies = db.GetAll(); // Получение всех записей из БД
            lastSearchResult = null; // Сброс результата поиска
            RefreshGrid(ideologies); // Отображение данных в таблице
            UpdateFilterOptions(); // Обновление списка экономик для фильтра
            lblStatus.Text = $"Загружено: {ideologies.Count} идеологий"; // Обновление статусной строки
        }

        // Обновление содержимого таблицы: очистка и заполнение переданными данными
        private void RefreshGrid(List<Ideology> data)
        {
            dgvIdeologies.Rows.Clear(); // Очистка таблицы
            foreach (var ideo in data) // Для каждой идеологии из списка
                dgvIdeologies.Rows.Add(ideo.Id, ideo.Name, ideo.CoreValues,
                    ideo.RoleOfState, ideo.Economy, ideo.Countries, ideo.KeyFigures);
        }

        // Получение выбранной в таблице идеологии (или null, если ничего не выбрано)
        private Ideology GetSelected()
        {
            if (dgvIdeologies.SelectedRows.Count == 0) return null;
            int id = Convert.ToInt32(dgvIdeologies.SelectedRows[0].Cells[0].Value);
            return ideologies.Find(i => i.Id == id);
        }

        // Кнопка "Добавить" — открывает диалог для ввода новой идеологии
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new IdeologyEditDialog("Добавить идеологию");
            // Если пользователь нажал "Сохранить" и все поля прошли проверку
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Создание новой идеологии из введённых данных и сохранение в БД
                db.Add(new Ideology
                {
                    Name = dialog.NameText,
                    CoreValues = dialog.ValuesText,
                    RoleOfState = dialog.RoleText,
                    Economy = dialog.EconomyText,
                    Countries = dialog.CountriesText,
                    KeyFigures = dialog.KeyFiguresText
                });
                lastSearchResult = null; // Сброс поиска
                LoadData(); // Обновление таблицы
            }
        }

        // Кнопка "Редактировать" — открывает диалог для изменения выбранной идеологии
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var sel = GetSelected(); // Получение выбранной идеологии
            if (sel == null) { MessageBox.Show("Выберите идеологию!"); return; }

            var dialog = new IdeologyEditDialog("Редактировать идеологию", sel);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Обновление полей выбранной идеологии новыми значениями
                sel.Name = dialog.NameText;
                sel.CoreValues = dialog.ValuesText;
                sel.RoleOfState = dialog.RoleText;
                sel.Economy = dialog.EconomyText;
                sel.Countries = dialog.CountriesText;
                sel.KeyFigures = dialog.KeyFiguresText;
                db.Update(sel); // Сохранение изменений в БД
                lastSearchResult = null;
                LoadData();
            }
        }

        // Кнопка "Удалить" — удаляет выбранную идеологию после подтверждения
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var sel = GetSelected();
            if (sel == null) { MessageBox.Show("Выберите идеологию!"); return; }

            // Запрос подтверждения перед удалением
            if (MessageBox.Show("Удалить идеологию?", "Подтверждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.Delete(sel.Id);
                lastSearchResult = null;
                LoadData();
            }
        }

        // Кнопка "Сравнить" — выполняет сравнение выбранных идеологий (2 и более)
        private void btnCompare_Click(object sender, EventArgs e)
        {
            // Проверка, что выбрано хотя бы две идеологии
            if (dgvIdeologies.SelectedRows.Count < 2)
            {
                MessageBox.Show("Выберите хотя бы две идеологии!");
                return;
            }

            var data = ExtractData(); // Извлечение данных из выбранных строк
            ShowResultWindow(BuildResult(data), data.Names); // Формирование результата и показ в отдельном окне
        }

        // Извлечение данных из выбранных строк таблицы
        private (List<string> Names, List<string> Values, List<string> Roles,
                 List<string> Economies, List<string> Countries, List<string> Figures)
            ExtractData()
        {
            var n = new List<string>();
            var v = new List<string>();
            var r = new List<string>();
            var e = new List<string>();
            var c = new List<string>();
            var f = new List<string>();

            // Проход по всем выбранным строкам и извлечение данных из каждой ячейки
            foreach (DataGridViewRow row in dgvIdeologies.SelectedRows)
            {
                n.Add(row.Cells["Название"].Value.ToString());
                v.Add(row.Cells["Ценности"].Value.ToString());
                r.Add(row.Cells["Роль государства"].Value.ToString());
                e.Add(row.Cells["Экономика"].Value.ToString());
                c.Add(row.Cells["Страны"].Value.ToString());
                f.Add(row.Cells["Личности"].Value.ToString());
            }
            return (n, v, r, e, c, f);
        }

        // Формирование результата сравнения с использованием математических формул
        private string BuildResult((List<string> Names, List<string> Values, List<string> Roles,
            List<string> Economies, List<string> Countries, List<string> Figures) d)
        {
            var (names, values, roles, economies, countries, figures) = d;
            int cnt = names.Count;

            // Заголовок и список сравниваемых идеологий
            string res = $"СРАВНЕНИЕ ИДЕОЛОГИЙ ({cnt})\n" + new string('=', 50) + "\n\n";
            res += "ИДЕОЛОГИИ:\n";
            for (int i = 0; i < cnt; i++) res += $"   {i + 1}. {names[i]}\n";
            res += $"\n{new string('-', 50)}\n\n";

            // Анализ по каждой категории (экономика, роль государства, страны, личности)
            res += BuildCat("ЭКОНОМИКЕ", economies, names);
            res += BuildCat("РОЛИ ГОСУДАРСТВА", roles, names);
            res += BuildCat("СТРАНАМ", countries, names);
            res += BuildCat("ЛИЧНОСТЯМ", figures, names);

            // Коэффициент Жаккара — отношение пересечения к объединению множеств
            // Формула: J(A,B) = |A∩B| / |A∪B|
            double jaccard = CalculateJaccard(values);
            res += $"\n{new string('-', 50)}\n";
            res += $" КОЭФФИЦИЕНТ ЖАККАРА: {jaccard:F2}\n";
            res += $"   (0 = совсем не похожи, 1 = идентичны)\n";

            // Евклидово расстояние — показывает степень различия между идеологиями
            // Формула: d(A,B) = √(Σ(ai - bi)²)
            double euclidean = CalculateEuclidean(economies, roles, countries, figures);
            res += $"\n ЕВКЛИДОВО РАССТОЯНИЕ: {euclidean:F2}\n";
            res += $"   (чем меньше значение, тем ближе идеологии друг к другу)\n";

            // Взвешенная оценка — учитывает важность каждого критерия
            // Формула: S = Σ(w_i * x_i)
            res += $"\n ВЗВЕШЕННАЯ ОЦЕНКА (по 4 критериям):\n";
            var weightedScores = CalculateWeightedScores(economies, roles, countries, figures, names);
            foreach (var kvp in weightedScores)
                res += $"   • {kvp.Key}: {kvp.Value:F2}\n";

            // Анализ ценностей — поиск общих слов во всех текстах ценностей
            res += "\nЦЕННОСТИ:\n";
            var common = FindCommon(values);
            res += common.Count > 0 ? $"   Общие слова: {string.Join(", ", common)}\n" : "   Общих слов нет\n";
            // Вывод ценностей каждой идеологии отдельно
            for (int i = 0; i < cnt; i++) res += $"   {names[i]}: {values[i]}\n";

            // Процент сходства по 4 критериям (экономика, роль, страны, личности)
            int total = 4, commonCnt = 0;
            if (economies.Distinct().Count() == 1) commonCnt++; // Все экономики совпадают
            if (roles.Distinct().Count() == 1) commonCnt++; // Все роли совпадают
            if (countries.Distinct().Count() == 1) commonCnt++; // Все страны совпадают
            if (figures.Distinct().Count() == 1) commonCnt++; // Все личности совпадают

            double sim = (double)commonCnt / total * 100;
            res += $"\n{new string('-', 50)}\n";
            res += $"СХОДСТВО: {sim:F0}% (по {total} критериям)\n";
            res += "ОЦЕНКА: " + GetRating(sim) + "\n" + new string('=', 50);

            return res;
        }

        // Вычисление коэффициента Жаккара
        private double CalculateJaccard(List<string> valuesList)
        {
            if (valuesList == null || valuesList.Count < 2) return 0;

            // Преобразование каждой строки ценностей в набор слов (очистка от знаков препинания)
            var wordSets = valuesList
                .Select(v => new HashSet<string>(
                    new string(v.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray())
                        .ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                ))
                .ToList();

            // Нахождение пересечения (общие слова) и объединения (все слова) множеств
            var intersection = new HashSet<string>(wordSets[0]);
            var union = new HashSet<string>(wordSets[0]);

            for (int i = 1; i < wordSets.Count; i++)
            {
                intersection.IntersectWith(wordSets[i]); // Общие слова
                union.UnionWith(wordSets[i]); // Все слова
            }

            return union.Count == 0 ? 0 : (double)intersection.Count / union.Count;
        }

        // Вычисление евклидова расстояния
        private double CalculateEuclidean(List<string> economies, List<string> roles,
            List<string> countries, List<string> figures)
        {
            if (economies.Count < 2) return 0;

            // Преобразование категориальных данных в числовые векторы
            var allValues = new List<List<double>>();
            for (int i = 0; i < economies.Count; i++)
            {
                allValues.Add(new List<double>
                {
                    GetCategoryValue(economies[i], new List<string> { "Рыночная", "Плановая", "Смешанная" }),
                    GetCategoryValue(roles[i], new List<string> { "Минимальная", "Умеренная", "Сильная", "Тотальная" }),
                    GetCategoryValue(countries[i], new List<string> { "США", "Великобритания", "Россия", "Швеция", "Китай" }),
                    GetCategoryValue(figures[i], new List<string>())
                });
            }

            // Вычисление среднего расстояния между всеми парами идеологий
            double totalDistance = 0;
            int pairs = 0;

            for (int i = 0; i < allValues.Count; i++)
            {
                for (int j = i + 1; j < allValues.Count; j++)
                {
                    double sumSq = 0;
                    for (int k = 0; k < allValues[i].Count; k++)
                        sumSq += Math.Pow(allValues[i][k] - allValues[j][k], 2);
                    totalDistance += Math.Sqrt(sumSq);
                    pairs++;
                }
            }

            return pairs > 0 ? totalDistance / pairs : 0;
        }

        // Преобразование категории в числовое значение для евклидова расстояния
        private double GetCategoryValue(string value, List<string> reference)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            if (reference.Count == 0)
                return Math.Abs(value.GetHashCode()) % 10; // Для личностей используем хеш-код

            int index = reference.IndexOf(value);
            return index >= 0 ? index + 1 : reference.Count + 1;
        }

        // Вычисление взвешенной оценки для каждой идеологии
        private Dictionary<string, double> CalculateWeightedScores(List<string> economies,
            List<string> roles, List<string> countries, List<string> figures, List<string> names)
        {
            var result = new Dictionary<string, double>();

            // Веса критериев (сумма = 1). Определяют важность каждого критерия
            double[] weights = { 0.30, 0.30, 0.20, 0.20 };
            // Списки эталонных значений для каждого критерия
            var references = new List<List<string>>
            {
                new List<string> { "Рыночная", "Плановая", "Смешанная" },
                new List<string> { "Минимальная", "Умеренная", "Сильная", "Тотальная" },
                new List<string> { "США", "Великобритания", "Россия", "Швеция", "Китай" },
                new List<string>() // Для личностей — пустой список
            };

            for (int i = 0; i < economies.Count; i++)
            {
                double score = 0;
                score += GetScore(economies[i], references[0]) * weights[0];
                score += GetScore(roles[i], references[1]) * weights[1];
                score += GetScore(countries[i], references[2]) * weights[2];
                score += GetScore(figures[i], references[3]) * weights[3];
                result[names[i]] = score;
            }

            return result;
        }

        // Нормализация оценки для взвешенной оценки (приводит значения к диапазону 0-1)
        private double GetScore(string value, List<string> reference)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0.5; // Среднее значение для пустых полей
            if (reference.Count == 0)
                return string.IsNullOrWhiteSpace(value) ? 0 : 1; // Для личностей: 1 если есть значение

            int index = reference.IndexOf(value);
            if (index < 0) return 0.3; // Если значение не найдено — низкая оценка
            return (double)(index + 1) / reference.Count;
        }

        // Анализ по одной категории: группировка значений и подсчёт процентов
        private string BuildCat(string cat, List<string> vals, List<string> names)
        {
            string res = $"\n{cat}:\n";
            // Группировка одинаковых значений и подсчёт количества в каждой группе
            foreach (var g in vals.GroupBy(x => x))
            {
                int cnt = g.Count();
                double pct = (double)cnt / vals.Count * 100;
                // Нахождение названий идеологий, у которых такое значение
                var matched = names.Where((n, i) => vals[i] == g.Key);
                res += $"   • {g.Key}: {cnt} из {vals.Count} ({pct:F0}%) — {string.Join(", ", matched)}\n";
            }
            return res;
        }

        // Текстовая оценка на основе процента сходства
        private string GetRating(double p) => p >= 80 ? "Очень похожи!" :
                                              p >= 50 ? "Среднее сходство." :
                                              p >= 20 ? "Значительно различаются." :
                                              "Практически противоположны.";

        // Поиск общих слов в ценностях (исключение предлогов и союзов короче 4 символов)
        private List<string> FindCommon(List<string> list)
        {
            if (list == null || list.Count == 0) return new List<string>();

            // Преобразование каждой строки в набор слов (убираем знаки препинания, приводим к нижнему регистру)
            var sets = list.Select(s => new HashSet<string>(
                new string(s.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray())
                    .ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            )).ToList();

            // Нахождение пересечения всех множеств — слова, которые есть у всех идеологий
            var common = new HashSet<string>(sets[0]);
            for (int i = 1; i < sets.Count; i++)
                common.IntersectWith(sets[i]);

            // Удаление слишком коротких слов (предлоги, союзы — они не несут смысловой нагрузки)
            return common.Where(w => w.Length > 3).ToList();
        }

        // Показ окна с результатом сравнения
        private void ShowResultWindow(string text, List<string> names)
        {
            var form = new Form
            {
                Text = "Результат сравнения",
                Size = new System.Drawing.Size(650, 550),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // RichTextBox — поле с поддержкой прокрутки и моноширинного шрифта
            var rtb = new RichTextBox
            {
                Location = new System.Drawing.Point(10, 10),
                Width = 615,
                Height = 400,
                ReadOnly = true,
                Font = new System.Drawing.Font("Consolas", 10),
                Text = text,
                BackColor = System.Drawing.Color.White
            };

            // Кнопка сохранения результата в файл
            var btnSave = new Button
            {
                Text = "Сохранить",
                Location = new System.Drawing.Point(10, 430),
                Width = 150,
                Height = 40,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += (s, e) => SaveResult(text, names);

            // Кнопка закрытия окна
            var btnClose = new Button
            {
                Text = "Закрыть",
                Location = new System.Drawing.Point(530, 430),
                Width = 95,
                Height = 40,
                FlatStyle = FlatStyle.Flat
            };
            btnClose.Click += (s, e) => form.Close();

            form.Controls.Add(rtb);
            form.Controls.Add(btnSave);
            form.Controls.Add(btnClose);
            form.ShowDialog();
        }

        // Сохранение результата в текстовый файл
        private void SaveResult(string text, List<string> names)
        {
            var dlg = new SaveFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt",
                DefaultExt = "txt",
                Title = "Сохранить результат",
                // Имя файла формируется автоматически из названий выбранных идеологий
                FileName = $"Сравнение_{string.Join("_", names.Take(3))}{(names.Count > 3 ? "_и_др" : "")}.txt"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(dlg.FileName, text);
                    MessageBox.Show($"Сохранено!\n{dlg.FileName}", "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Поиск по названию и ценностям (без учёта регистра)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string text = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(text))
            {
                lastSearchResult = null;
                LoadData();
                return;
            }

            // Поиск идеологий, у которых название или ценности содержат искомый текст
            lastSearchResult = ideologies
                .Where(ideo => ideo.Name.ToLower().Contains(text) ||
                              ideo.CoreValues.ToLower().Contains(text))
                .ToList();

            RefreshGrid(lastSearchResult);
            lblStatus.Text = $"Найдено: {lastSearchResult.Count}";
        }

        // Фильтрация по экономике (с возможностью ввода текста)
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filterText = cmbFilter.Text.Trim(); // Используем Text вместо SelectedItem

            // Если поле пустое или введено "Все" — показываем все идеологии
            if (string.IsNullOrWhiteSpace(filterText) || filterText.Equals("Все", StringComparison.OrdinalIgnoreCase))
            {
                var source = lastSearchResult?.Count > 0 ? lastSearchResult : ideologies;
                RefreshGrid(source);
                lblStatus.Text = lastSearchResult?.Count > 0
                    ? $"Показано: {source.Count} (результаты поиска)"
                    : $"Показано: {source.Count} (все)";
                return;
            }

            // Источник для фильтрации: либо результаты поиска, либо все идеологии
            var sourceList = lastSearchResult?.Count > 0 ? lastSearchResult : ideologies;

            // Фильтрация по экономике (без учёта регистра)
            var filtered = sourceList
                .Where(ideo => ideo.Economy.Equals(filterText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            RefreshGrid(filtered);
            lblStatus.Text = lastSearchResult?.Count > 0
                ? $"Отфильтровано: {filtered.Count} с экономикой \"{filterText}\" (в результатах поиска)"
                : $"Отфильтровано: {filtered.Count} с экономикой \"{filterText}\" (из всех)";
        }

        // ============================================================
        // СПРАВОЧНАЯ СИСТЕМА
        // ============================================================

        // Открывает файл справки при нажатии на пункт меню "Справка"
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Путь к файлу справки
            string helpFile = @"E:\IdeologyComparer.chm";

            // Проверяем, существует ли файл
            if (File.Exists(helpFile))
            {
                // Открываем справку
                Help.ShowHelp(this, helpFile);
            }
            else
            {
                // Если файл не найден — показываем сообщение
                MessageBox.Show("Файл справки не найден!\n\n" +
                                "Убедитесь, что файл IdeologyComparer.chm\n" +
                                "находится по пути: E:\\IdeologyComparer.chm",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Диалог для добавления или редактирования идеологии
    public class IdeologyEditDialog : Form
    {
        // Свойства для получения введённых данных из полей
        public string NameText => txtName.Text.Trim();
        public string ValuesText => txtValues.Text.Trim();
        public string RoleText => txtRole.Text.Trim();
        public string EconomyText => txtEconomy.Text.Trim();
        public string CountriesText => txtCountries.Text.Trim();
        public string KeyFiguresText => txtKeyFigures.Text.Trim();

        // Поля ввода
        private TextBox txtName, txtValues, txtRole, txtEconomy, txtCountries, txtKeyFigures;

        // Конструктор диалога: title — заголовок окна, ideo — редактируемая идеология (если null — режим добавления)
        public IdeologyEditDialog(string title, Ideology ideo = null)
        {
            Text = title;
            Size = new System.Drawing.Size(400, 440);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            int y = 20, w = 200, xLabel = 30, xField = 130;

            // Создание полей ввода и размещение по вертикали
            txtName = MakeField(xField, y, w); y += 40;
            txtValues = MakeField(xField, y, w, true); y += 90; // Многострочное поле для ценностей
            txtRole = MakeField(xField, y, w); y += 40;
            txtEconomy = MakeField(xField, y, w); y += 40;
            txtCountries = MakeField(xField, y, w); y += 40;
            txtKeyFigures = MakeField(xField, y, w);

            // Добавление подписей к полям
            AddLabel("Название:", xLabel, 20);
            AddLabel("Ценности:", xLabel, 60);
            AddLabel("Роль государства:", xLabel, 140);
            AddLabel("Экономика:", xLabel, 180);
            AddLabel("Страны:", xLabel, 220);
            AddLabel("Личности:", xLabel, 260);

            // Кнопки управления
            var btnSave = new Button { Text = "Сохранить", Location = new System.Drawing.Point(100, 340), Width = 100 };
            var btnCancel = new Button { Text = "Отмена", Location = new System.Drawing.Point(210, 340), Width = 100 };

            btnSave.Click += (s, e) =>
            {
                // Проверка обязательных полей (название и ценности не могут быть пустыми)
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtValues.Text))
                {
                    MessageBox.Show("Название и ценности обязательны!");
                    return;
                }
                DialogResult = DialogResult.OK; // Возврат OK, чтобы внешний код знал, что сохранение прошло
                Close();
            };
            btnCancel.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };

            Controls.AddRange(new Control[] { txtName, txtValues, txtRole, txtEconomy,
                txtCountries, txtKeyFigures, btnSave, btnCancel });

            // Если передана идеология — заполнение полей (режим редактирования)
            if (ideo != null)
            {
                txtName.Text = ideo.Name;
                txtValues.Text = ideo.CoreValues;
                txtRole.Text = ideo.RoleOfState;
                txtEconomy.Text = ideo.Economy;
                txtCountries.Text = ideo.Countries;
                txtKeyFigures.Text = ideo.KeyFigures;
            }
        }

        // Создание текстового поля с заданными параметрами
        private TextBox MakeField(int x, int y, int w, bool multi = false)
            => new TextBox
            {
                Location = new System.Drawing.Point(x, y),
                Width = w,
                Multiline = multi,
                Height = multi ? 60 : 25
            };

        // Добавление подписи к полю
        private void AddLabel(string text, int x, int y)
            => Controls.Add(new Label
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Width = 100,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight
            });
    }
}