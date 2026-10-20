using System.Runtime.InteropServices;

namespace Разработка_курсового_проекта
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dgvIdeologies = new DataGridView();
            panel1 = new Panel();
            btnFilter = new Button();
            label2 = new Label();
            cmbFilter = new ComboBox();
            btnSearch = new Button();
            label1 = new Label();
            txtSearch = new TextBox();
            btnCompare = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            lblStatus = new Label();
            toolTip1 = new ToolTip(components);
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            contextMenuStrip1 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            справкаToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvIdeologies).BeginInit();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvIdeologies
            // 
            dgvIdeologies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIdeologies.Dock = DockStyle.Bottom;
            dgvIdeologies.Location = new Point(0, 150);
            dgvIdeologies.Name = "dgvIdeologies";
            dgvIdeologies.RowHeadersWidth = 51;
            dgvIdeologies.Size = new Size(1813, 574);
            dgvIdeologies.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnFilter);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbFilter);
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnCompare);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnEdit);
            panel1.Controls.Add(btnAdd);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1813, 68);
            panel1.TabIndex = 1;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(1217, 18);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 9;
            btnFilter.Text = "Фильтр";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(995, 24);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 8;
            label2.Text = "Фильтр";
            // 
            // cmbFilter
            // 
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Location = new Point(1061, 19);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(150, 28);
            cmbFilter.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(841, 19);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Найти";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(570, 24);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 6;
            label1.Text = "Поиск :";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(635, 21);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 27);
            txtSearch.TabIndex = 2;
            // 
            // btnCompare
            // 
            btnCompare.Location = new Point(369, 12);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(107, 44);
            btnCompare.TabIndex = 5;
            btnCompare.Text = "Сравнить";
            toolTip1.SetToolTip(btnCompare, "Сравнить выбранные идеологии");
            btnCompare.UseVisualStyleBackColor = true;
            btnCompare.Click += btnCompare_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(256, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(107, 44);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Удалить";
            toolTip1.SetToolTip(btnDelete, "Удалить выбранную идеологию");
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(125, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(125, 44);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Редактировать";
            toolTip1.SetToolTip(btnEdit, "Отредактировать выбранную ячейку");
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(107, 44);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить";
            toolTip1.SetToolTip(btnAdd, "Добавить идеологию");
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Location = new Point(0, 130);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(57, 20);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Готово";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { справкаToolStripMenuItem });
            menuStrip1.Location = new Point(0, 68);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1813, 28);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            справкаToolStripMenuItem.Size = new Size(81, 24);
            справкаToolStripMenuItem.Text = "Справка";
            справкаToolStripMenuItem.Click += справкаToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1813, 724);
            Controls.Add(menuStrip1);
            Controls.Add(lblStatus);
            Controls.Add(panel1);
            Controls.Add(dgvIdeologies);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "IdeologyComparer";
            ((System.ComponentModel.ISupportInitialize)dgvIdeologies).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvIdeologies;
        private Panel panel1;
        private Button btnCompare;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label label1;
        private Label label2;
        private ComboBox cmbFilter;
        private Button btnFilter;
        private Label lblStatus;
        private ToolTip toolTip1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ContextMenuStrip contextMenuStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem справкаToolStripMenuItem;
    }
}