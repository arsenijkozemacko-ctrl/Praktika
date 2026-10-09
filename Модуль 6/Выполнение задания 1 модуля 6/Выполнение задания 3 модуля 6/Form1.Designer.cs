namespace Выполнение_задания_3_модуля_6
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
            dataGridView = new DataGridView();
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            txtAuthor = new TextBox();
            label3 = new Label();
            txtYear = new TextBox();
            label4 = new Label();
            cmbStatus = new ComboBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            label5 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnRent = new Button();
            btnReturn = new Button();
            btnShowAll = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(10, 10);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(760, 280);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 300);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 1;
            label1.Text = "Название";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(93, 296);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(250, 27);
            txtTitle.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(370, 300);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 3;
            label2.Text = "Автор";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(427, 296);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(320, 27);
            txtAuthor.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 333);
            label3.Name = "label3";
            label3.Size = new Size(33, 20);
            label3.TabIndex = 5;
            label3.Text = "Год";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(93, 333);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(100, 27);
            txtYear.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(370, 333);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 7;
            label4.Text = "Статус";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Доступна", "На руках" });
            cmbStatus.Location = new Point(427, 333);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 28);
            cmbStatus.TabIndex = 8;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(802, 196);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 29);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "Поиск";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(802, 163);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 27);
            txtSearch.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(802, 140);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 11;
            label5.Text = "Поиск";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(10, 390);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(134, 29);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Добавить книгу";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(150, 390);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(250, 390);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRent
            // 
            btnRent.Location = new Point(350, 390);
            btnRent.Name = "btnRent";
            btnRent.Size = new Size(109, 29);
            btnRent.TabIndex = 15;
            btnRent.Text = "Арендовать";
            btnRent.UseVisualStyleBackColor = true;
            btnRent.Click += btnRent_Click;
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(465, 390);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(94, 29);
            btnReturn.TabIndex = 16;
            btnReturn.Text = "Вернуть";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(565, 390);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(157, 29);
            btnShowAll.TabIndex = 17;
            btnShowAll.Text = "Показать все книги";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 473);
            Controls.Add(btnShowAll);
            Controls.Add(btnReturn);
            Controls.Add(btnRent);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(label5);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(cmbStatus);
            Controls.Add(label4);
            Controls.Add(txtYear);
            Controls.Add(label3);
            Controls.Add(txtAuthor);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private TextBox txtAuthor;
        private Label label3;
        private TextBox txtYear;
        private Label label4;
        private ComboBox cmbStatus;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label label5;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRent;
        private Button btnReturn;
        private Button btnShowAll;
    }
}
