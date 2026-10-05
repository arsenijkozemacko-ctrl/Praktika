namespace Выполнение_задания_5_модуля_5
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
            txtDisplay = new TextBox();
            btn1 = new Button();
            button2 = new Button();
            button3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnDiv = new Button();
            btnMinus = new Button();
            btnMul = new Button();
            btn0 = new Button();
            btnDot = new Button();
            btnEq = new Button();
            btnPlus = new Button();
            btnClear = new Button();
            SuspendLayout();
            // 
            // txtDisplay
            // 
            txtDisplay.Font = new Font("Arial Narrow", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtDisplay.Location = new Point(63, 67);
            txtDisplay.Name = "txtDisplay";
            txtDisplay.Size = new Size(310, 38);
            txtDisplay.TabIndex = 0;
            // 
            // btn1
            // 
            btn1.Location = new Point(63, 325);
            btn1.Name = "btn1";
            btn1.Size = new Size(70, 60);
            btn1.TabIndex = 1;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btnClear_Click;
            // 
            // button2
            // 
            button2.Location = new Point(139, 325);
            button2.Name = "button2";
            button2.Size = new Size(70, 60);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnClear_Click;
            // 
            // button3
            // 
            button3.Location = new Point(215, 325);
            button3.Name = "button3";
            button3.Size = new Size(70, 60);
            button3.TabIndex = 3;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnClear_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(63, 259);
            btn4.Name = "btn4";
            btn4.Size = new Size(70, 60);
            btn4.TabIndex = 4;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btnClear_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(139, 259);
            btn5.Name = "btn5";
            btn5.Size = new Size(70, 60);
            btn5.TabIndex = 5;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btnClear_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(215, 259);
            btn6.Name = "btn6";
            btn6.Size = new Size(70, 60);
            btn6.TabIndex = 6;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btnClear_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(63, 193);
            btn7.Name = "btn7";
            btn7.Size = new Size(70, 60);
            btn7.TabIndex = 7;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btnClear_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(139, 193);
            btn8.Name = "btn8";
            btn8.Size = new Size(70, 60);
            btn8.TabIndex = 8;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btnClear_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(215, 193);
            btn9.Name = "btn9";
            btn9.Size = new Size(70, 60);
            btn9.TabIndex = 9;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btnClear_Click;
            // 
            // btnDiv
            // 
            btnDiv.Location = new Point(303, 193);
            btnDiv.Name = "btnDiv";
            btnDiv.Size = new Size(70, 60);
            btnDiv.TabIndex = 10;
            btnDiv.Text = "/";
            btnDiv.UseVisualStyleBackColor = true;
            btnDiv.Click += btnClear_Click;
            // 
            // btnMinus
            // 
            btnMinus.Location = new Point(303, 325);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(70, 60);
            btnMinus.TabIndex = 11;
            btnMinus.Text = "−";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += btnClear_Click;
            // 
            // btnMul
            // 
            btnMul.Location = new Point(303, 259);
            btnMul.Name = "btnMul";
            btnMul.Size = new Size(70, 60);
            btnMul.TabIndex = 12;
            btnMul.Text = "*";
            btnMul.UseVisualStyleBackColor = true;
            btnMul.Click += btnClear_Click;
            // 
            // btn0
            // 
            btn0.Location = new Point(63, 403);
            btn0.Name = "btn0";
            btn0.Size = new Size(70, 60);
            btn0.TabIndex = 13;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btnClear_Click;
            // 
            // btnDot
            // 
            btnDot.Location = new Point(139, 403);
            btnDot.Name = "btnDot";
            btnDot.Size = new Size(70, 60);
            btnDot.TabIndex = 14;
            btnDot.Text = ".";
            btnDot.UseVisualStyleBackColor = true;
            btnDot.Click += btnClear_Click;
            // 
            // btnEq
            // 
            btnEq.Location = new Point(215, 403);
            btnEq.Name = "btnEq";
            btnEq.Size = new Size(70, 60);
            btnEq.TabIndex = 15;
            btnEq.Text = "=";
            btnEq.UseVisualStyleBackColor = true;
            btnEq.Click += btnClear_Click;
            // 
            // btnPlus
            // 
            btnPlus.Location = new Point(303, 403);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(70, 60);
            btnPlus.TabIndex = 16;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += btnClear_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(215, 127);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(70, 60);
            btnClear.TabIndex = 17;
            btnClear.Text = "С";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 536);
            Controls.Add(btnClear);
            Controls.Add(btnPlus);
            Controls.Add(btnEq);
            Controls.Add(btnDot);
            Controls.Add(btn0);
            Controls.Add(btnMul);
            Controls.Add(btnMinus);
            Controls.Add(btnDiv);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btn1);
            Controls.Add(txtDisplay);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDisplay;
        private Button btn1;
        private Button button2;
        private Button button3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnDiv;
        private Button btnMinus;
        private Button btnMul;
        private Button btn0;
        private Button btnDot;
        private Button btnEq;
        private Button btnPlus;
        private Button btnClear;
    }
}
