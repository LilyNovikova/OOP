namespace Interface
{
    partial class FordFulkerson
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
            this.Table = new System.Windows.Forms.DataGridView();
            this.NumNodesUpDown = new System.Windows.Forms.NumericUpDown();
            this.NumNodesLabel = new System.Windows.Forms.Label();
            this.FlowLabel = new System.Windows.Forms.Label();
            this.MaxFlowValueLabel = new System.Windows.Forms.Label();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.SinkLabel = new System.Windows.Forms.Label();
            this.SinkUpDown = new System.Windows.Forms.NumericUpDown();
            this.SourceUpDown = new System.Windows.Forms.NumericUpDown();
            this.ExceptionLabel = new System.Windows.Forms.Label();
            this.GraphFromFileBtn = new System.Windows.Forms.Button();
            this.CountMaxFlowBtn = new System.Windows.Forms.Button();
            this.ClearTableBtn = new System.Windows.Forms.Button();
            this.GraphFromTableBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumNodesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinkUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SourceUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // Table
            // 
            this.Table.AllowUserToAddRows = false;
            this.Table.AllowUserToDeleteRows = false;
            this.Table.AllowUserToResizeColumns = false;
            this.Table.AllowUserToResizeRows = false;
            this.Table.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Table.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Table.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(13, 56);
            this.Table.Name = "Table";
            this.Table.RowHeadersWidth = 50;
            this.Table.RowTemplate.Height = 24;
            this.Table.Size = new System.Drawing.Size(838, 621);
            this.Table.TabIndex = 0;
            // 
            // NumNodesUpDown
            // 
            this.NumNodesUpDown.Location = new System.Drawing.Point(195, 13);
            this.NumNodesUpDown.Name = "NumNodesUpDown";
            this.NumNodesUpDown.Size = new System.Drawing.Size(120, 22);
            this.NumNodesUpDown.TabIndex = 1;
            this.NumNodesUpDown.ValueChanged += new System.EventHandler(this.NumNodesUpDown_ValueChanged);
            // 
            // NumNodesLabel
            // 
            this.NumNodesLabel.AutoSize = true;
            this.NumNodesLabel.Location = new System.Drawing.Point(13, 17);
            this.NumNodesLabel.Name = "NumNodesLabel";
            this.NumNodesLabel.Size = new System.Drawing.Size(114, 17);
            this.NumNodesLabel.TabIndex = 2;
            this.NumNodesLabel.Text = "NumberOfNodes";
            // 
            // FlowLabel
            // 
            this.FlowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowLabel.AutoSize = true;
            this.FlowLabel.Location = new System.Drawing.Point(874, 248);
            this.FlowLabel.Name = "FlowLabel";
            this.FlowLabel.Size = new System.Drawing.Size(61, 17);
            this.FlowLabel.TabIndex = 3;
            this.FlowLabel.Text = "MaxFlow";
            // 
            // MaxFlowValueLabel
            // 
            this.MaxFlowValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxFlowValueLabel.AutoSize = true;
            this.MaxFlowValueLabel.Location = new System.Drawing.Point(1010, 248);
            this.MaxFlowValueLabel.Name = "MaxFlowValueLabel";
            this.MaxFlowValueLabel.Size = new System.Drawing.Size(13, 17);
            this.MaxFlowValueLabel.TabIndex = 4;
            this.MaxFlowValueLabel.Text = "-";
            // 
            // SourceLabel
            // 
            this.SourceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Location = new System.Drawing.Point(874, 87);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(91, 17);
            this.SourceLabel.TabIndex = 5;
            this.SourceLabel.Text = "Source Node";
            // 
            // SinkLabel
            // 
            this.SinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SinkLabel.AutoSize = true;
            this.SinkLabel.Location = new System.Drawing.Point(877, 168);
            this.SinkLabel.Name = "SinkLabel";
            this.SinkLabel.Size = new System.Drawing.Size(73, 17);
            this.SinkLabel.TabIndex = 6;
            this.SinkLabel.Text = "Sink Node";
            // 
            // SinkUpDown
            // 
            this.SinkUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SinkUpDown.Location = new System.Drawing.Point(971, 163);
            this.SinkUpDown.Name = "SinkUpDown";
            this.SinkUpDown.Size = new System.Drawing.Size(97, 22);
            this.SinkUpDown.TabIndex = 7;
            this.SinkUpDown.ValueChanged += new System.EventHandler(this.SinkUpDown_ValueChanged);
            // 
            // SourceUpDown
            // 
            this.SourceUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SourceUpDown.Location = new System.Drawing.Point(971, 82);
            this.SourceUpDown.Name = "SourceUpDown";
            this.SourceUpDown.Size = new System.Drawing.Size(97, 22);
            this.SourceUpDown.TabIndex = 8;
            this.SourceUpDown.ValueChanged += new System.EventHandler(this.SourceUpDown_ValueChanged);
            // 
            // ExceptionLabel
            // 
            this.ExceptionLabel.AutoSize = true;
            this.ExceptionLabel.Location = new System.Drawing.Point(358, 18);
            this.ExceptionLabel.Name = "ExceptionLabel";
            this.ExceptionLabel.Size = new System.Drawing.Size(0, 17);
            this.ExceptionLabel.TabIndex = 9;
            // 
            // GraphFromFileBtn
            // 
            this.GraphFromFileBtn.Location = new System.Drawing.Point(877, 357);
            this.GraphFromFileBtn.Name = "GraphFromFileBtn";
            this.GraphFromFileBtn.Size = new System.Drawing.Size(128, 44);
            this.GraphFromFileBtn.TabIndex = 10;
            this.GraphFromFileBtn.Text = "Graph from file";
            this.GraphFromFileBtn.UseVisualStyleBackColor = true;
            this.GraphFromFileBtn.Click += new System.EventHandler(this.GraphFromFileBtn_Click);
            // 
            // CountMaxFlowBtn
            // 
            this.CountMaxFlowBtn.Location = new System.Drawing.Point(877, 407);
            this.CountMaxFlowBtn.Name = "CountMaxFlowBtn";
            this.CountMaxFlowBtn.Size = new System.Drawing.Size(128, 45);
            this.CountMaxFlowBtn.TabIndex = 11;
            this.CountMaxFlowBtn.Text = "Count max flow";
            this.CountMaxFlowBtn.UseVisualStyleBackColor = true;
            this.CountMaxFlowBtn.Click += new System.EventHandler(this.CountMaxFlowBtn_Click);
            // 
            // ClearTableBtn
            // 
            this.ClearTableBtn.Location = new System.Drawing.Point(877, 458);
            this.ClearTableBtn.Name = "ClearTableBtn";
            this.ClearTableBtn.Size = new System.Drawing.Size(128, 47);
            this.ClearTableBtn.TabIndex = 12;
            this.ClearTableBtn.Text = "Clear table";
            this.ClearTableBtn.UseVisualStyleBackColor = true;
            this.ClearTableBtn.Click += new System.EventHandler(this.ClearTableBtn_Click);
            // 
            // GraphFromTableBtn
            // 
            this.GraphFromTableBtn.Location = new System.Drawing.Point(877, 301);
            this.GraphFromTableBtn.Name = "GraphFromTableBtn";
            this.GraphFromTableBtn.Size = new System.Drawing.Size(128, 50);
            this.GraphFromTableBtn.TabIndex = 13;
            this.GraphFromTableBtn.Text = "Graph from table";
            this.GraphFromTableBtn.UseVisualStyleBackColor = true;
            this.GraphFromTableBtn.Click += new System.EventHandler(this.GraphFromTableBtn_Click);
            // 
            // FordFulkerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1092, 702);
            this.Controls.Add(this.GraphFromTableBtn);
            this.Controls.Add(this.ClearTableBtn);
            this.Controls.Add(this.CountMaxFlowBtn);
            this.Controls.Add(this.GraphFromFileBtn);
            this.Controls.Add(this.ExceptionLabel);
            this.Controls.Add(this.SourceUpDown);
            this.Controls.Add(this.SinkUpDown);
            this.Controls.Add(this.SinkLabel);
            this.Controls.Add(this.SourceLabel);
            this.Controls.Add(this.MaxFlowValueLabel);
            this.Controls.Add(this.FlowLabel);
            this.Controls.Add(this.NumNodesLabel);
            this.Controls.Add(this.NumNodesUpDown);
            this.Controls.Add(this.Table);
            this.Name = "FordFulkerson";
            this.Text = "FordFulkerson";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumNodesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SinkUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SourceUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.NumericUpDown NumNodesUpDown;
        private System.Windows.Forms.Label NumNodesLabel;
        private System.Windows.Forms.Label FlowLabel;
        private System.Windows.Forms.Label MaxFlowValueLabel;
        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.Label SinkLabel;
        private System.Windows.Forms.NumericUpDown SinkUpDown;
        private System.Windows.Forms.NumericUpDown SourceUpDown;
        private System.Windows.Forms.Label ExceptionLabel;
        private System.Windows.Forms.Button GraphFromFileBtn;
        private System.Windows.Forms.Button CountMaxFlowBtn;
        private System.Windows.Forms.Button ClearTableBtn;
        private System.Windows.Forms.Button GraphFromTableBtn;
    }
}

