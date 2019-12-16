namespace OptMethod
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FuncTextBox = new System.Windows.Forms.TextBox();
            this.ParseFuncBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ResultsTextBox = new System.Windows.Forms.TextBox();
            this.ExceptionLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FindMinBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.X1ValBox = new System.Windows.Forms.TextBox();
            this.X2ValBox = new System.Windows.Forms.TextBox();
            this.X1WidthBox = new System.Windows.Forms.TextBox();
            this.X2WidthBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TolBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FuncTextBox
            // 
            this.FuncTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FuncTextBox.Location = new System.Drawing.Point(29, 32);
            this.FuncTextBox.Name = "FuncTextBox";
            this.FuncTextBox.Size = new System.Drawing.Size(468, 22);
            this.FuncTextBox.TabIndex = 0;
            // 
            // ParseFuncBtn
            // 
            this.ParseFuncBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ParseFuncBtn.Location = new System.Drawing.Point(520, 30);
            this.ParseFuncBtn.Name = "ParseFuncBtn";
            this.ParseFuncBtn.Size = new System.Drawing.Size(105, 23);
            this.ParseFuncBtn.TabIndex = 1;
            this.ParseFuncBtn.Text = "Enter";
            this.ParseFuncBtn.UseVisualStyleBackColor = true;
            this.ParseFuncBtn.Click += new System.EventHandler(this.ParseFuncBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "X1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(342, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "X2:";
            // 
            // ResultsTextBox
            // 
            this.ResultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsTextBox.Location = new System.Drawing.Point(29, 246);
            this.ResultsTextBox.Multiline = true;
            this.ResultsTextBox.Name = "ResultsTextBox";
            this.ResultsTextBox.ReadOnly = true;
            this.ResultsTextBox.Size = new System.Drawing.Size(593, 275);
            this.ResultsTextBox.TabIndex = 6;
            // 
            // ExceptionLabel
            // 
            this.ExceptionLabel.AutoSize = true;
            this.ExceptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExceptionLabel.Location = new System.Drawing.Point(32, 169);
            this.ExceptionLabel.Name = "ExceptionLabel";
            this.ExceptionLabel.Size = new System.Drawing.Size(71, 17);
            this.ExceptionLabel.TabIndex = 7;
            this.ExceptionLabel.Text = "_______";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Results of searching function minimum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Function";
            // 
            // FindMinBtn
            // 
            this.FindMinBtn.Location = new System.Drawing.Point(520, 71);
            this.FindMinBtn.Name = "FindMinBtn";
            this.FindMinBtn.Size = new System.Drawing.Size(105, 54);
            this.FindMinBtn.TabIndex = 10;
            this.FindMinBtn.Text = "Find min";
            this.FindMinBtn.UseVisualStyleBackColor = true;
            this.FindMinBtn.Click += new System.EventHandler(this.FindMinBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Search start point:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Search area width:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(342, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "X2:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(164, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "X1:";
            // 
            // X1ValBox
            // 
            this.X1ValBox.Location = new System.Drawing.Point(209, 74);
            this.X1ValBox.Name = "X1ValBox";
            this.X1ValBox.Size = new System.Drawing.Size(100, 22);
            this.X1ValBox.TabIndex = 17;
            // 
            // X2ValBox
            // 
            this.X2ValBox.Location = new System.Drawing.Point(377, 74);
            this.X2ValBox.Name = "X2ValBox";
            this.X2ValBox.Size = new System.Drawing.Size(100, 22);
            this.X2ValBox.TabIndex = 18;
            // 
            // X1WidthBox
            // 
            this.X1WidthBox.Location = new System.Drawing.Point(209, 103);
            this.X1WidthBox.Name = "X1WidthBox";
            this.X1WidthBox.Size = new System.Drawing.Size(100, 22);
            this.X1WidthBox.TabIndex = 19;
            // 
            // X2WidthBox
            // 
            this.X2WidthBox.Location = new System.Drawing.Point(377, 102);
            this.X2WidthBox.Name = "X2WidthBox";
            this.X2WidthBox.Size = new System.Drawing.Size(100, 22);
            this.X2WidthBox.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tolerance: ";
            // 
            // TolBox
            // 
            this.TolBox.Location = new System.Drawing.Point(118, 139);
            this.TolBox.Name = "TolBox";
            this.TolBox.Size = new System.Drawing.Size(100, 22);
            this.TolBox.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 547);
            this.Controls.Add(this.TolBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.X2WidthBox);
            this.Controls.Add(this.X1WidthBox);
            this.Controls.Add(this.X2ValBox);
            this.Controls.Add(this.X1ValBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FindMinBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ExceptionLabel);
            this.Controls.Add(this.ResultsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ParseFuncBtn);
            this.Controls.Add(this.FuncTextBox);
            this.Name = "Form1";
            this.Text = "Optimisation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FuncTextBox;
        private System.Windows.Forms.Button ParseFuncBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ResultsTextBox;
        private System.Windows.Forms.Label ExceptionLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button FindMinBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox X1ValBox;
        private System.Windows.Forms.TextBox X2ValBox;
        private System.Windows.Forms.TextBox X1WidthBox;
        private System.Windows.Forms.TextBox X2WidthBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TolBox;
    }
}