namespace Выполнение_модуля_8
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
            panel1 = new Panel();
            btnDelete = new Button();
            label1 = new Label();
            txtTitle = new TextBox();
            label2 = new Label();
            txtDescription = new TextBox();
            label3 = new Label();
            lstMarkers = new ListBox();
            lblInfo = new Label();
            picMap = new PictureBox();
            lblCoords = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMap).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 727);
            panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(10, 435);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(220, 29);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Удалить выбранную";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 20);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 0;
            label1.Text = "Название точки:";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(10, 45);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(220, 27);
            txtTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 80);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 2;
            label2.Text = "Описание:";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(10, 105);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(220, 60);
            txtDescription.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 220);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 5;
            label3.Text = "Список точек:";
            // 
            // lstMarkers
            // 
            lstMarkers.FormattingEnabled = true;
            lstMarkers.Location = new Point(10, 245);
            lstMarkers.Name = "lstMarkers";
            lstMarkers.Size = new Size(220, 184);
            lstMarkers.TabIndex = 6;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.BorderStyle = BorderStyle.FixedSingle;
            lblInfo.Location = new Point(10, 500);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(149, 22);
            lblInfo.TabIndex = 7;
            lblInfo.Text = "Кликните по карте...";
            // 
            // picMap
            // 
            picMap.BackColor = Color.White;
            picMap.Dock = DockStyle.Fill;
            picMap.Location = new Point(250, 0);
            picMap.Name = "picMap";
            picMap.Size = new Size(1404, 727);
            picMap.TabIndex = 8;
            picMap.TabStop = false;
            picMap.Paint += picMap_Paint;
            picMap.MouseClick += picMap_MouseClick;
            picMap.MouseMove += picMap_MouseMove;
            // 
            // lblCoords
            // 
            lblCoords.AutoSize = true;
            lblCoords.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblCoords.Location = new Point(256, 698);
            lblCoords.Name = "lblCoords";
            lblCoords.Size = new Size(78, 23);
            lblCoords.TabIndex = 9;
            lblCoords.Text = "X: 0, Y: 0.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1654, 727);
            Controls.Add(lblCoords);
            Controls.Add(picMap);
            Controls.Add(lblInfo);
            Controls.Add(lstMarkers);
            Controls.Add(label3);
            Controls.Add(txtDescription);
            Controls.Add(label2);
            Controls.Add(txtTitle);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private TextBox txtDescription;
        private Label label3;
        private ListBox lstMarkers;
        private Button btnDelete;
        private Label lblInfo;
        private PictureBox picMap;
        private Label lblCoords;
    }
}
