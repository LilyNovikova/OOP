namespace NewtonMethod
{
    partial class ProtocolForm
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
            this.ProtocolBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FunctionLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProtocolBox
            // 
            this.ProtocolBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProtocolBox.Location = new System.Drawing.Point(12, 88);
            this.ProtocolBox.Multiline = true;
            this.ProtocolBox.Name = "ProtocolBox";
            this.ProtocolBox.ReadOnly = true;
            this.ProtocolBox.Size = new System.Drawing.Size(723, 663);
            this.ProtocolBox.TabIndex = 0;
            this.ProtocolBox.TextChanged += new System.EventHandler(this.ProtocolBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Protocol of Newton algorithm for function";
            // 
            // FunctionLabel
            // 
            this.FunctionLabel.AutoSize = true;
            this.FunctionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FunctionLabel.Location = new System.Drawing.Point(16, 47);
            this.FunctionLabel.Name = "FunctionLabel";
            this.FunctionLabel.Size = new System.Drawing.Size(28, 24);
            this.FunctionLabel.TabIndex = 2;
            this.FunctionLabel.Text = "---";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(438, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(297, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save to file";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProtocolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 763);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FunctionLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProtocolBox);
            this.Name = "ProtocolForm";
            this.Text = "ProtocolForm";
            this.Load += new System.EventHandler(this.ProtocolForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProtocolBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FunctionLabel;
        private System.Windows.Forms.Button button1;
    }
}