namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.DataFromFileBtn = new System.Windows.Forms.Button();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.RowsUpDown = new System.Windows.Forms.NumericUpDown();
            this.ColumnsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ExceptionLabel = new System.Windows.Forms.Label();
            this.ClearTableBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToAddRows = false;
            this.DataTable.AllowUserToDeleteRows = false;
            this.DataTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Location = new System.Drawing.Point(12, 125);
            this.DataTable.Name = "DataTable";
            this.DataTable.RowTemplate.Height = 24;
            this.DataTable.Size = new System.Drawing.Size(766, 419);
            this.DataTable.TabIndex = 0;
            this.DataTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataTable_CellContentClick);
            // 
            // DataFromFileBtn
            // 
            this.DataFromFileBtn.Location = new System.Drawing.Point(258, 12);
            this.DataFromFileBtn.Name = "DataFromFileBtn";
            this.DataFromFileBtn.Size = new System.Drawing.Size(226, 23);
            this.DataFromFileBtn.TabIndex = 2;
            this.DataFromFileBtn.Text = "Data from input file";
            this.DataFromFileBtn.UseVisualStyleBackColor = true;
            this.DataFromFileBtn.Click += new System.EventHandler(this.DataFromFileBtn_Click);
            // 
            // SelectBtn
            // 
            this.SelectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectBtn.Location = new System.Drawing.Point(538, 11);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(226, 52);
            this.SelectBtn.TabIndex = 3;
            this.SelectBtn.Text = "Select sets";
            this.SelectBtn.UseVisualStyleBackColor = true;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // RowsUpDown
            // 
            this.RowsUpDown.Location = new System.Drawing.Point(85, 12);
            this.RowsUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.RowsUpDown.Name = "RowsUpDown";
            this.RowsUpDown.Size = new System.Drawing.Size(120, 22);
            this.RowsUpDown.TabIndex = 4;
            this.RowsUpDown.ValueChanged += new System.EventHandler(this.RowsUpDown_ValueChanged);
            // 
            // ColumnsUpDown
            // 
            this.ColumnsUpDown.Location = new System.Drawing.Point(85, 41);
            this.ColumnsUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ColumnsUpDown.Name = "ColumnsUpDown";
            this.ColumnsUpDown.Size = new System.Drawing.Size(120, 22);
            this.ColumnsUpDown.TabIndex = 5;
            this.ColumnsUpDown.ValueChanged += new System.EventHandler(this.ColumnsUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Columns";
            // 
            // ExceptionLabel
            // 
            this.ExceptionLabel.AutoSize = true;
            this.ExceptionLabel.Location = new System.Drawing.Point(13, 95);
            this.ExceptionLabel.Name = "ExceptionLabel";
            this.ExceptionLabel.Size = new System.Drawing.Size(28, 17);
            this.ExceptionLabel.TabIndex = 8;
            this.ExceptionLabel.Text = "OK";
            // 
            // ClearTableBtn
            // 
            this.ClearTableBtn.Location = new System.Drawing.Point(258, 41);
            this.ClearTableBtn.Name = "ClearTableBtn";
            this.ClearTableBtn.Size = new System.Drawing.Size(226, 23);
            this.ClearTableBtn.TabIndex = 9;
            this.ClearTableBtn.Text = "Clear table";
            this.ClearTableBtn.UseVisualStyleBackColor = true;
            this.ClearTableBtn.Click += new System.EventHandler(this.ClearTableBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 556);
            this.Controls.Add(this.ClearTableBtn);
            this.Controls.Add(this.ExceptionLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColumnsUpDown);
            this.Controls.Add(this.RowsUpDown);
            this.Controls.Add(this.SelectBtn);
            this.Controls.Add(this.DataFromFileBtn);
            this.Controls.Add(this.DataTable);
            this.Name = "Form1";
            this.Text = "Data selection";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnsUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.Button DataFromFileBtn;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.NumericUpDown RowsUpDown;
        private System.Windows.Forms.NumericUpDown ColumnsUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ExceptionLabel;
        private System.Windows.Forms.Button ClearTableBtn;
    }
}

