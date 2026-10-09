namespace Выполнение_задания_4_модуля_6
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
            cmbType = new ComboBox();
            txtCategory = new TextBox();
            txtAmount = new TextBox();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnCalculate = new Button();
            lblType = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblBalance = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(10, 10);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(760, 260);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Доход", "Расход" });
            cmbType.Location = new Point(60, 280);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(150, 28);
            cmbType.TabIndex = 1;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(320, 280);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(200, 27);
            txtCategory.TabIndex = 2;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(600, 280);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(150, 27);
            txtAmount.TabIndex = 3;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(100, 320);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(420, 27);
            txtDescription.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(10, 360);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 29);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(170, 360);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 29);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(330, 360);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 29);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(490, 360);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(150, 29);
            btnCalculate.TabIndex = 8;
            btnCalculate.Text = "Подсчитать";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(10, 280);
            lblType.Name = "lblType";
            lblType.Size = new Size(35, 20);
            lblType.TabIndex = 9;
            lblType.Text = "Тип";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(230, 280);
            label1.Name = "label1";
            label1.Size = new Size(81, 20);
            label1.TabIndex = 10;
            label1.Text = "Категория";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(540, 280);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 11;
            label2.Text = "Сумма";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 320);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 12;
            label3.Text = "Описание";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblBalance.Location = new Point(10, 400);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(122, 24);
            lblBalance.TabIndex = 13;
            lblBalance.Text = "Баланс: 0 руб.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 433);
            Controls.Add(lblBalance);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblType);
            Controls.Add(btnCalculate);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtDescription);
            Controls.Add(txtAmount);
            Controls.Add(txtCategory);
            Controls.Add(cmbType);
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
        private ComboBox cmbType;
        private TextBox txtCategory;
        private TextBox txtAmount;
        private TextBox txtDescription;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnCalculate;
        private Label lblType;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblBalance;
    }
}
