namespace Выполнение_задания_1_модуля_6
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
            txtName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPosition = new TextBox();
            txtSalary = new TextBox();
            label3 = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(10, 10);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(760, 300);
            dataGridView.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(10, 343);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 27);
            txtName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 320);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 2;
            label1.Text = "\"ФИО\"";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(270, 320);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 3;
            label2.Text = "Должность";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(270, 343);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(200, 27);
            txtPosition.TabIndex = 4;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(536, 343);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(200, 27);
            txtSalary.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(536, 320);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 6;
            label3.Text = "Зарплата";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(788, 78);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(184, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(788, 152);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(184, 29);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Обновить выбранного";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(788, 227);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(184, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Удалить выбранного";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1470, 703);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(label3);
            Controls.Add(txtSalary);
            Controls.Add(txtPosition);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtName);
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
        private TextBox txtName;
        private Label label1;
        private Label label2;
        private TextBox txtPosition;
        private TextBox txtSalary;
        private Label label3;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}
