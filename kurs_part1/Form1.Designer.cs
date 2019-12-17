using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace kurs_part1
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
            this.TransportTypeSelection = new System.Windows.Forms.ComboBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ModelLabel = new System.Windows.Forms.Label();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.SeatsLabel = new System.Windows.Forms.Label();
            this.CapacityLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.AddPropertyLabel = new System.Windows.Forms.Label();
            this.TransportSelection = new System.Windows.Forms.ComboBox();
            this.LModel = new System.Windows.Forms.Label();
            this.LSpeed = new System.Windows.Forms.Label();
            this.LWeight = new System.Windows.Forms.Label();
            this.LSeats = new System.Windows.Forms.Label();
            this.LCapacity = new System.Windows.Forms.Label();
            this.LPrice = new System.Windows.Forms.Label();
            this.LAddProperty = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TransportTypeSelection
            // 
            this.TransportTypeSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransportTypeSelection.FormattingEnabled = true;
            this.TransportTypeSelection.Location = new System.Drawing.Point(12, 12);
            this.TransportTypeSelection.Name = "TransportTypeSelection";
            this.TransportTypeSelection.Size = new System.Drawing.Size(270, 24);
            this.TransportTypeSelection.TabIndex = 0;
            this.TransportTypeSelection.SelectedIndexChanged += new System.EventHandler(this.TransportType_SelectedIndexChanged);
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(113, 135);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(68, 25);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Name";
            // 
            // ModelLabel
            // 
            this.ModelLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ModelLabel.AutoSize = true;
            this.ModelLabel.Location = new System.Drawing.Point(17, 176);
            this.ModelLabel.Name = "ModelLabel";
            this.ModelLabel.Size = new System.Drawing.Size(54, 17);
            this.ModelLabel.TabIndex = 3;
            this.ModelLabel.Text = "Model: ";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(17, 207);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(57, 17);
            this.SpeedLabel.TabIndex = 4;
            this.SpeedLabel.Text = "Speed: ";
            // 
            // WeightLabel
            // 
            this.WeightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Location = new System.Drawing.Point(17, 236);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(60, 17);
            this.WeightLabel.TabIndex = 5;
            this.WeightLabel.Text = "Weight: ";
            // 
            // SeatsLabel
            // 
            this.SeatsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SeatsLabel.AutoSize = true;
            this.SeatsLabel.Location = new System.Drawing.Point(17, 270);
            this.SeatsLabel.Name = "SeatsLabel";
            this.SeatsLabel.Size = new System.Drawing.Size(52, 17);
            this.SeatsLabel.TabIndex = 6;
            this.SeatsLabel.Text = "Seats: ";
            // 
            // CapacityLabel
            // 
            this.CapacityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CapacityLabel.AutoSize = true;
            this.CapacityLabel.Location = new System.Drawing.Point(17, 303);
            this.CapacityLabel.Name = "CapacityLabel";
            this.CapacityLabel.Size = new System.Drawing.Size(70, 17);
            this.CapacityLabel.TabIndex = 7;
            this.CapacityLabel.Text = "Capacity: ";
            // 
            // PriceLabel
            // 
            this.PriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(17, 338);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(48, 17);
            this.PriceLabel.TabIndex = 8;
            this.PriceLabel.Text = "Price: ";
            // 
            // AddPropertyLabel
            // 
            this.AddPropertyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddPropertyLabel.AutoSize = true;
            this.AddPropertyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddPropertyLabel.Location = new System.Drawing.Point(17, 368);
            this.AddPropertyLabel.Name = "AddPropertyLabel";
            this.AddPropertyLabel.Size = new System.Drawing.Size(132, 17);
            this.AddPropertyLabel.TabIndex = 9;
            this.AddPropertyLabel.Text = "Additional Property ";
            // 
            // TransportSelection
            // 
            this.TransportSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TransportSelection.FormattingEnabled = true;
            this.TransportSelection.Location = new System.Drawing.Point(12, 58);
            this.TransportSelection.Name = "TransportSelection";
            this.TransportSelection.Size = new System.Drawing.Size(270, 24);
            this.TransportSelection.TabIndex = 10;
            this.TransportSelection.SelectedIndexChanged += new System.EventHandler(this.TransportSelection_SelectedIndexChanged);
            // 
            // LModel
            // 
            this.LModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LModel.AutoSize = true;
            this.LModel.Location = new System.Drawing.Point(112, 176);
            this.LModel.Name = "LModel";
            this.LModel.Size = new System.Drawing.Size(13, 17);
            this.LModel.TabIndex = 11;
            this.LModel.Text = "-";
            // 
            // LSpeed
            // 
            this.LSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LSpeed.AutoSize = true;
            this.LSpeed.Location = new System.Drawing.Point(112, 207);
            this.LSpeed.Name = "LSpeed";
            this.LSpeed.Size = new System.Drawing.Size(13, 17);
            this.LSpeed.TabIndex = 12;
            this.LSpeed.Text = "-";
            // 
            // LWeight
            // 
            this.LWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LWeight.AutoSize = true;
            this.LWeight.Location = new System.Drawing.Point(112, 236);
            this.LWeight.Name = "LWeight";
            this.LWeight.Size = new System.Drawing.Size(13, 17);
            this.LWeight.TabIndex = 13;
            this.LWeight.Text = "-";
            // 
            // LSeats
            // 
            this.LSeats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LSeats.AutoSize = true;
            this.LSeats.Location = new System.Drawing.Point(112, 270);
            this.LSeats.Name = "LSeats";
            this.LSeats.Size = new System.Drawing.Size(13, 17);
            this.LSeats.TabIndex = 14;
            this.LSeats.Text = "-";
            // 
            // LCapacity
            // 
            this.LCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LCapacity.AutoSize = true;
            this.LCapacity.Location = new System.Drawing.Point(112, 303);
            this.LCapacity.Name = "LCapacity";
            this.LCapacity.Size = new System.Drawing.Size(13, 17);
            this.LCapacity.TabIndex = 15;
            this.LCapacity.Text = "-";
            // 
            // LPrice
            // 
            this.LPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LPrice.AutoSize = true;
            this.LPrice.Location = new System.Drawing.Point(112, 338);
            this.LPrice.Name = "LPrice";
            this.LPrice.Size = new System.Drawing.Size(13, 17);
            this.LPrice.TabIndex = 16;
            this.LPrice.Text = "-";
            // 
            // LAddProperty
            // 
            this.LAddProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LAddProperty.AutoSize = true;
            this.LAddProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LAddProperty.Location = new System.Drawing.Point(168, 368);
            this.LAddProperty.Name = "LAddProperty";
            this.LAddProperty.Size = new System.Drawing.Size(13, 17);
            this.LAddProperty.TabIndex = 17;
            this.LAddProperty.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 405);
            this.Controls.Add(this.LAddProperty);
            this.Controls.Add(this.LPrice);
            this.Controls.Add(this.LCapacity);
            this.Controls.Add(this.LSeats);
            this.Controls.Add(this.LWeight);
            this.Controls.Add(this.LSpeed);
            this.Controls.Add(this.LModel);
            this.Controls.Add(this.TransportSelection);
            this.Controls.Add(this.AddPropertyLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.CapacityLabel);
            this.Controls.Add(this.SeatsLabel);
            this.Controls.Add(this.WeightLabel);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.ModelLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.TransportTypeSelection);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TransportTypeSelection;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ModelLabel;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label WeightLabel;
        private System.Windows.Forms.Label SeatsLabel;
        private System.Windows.Forms.Label CapacityLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label AddPropertyLabel;
        private System.Windows.Forms.ComboBox TransportSelection;
        private System.Windows.Forms.Label LModel;
        private System.Windows.Forms.Label LSpeed;
        private System.Windows.Forms.Label LWeight;
        private System.Windows.Forms.Label LSeats;
        private System.Windows.Forms.Label LCapacity;
        private System.Windows.Forms.Label LPrice;
        private System.Windows.Forms.Label LAddProperty;


    }
}

