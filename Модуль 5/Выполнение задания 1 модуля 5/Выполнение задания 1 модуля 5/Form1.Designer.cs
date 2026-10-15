namespace Выполнение_задания_1_модуля_5
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
            btnLine = new Button();
            btnCircle = new Button();
            btnRectangle = new Button();
            SuspendLayout();
            // 
            // btnLine
            // 
            btnLine.Location = new Point(12, 2);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(109, 44);
            btnLine.TabIndex = 0;
            btnLine.Text = "Линия";
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;
            // 
            // btnCircle
            // 
            btnCircle.Location = new Point(127, 2);
            btnCircle.Name = "btnCircle";
            btnCircle.Size = new Size(109, 44);
            btnCircle.TabIndex = 1;
            btnCircle.Text = "Круг";
            btnCircle.UseVisualStyleBackColor = true;
            btnCircle.Click += btnCircle_Click;
            // 
            // btnRectangle
            // 
            btnRectangle.Location = new Point(242, 2);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(109, 44);
            btnRectangle.TabIndex = 2;
            btnRectangle.Text = "Квадрат";
            btnRectangle.UseVisualStyleBackColor = true;
            btnRectangle.Click += btnRectangle_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1329, 664);
            Controls.Add(btnRectangle);
            Controls.Add(btnCircle);
            Controls.Add(btnLine);
            Name = "Form1";
            Text = "Form1";
            Paint += Form1_Paint;
            MouseDown += Form1_MouseDown;
            MouseUp += Form1_MouseUp;
            ResumeLayout(false);
        }

        #endregion

        private Button btnLine;
        private Button btnCircle;
        private Button btnRectangle;
    }
}
