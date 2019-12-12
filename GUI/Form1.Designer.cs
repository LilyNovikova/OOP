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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.InspectionRoomLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.EngineRepairRoomLabel = new System.Windows.Forms.Label();
            this.TireFittingRoomLabel = new System.Windows.Forms.Label();
            this.BodyRepairRoomLabel = new System.Windows.Forms.Label();
            this.InspectionUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.EngineRepairUpDown = new System.Windows.Forms.NumericUpDown();
            this.TireFittingUpDown = new System.Windows.Forms.NumericUpDown();
            this.BodyRepairUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.ImitStepUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ImitBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ExceptionLabel = new System.Windows.Forms.Label();
            this.InspectionQBox = new System.Windows.Forms.TextBox();
            this.EngineRepairQBox = new System.Windows.Forms.TextBox();
            this.TireFittingQBox = new System.Windows.Forms.TextBox();
            this.BodyRepairQBox = new System.Windows.Forms.TextBox();
            this.StatBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.InspectionPercentLabel = new System.Windows.Forms.Label();
            this.EngineRepairPercentLabel = new System.Windows.Forms.Label();
            this.TireFittingPercentLabel = new System.Windows.Forms.Label();
            this.BodyRepairPercentLabel = new System.Windows.Forms.Label();
            this.OverdueLabel = new System.Windows.Forms.Label();
            this.NewRequestLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InspectionUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EngineRepairUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TireFittingUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyRepairUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImitStepUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(183, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inspertion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(344, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Engine Repair";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(540, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tire Fitting";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(706, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Body Repair";
            // 
            // InspectionRoomLabel
            // 
            this.InspectionRoomLabel.AutoSize = true;
            this.InspectionRoomLabel.Location = new System.Drawing.Point(146, 87);
            this.InspectionRoomLabel.Name = "InspectionRoomLabel";
            this.InspectionRoomLabel.Size = new System.Drawing.Size(13, 17);
            this.InspectionRoomLabel.TabIndex = 8;
            this.InspectionRoomLabel.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Current Requests: ";
            // 
            // EngineRepairRoomLabel
            // 
            this.EngineRepairRoomLabel.AutoSize = true;
            this.EngineRepairRoomLabel.Location = new System.Drawing.Point(324, 87);
            this.EngineRepairRoomLabel.Name = "EngineRepairRoomLabel";
            this.EngineRepairRoomLabel.Size = new System.Drawing.Size(13, 17);
            this.EngineRepairRoomLabel.TabIndex = 10;
            this.EngineRepairRoomLabel.Text = "-";
            // 
            // TireFittingRoomLabel
            // 
            this.TireFittingRoomLabel.AutoSize = true;
            this.TireFittingRoomLabel.Location = new System.Drawing.Point(514, 87);
            this.TireFittingRoomLabel.Name = "TireFittingRoomLabel";
            this.TireFittingRoomLabel.Size = new System.Drawing.Size(13, 17);
            this.TireFittingRoomLabel.TabIndex = 11;
            this.TireFittingRoomLabel.Text = "-";
            // 
            // BodyRepairRoomLabel
            // 
            this.BodyRepairRoomLabel.AutoSize = true;
            this.BodyRepairRoomLabel.Location = new System.Drawing.Point(692, 87);
            this.BodyRepairRoomLabel.Name = "BodyRepairRoomLabel";
            this.BodyRepairRoomLabel.Size = new System.Drawing.Size(13, 17);
            this.BodyRepairRoomLabel.TabIndex = 12;
            this.BodyRepairRoomLabel.Text = "-";
            // 
            // InspectionUpDown
            // 
            this.InspectionUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InspectionUpDown.Location = new System.Drawing.Point(149, 693);
            this.InspectionUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.InspectionUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.InspectionUpDown.Name = "InspectionUpDown";
            this.InspectionUpDown.Size = new System.Drawing.Size(146, 22);
            this.InspectionUpDown.TabIndex = 13;
            this.InspectionUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.InspectionUpDown.ValueChanged += new System.EventHandler(this.InspectionUpDown_ValueChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 697);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "Number of workers: ";
            // 
            // EngineRepairUpDown
            // 
            this.EngineRepairUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EngineRepairUpDown.Location = new System.Drawing.Point(327, 693);
            this.EngineRepairUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.EngineRepairUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.EngineRepairUpDown.Name = "EngineRepairUpDown";
            this.EngineRepairUpDown.Size = new System.Drawing.Size(161, 22);
            this.EngineRepairUpDown.TabIndex = 15;
            this.EngineRepairUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.EngineRepairUpDown.ValueChanged += new System.EventHandler(this.EngineRepairUpDown_ValueChanged);
            // 
            // TireFittingUpDown
            // 
            this.TireFittingUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TireFittingUpDown.Location = new System.Drawing.Point(517, 692);
            this.TireFittingUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.TireFittingUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.TireFittingUpDown.Name = "TireFittingUpDown";
            this.TireFittingUpDown.Size = new System.Drawing.Size(154, 22);
            this.TireFittingUpDown.TabIndex = 16;
            this.TireFittingUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.TireFittingUpDown.ValueChanged += new System.EventHandler(this.TireFittingUpDown_ValueChanged);
            // 
            // BodyRepairUpDown
            // 
            this.BodyRepairUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BodyRepairUpDown.Location = new System.Drawing.Point(695, 689);
            this.BodyRepairUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.BodyRepairUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.BodyRepairUpDown.Name = "BodyRepairUpDown";
            this.BodyRepairUpDown.Size = new System.Drawing.Size(157, 22);
            this.BodyRepairUpDown.TabIndex = 17;
            this.BodyRepairUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.BodyRepairUpDown.ValueChanged += new System.EventHandler(this.BodyRepairUpDown_ValueChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(964, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 17);
            this.label11.TabIndex = 18;
            this.label11.Text = "Imitation Step";
            // 
            // ImitStepUpDown
            // 
            this.ImitStepUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImitStepUpDown.Location = new System.Drawing.Point(951, 41);
            this.ImitStepUpDown.Name = "ImitStepUpDown";
            this.ImitStepUpDown.Size = new System.Drawing.Size(120, 22);
            this.ImitStepUpDown.TabIndex = 19;
            this.ImitStepUpDown.ValueChanged += new System.EventHandler(this.ImitStepUpDown_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Room: ";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "Queue:";
            // 
            // ImitBtn
            // 
            this.ImitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ImitBtn.BackColor = System.Drawing.Color.Lime;
            this.ImitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImitBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ImitBtn.Location = new System.Drawing.Point(927, 689);
            this.ImitBtn.Name = "ImitBtn";
            this.ImitBtn.Size = new System.Drawing.Size(161, 64);
            this.ImitBtn.TabIndex = 22;
            this.ImitBtn.Text = "Imitation";
            this.ImitBtn.UseVisualStyleBackColor = false;
            this.ImitBtn.Click += new System.EventHandler(this.ImitBtn_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(900, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.Location = new System.Drawing.Point(967, 87);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(56, 20);
            this.StatusLabel.TabIndex = 24;
            this.StatusLabel.Text = "Pause";
            // 
            // ExceptionLabel
            // 
            this.ExceptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ExceptionLabel.AutoSize = true;
            this.ExceptionLabel.Location = new System.Drawing.Point(14, 736);
            this.ExceptionLabel.Name = "ExceptionLabel";
            this.ExceptionLabel.Size = new System.Drawing.Size(28, 17);
            this.ExceptionLabel.TabIndex = 25;
            this.ExceptionLabel.Text = "OK";
            // 
            // InspectionQBox
            // 
            this.InspectionQBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InspectionQBox.BackColor = System.Drawing.Color.White;
            this.InspectionQBox.Location = new System.Drawing.Point(149, 239);
            this.InspectionQBox.Multiline = true;
            this.InspectionQBox.Name = "InspectionQBox";
            this.InspectionQBox.ReadOnly = true;
            this.InspectionQBox.Size = new System.Drawing.Size(146, 433);
            this.InspectionQBox.TabIndex = 26;
            // 
            // EngineRepairQBox
            // 
            this.EngineRepairQBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.EngineRepairQBox.BackColor = System.Drawing.Color.White;
            this.EngineRepairQBox.Location = new System.Drawing.Point(327, 239);
            this.EngineRepairQBox.Multiline = true;
            this.EngineRepairQBox.Name = "EngineRepairQBox";
            this.EngineRepairQBox.ReadOnly = true;
            this.EngineRepairQBox.Size = new System.Drawing.Size(161, 433);
            this.EngineRepairQBox.TabIndex = 27;
            // 
            // TireFittingQBox
            // 
            this.TireFittingQBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TireFittingQBox.BackColor = System.Drawing.Color.White;
            this.TireFittingQBox.Location = new System.Drawing.Point(517, 239);
            this.TireFittingQBox.Multiline = true;
            this.TireFittingQBox.Name = "TireFittingQBox";
            this.TireFittingQBox.ReadOnly = true;
            this.TireFittingQBox.Size = new System.Drawing.Size(154, 433);
            this.TireFittingQBox.TabIndex = 28;
            // 
            // BodyRepairQBox
            // 
            this.BodyRepairQBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BodyRepairQBox.BackColor = System.Drawing.Color.White;
            this.BodyRepairQBox.Location = new System.Drawing.Point(695, 239);
            this.BodyRepairQBox.Multiline = true;
            this.BodyRepairQBox.Name = "BodyRepairQBox";
            this.BodyRepairQBox.ReadOnly = true;
            this.BodyRepairQBox.Size = new System.Drawing.Size(157, 433);
            this.BodyRepairQBox.TabIndex = 29;
            // 
            // StatBtn
            // 
            this.StatBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StatBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.StatBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatBtn.Location = new System.Drawing.Point(967, 591);
            this.StatBtn.Name = "StatBtn";
            this.StatBtn.Size = new System.Drawing.Size(88, 81);
            this.StatBtn.TabIndex = 30;
            this.StatBtn.Text = "Show stat";
            this.StatBtn.UseVisualStyleBackColor = false;
            this.StatBtn.Click += new System.EventHandler(this.StatBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 17);
            this.label7.TabIndex = 31;
            this.label7.Text = "Working Time Percent:";
            // 
            // InspectionPercentLabel
            // 
            this.InspectionPercentLabel.AutoSize = true;
            this.InspectionPercentLabel.Location = new System.Drawing.Point(204, 43);
            this.InspectionPercentLabel.Name = "InspectionPercentLabel";
            this.InspectionPercentLabel.Size = new System.Drawing.Size(32, 17);
            this.InspectionPercentLabel.TabIndex = 32;
            this.InspectionPercentLabel.Text = "0 %";
            // 
            // EngineRepairPercentLabel
            // 
            this.EngineRepairPercentLabel.AutoSize = true;
            this.EngineRepairPercentLabel.Location = new System.Drawing.Point(377, 43);
            this.EngineRepairPercentLabel.Name = "EngineRepairPercentLabel";
            this.EngineRepairPercentLabel.Size = new System.Drawing.Size(32, 17);
            this.EngineRepairPercentLabel.TabIndex = 33;
            this.EngineRepairPercentLabel.Text = "0 %";
            // 
            // TireFittingPercentLabel
            // 
            this.TireFittingPercentLabel.AutoSize = true;
            this.TireFittingPercentLabel.Location = new System.Drawing.Point(561, 43);
            this.TireFittingPercentLabel.Name = "TireFittingPercentLabel";
            this.TireFittingPercentLabel.Size = new System.Drawing.Size(32, 17);
            this.TireFittingPercentLabel.TabIndex = 34;
            this.TireFittingPercentLabel.Text = "0 %";
            // 
            // BodyRepairPercentLabel
            // 
            this.BodyRepairPercentLabel.AutoSize = true;
            this.BodyRepairPercentLabel.Location = new System.Drawing.Point(730, 43);
            this.BodyRepairPercentLabel.Name = "BodyRepairPercentLabel";
            this.BodyRepairPercentLabel.Size = new System.Drawing.Size(32, 17);
            this.BodyRepairPercentLabel.TabIndex = 35;
            this.BodyRepairPercentLabel.Text = "0 %";
            // 
            // OverdueLabel
            // 
            this.OverdueLabel.AutoSize = true;
            this.OverdueLabel.Location = new System.Drawing.Point(875, 308);
            this.OverdueLabel.Name = "OverdueLabel";
            this.OverdueLabel.Size = new System.Drawing.Size(0, 17);
            this.OverdueLabel.TabIndex = 36;
            // 
            // NewRequestLabel
            // 
            this.NewRequestLabel.AutoSize = true;
            this.NewRequestLabel.Location = new System.Drawing.Point(878, 239);
            this.NewRequestLabel.Name = "NewRequestLabel";
            this.NewRequestLabel.Size = new System.Drawing.Size(0, 17);
            this.NewRequestLabel.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 774);
            this.Controls.Add(this.NewRequestLabel);
            this.Controls.Add(this.OverdueLabel);
            this.Controls.Add(this.BodyRepairPercentLabel);
            this.Controls.Add(this.TireFittingPercentLabel);
            this.Controls.Add(this.EngineRepairPercentLabel);
            this.Controls.Add(this.InspectionPercentLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.StatBtn);
            this.Controls.Add(this.BodyRepairQBox);
            this.Controls.Add(this.TireFittingQBox);
            this.Controls.Add(this.EngineRepairQBox);
            this.Controls.Add(this.InspectionQBox);
            this.Controls.Add(this.ExceptionLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ImitBtn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ImitStepUpDown);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BodyRepairUpDown);
            this.Controls.Add(this.TireFittingUpDown);
            this.Controls.Add(this.EngineRepairUpDown);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.InspectionUpDown);
            this.Controls.Add(this.BodyRepairRoomLabel);
            this.Controls.Add(this.TireFittingRoomLabel);
            this.Controls.Add(this.EngineRepairRoomLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.InspectionRoomLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Autoservice";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InspectionUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EngineRepairUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TireFittingUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyRepairUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImitStepUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label InspectionRoomLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label EngineRepairRoomLabel;
        private System.Windows.Forms.Label TireFittingRoomLabel;
        private System.Windows.Forms.Label BodyRepairRoomLabel;
        private System.Windows.Forms.NumericUpDown InspectionUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown EngineRepairUpDown;
        private System.Windows.Forms.NumericUpDown TireFittingUpDown;
        private System.Windows.Forms.NumericUpDown BodyRepairUpDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown ImitStepUpDown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button ImitBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label ExceptionLabel;
        private System.Windows.Forms.TextBox InspectionQBox;
        private System.Windows.Forms.TextBox EngineRepairQBox;
        private System.Windows.Forms.TextBox TireFittingQBox;
        private System.Windows.Forms.TextBox BodyRepairQBox;
        private System.Windows.Forms.Button StatBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label InspectionPercentLabel;
        private System.Windows.Forms.Label EngineRepairPercentLabel;
        private System.Windows.Forms.Label TireFittingPercentLabel;
        private System.Windows.Forms.Label BodyRepairPercentLabel;
        private System.Windows.Forms.Label OverdueLabel;
        private System.Windows.Forms.Label NewRequestLabel;
    }
}

