namespace Выполнение_задания_3_модуля_5
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
            txtTask = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnAdd = new Button();
            IstTasks = new ListBox();
            btnRemove = new Button();
            btnDone = new Button();
            SuspendLayout();
            // 
            // txtTask
            // 
            txtTask.Font = new Font("Segoe UI", 11F);
            txtTask.Location = new Point(10, 10);
            txtTask.Name = "txtTask";
            txtTask.Size = new Size(300, 32);
            txtTask.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(320, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // IstTasks
            // 
            IstTasks.FormattingEnabled = true;
            IstTasks.IntegralHeight = false;
            IstTasks.Location = new Point(10, 50);
            IstTasks.Name = "IstTasks";
            IstTasks.Size = new Size(460, 250);
            IstTasks.TabIndex = 3;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(10, 310);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(150, 29);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "Удалить";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnDone
            // 
            btnDone.Location = new Point(170, 310);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(150, 29);
            btnDone.TabIndex = 5;
            btnDone.Text = "Выполнено";
            btnDone.UseVisualStyleBackColor = true;
            btnDone.Click += btnDone_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 474);
            Controls.Add(btnDone);
            Controls.Add(btnRemove);
            Controls.Add(IstTasks);
            Controls.Add(btnAdd);
            Controls.Add(txtTask);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTask;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnAdd;
        private ListBox IstTasks;
        private Button btnRemove;
        private Button btnDone;
    }
}
