namespace Выполнение_задания_3_модуля_9
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
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            cmbPriority = new ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label3 = new Label();
            dtpDueDate = new DateTimePicker();
            btnAdd = new Button();
            lstTasks = new ListBox();
            btnDelete = new Button();
            btnComplete = new Button();
            lblWarning = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "Название:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(106, 17);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(200, 27);
            txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(310, 20);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 2;
            label2.Text = "Приоритет:";
            // 
            // cmbPriority
            // 
            cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Items.AddRange(new object[] { "Высокий", "Средний", "Низкий" });
            cmbPriority.Location = new Point(404, 17);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(151, 28);
            cmbPriority.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 55);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 4;
            label3.Text = "Дата:";
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(70, 55);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(162, 27);
            dtpDueDate.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(260, 52);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 29);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Добавить задачу";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lstTasks
            // 
            lstTasks.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lstTasks.FormattingEnabled = true;
            lstTasks.ItemHeight = 22;
            lstTasks.Location = new Point(20, 95);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(545, 246);
            lstTasks.TabIndex = 7;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(220, 360);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(160, 30);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Удалить задачу";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnComplete
            // 
            btnComplete.Location = new Point(20, 360);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(194, 30);
            btnComplete.TabIndex = 9;
            btnComplete.Text = "Отметить выполненной";
            btnComplete.UseVisualStyleBackColor = true;
            btnComplete.Click += btnComplete_Click;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblWarning.Location = new Point(20, 405);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(168, 19);
            lblWarning.TabIndex = 10;
            lblWarning.Text = "Срочных задач нет";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 634);
            Controls.Add(lblWarning);
            Controls.Add(btnComplete);
            Controls.Add(btnDelete);
            Controls.Add(lstTasks);
            Controls.Add(btnAdd);
            Controls.Add(dtpDueDate);
            Controls.Add(label3);
            Controls.Add(cmbPriority);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private ComboBox cmbPriority;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label3;
        private DateTimePicker dtpDueDate;
        private Button btnAdd;
        private ListBox lstTasks;
        private Button btnDelete;
        private Button btnComplete;
        private Label lblWarning;
    }
}
