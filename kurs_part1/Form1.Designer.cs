﻿using System.Linq;
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
            this.TransportTypeSelection.FormattingEnabled = true;
            this.TransportTypeSelection.Items.AddRange(new object[] {
            "Car",
            "Boat",
            "Aircraft",
            "Train"});
            this.TransportTypeSelection.Location = new System.Drawing.Point(12, 12);
            this.TransportTypeSelection.Name = "TransportTypeSelection";
            this.TransportTypeSelection.Size = new System.Drawing.Size(135, 24);
            this.TransportTypeSelection.TabIndex = 0;
            this.TransportTypeSelection.Text = "Car";
            this.TransportTypeSelection.SelectedIndexChanged += new System.EventHandler(this.TransportType_SelectedIndexChanged);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(268, 60);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(68, 25);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Name";
            // 
            // ModelLabel
            // 
            this.ModelLabel.AutoSize = true;
            this.ModelLabel.Location = new System.Drawing.Point(17, 130);
            this.ModelLabel.Name = "ModelLabel";
            this.ModelLabel.Size = new System.Drawing.Size(54, 17);
            this.ModelLabel.TabIndex = 3;
            this.ModelLabel.Text = "Model: ";
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(17, 190);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(57, 17);
            this.SpeedLabel.TabIndex = 4;
            this.SpeedLabel.Text = "Speed: ";
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Location = new System.Drawing.Point(17, 257);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(60, 17);
            this.WeightLabel.TabIndex = 5;
            this.WeightLabel.Text = "Weight: ";
            // 
            // SeatsLabel
            // 
            this.SeatsLabel.AutoSize = true;
            this.SeatsLabel.Location = new System.Drawing.Point(342, 130);
            this.SeatsLabel.Name = "SeatsLabel";
            this.SeatsLabel.Size = new System.Drawing.Size(52, 17);
            this.SeatsLabel.TabIndex = 6;
            this.SeatsLabel.Text = "Seats: ";
            // 
            // CapacityLabel
            // 
            this.CapacityLabel.AutoSize = true;
            this.CapacityLabel.Location = new System.Drawing.Point(342, 190);
            this.CapacityLabel.Name = "CapacityLabel";
            this.CapacityLabel.Size = new System.Drawing.Size(70, 17);
            this.CapacityLabel.TabIndex = 7;
            this.CapacityLabel.Text = "Capacity: ";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(342, 257);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(48, 17);
            this.PriceLabel.TabIndex = 8;
            this.PriceLabel.Text = "Price: ";
            // 
            // AddPropertyLabel
            // 
            this.AddPropertyLabel.AutoSize = true;
            this.AddPropertyLabel.Location = new System.Drawing.Point(17, 371);
            this.AddPropertyLabel.Name = "AddPropertyLabel";
            this.AddPropertyLabel.Size = new System.Drawing.Size(132, 17);
            this.AddPropertyLabel.TabIndex = 9;
            this.AddPropertyLabel.Text = "Additional Property ";
            // 
            // TransportSelection
            // 
            this.TransportSelection.FormattingEnabled = true;
            this.TransportSelection.Location = new System.Drawing.Point(192, 12);
            this.TransportSelection.Name = "TransportSelection";
            this.TransportSelection.Size = new System.Drawing.Size(383, 24);
            this.TransportSelection.TabIndex = 10;
            this.TransportSelection.SelectedIndexChanged += new System.EventHandler(this.TransportSelection_SelectedIndexChanged);
            // 
            // LModel
            // 
            this.LModel.AutoSize = true;
            this.LModel.Location = new System.Drawing.Point(112, 130);
            this.LModel.Name = "LModel";
            this.LModel.Size = new System.Drawing.Size(13, 17);
            this.LModel.TabIndex = 11;
            this.LModel.Text = "-";
            // 
            // LSpeed
            // 
            this.LSpeed.AutoSize = true;
            this.LSpeed.Location = new System.Drawing.Point(115, 190);
            this.LSpeed.Name = "LSpeed";
            this.LSpeed.Size = new System.Drawing.Size(13, 17);
            this.LSpeed.TabIndex = 12;
            this.LSpeed.Text = "-";
            this.LSpeed.Click += new System.EventHandler(this.label2_Click);
            // 
            // LWeight
            // 
            this.LWeight.AutoSize = true;
            this.LWeight.Location = new System.Drawing.Point(115, 257);
            this.LWeight.Name = "LWeight";
            this.LWeight.Size = new System.Drawing.Size(13, 17);
            this.LWeight.TabIndex = 13;
            this.LWeight.Text = "-";
            // 
            // LSeats
            // 
            this.LSeats.AutoSize = true;
            this.LSeats.Location = new System.Drawing.Point(438, 130);
            this.LSeats.Name = "LSeats";
            this.LSeats.Size = new System.Drawing.Size(13, 17);
            this.LSeats.TabIndex = 14;
            this.LSeats.Text = "-";
            // 
            // LCapacity
            // 
            this.LCapacity.AutoSize = true;
            this.LCapacity.Location = new System.Drawing.Point(454, 190);
            this.LCapacity.Name = "LCapacity";
            this.LCapacity.Size = new System.Drawing.Size(13, 17);
            this.LCapacity.TabIndex = 15;
            this.LCapacity.Text = "-";
            // 
            // LPrice
            // 
            this.LPrice.AutoSize = true;
            this.LPrice.Location = new System.Drawing.Point(437, 257);
            this.LPrice.Name = "LPrice";
            this.LPrice.Size = new System.Drawing.Size(13, 17);
            this.LPrice.TabIndex = 16;
            this.LPrice.Text = "-";
            // 
            // LAddProperty
            // 
            this.LAddProperty.AutoSize = true;
            this.LAddProperty.Location = new System.Drawing.Point(192, 371);
            this.LAddProperty.Name = "LAddProperty";
            this.LAddProperty.Size = new System.Drawing.Size(13, 17);
            this.LAddProperty.TabIndex = 17;
            this.LAddProperty.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 441);
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

        private static Transport SelectedItem;
        private static IEnumerable SelectedList;
        public void TransportType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetTransportCollection(out SelectedList);
        }

        public void SetLabels(Transport T)
        {
            NameLabel.Text = T.Name;
            LModel.Text = T.Model;
            LSpeed.Text = T.Speed.ToString();
            LWeight.Text = T.Weight.ToString();
            LSeats.Text = T.Seats.ToString();
            LPrice.Text = T.Price.ToString();
            LCapacity.Text = T.Capacity.ToString();
            LAddProperty.Text = T.GetAddPropertyString();
        }

        public void TransportSelection_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
            try
            {
                string selection = TransportSelection.SelectedItem.ToString();
                try
                {
                    foreach (Transport T in SelectedList)
                    {
                        if (T.Name.Equals(selection))
                        {
                            SelectedItem = T;
                            SetLabels(T);
                            break;
                        }
                    }
                } 
                catch(NullReferenceException)
                {
                    
                }           
            }
            catch (InvalidOperationException)
            {

            }
        }

        public void SetTransportCollection(out IEnumerable SelectedList)
        {
            this.TransportSelection.Items.Clear();
            this.TransportSelection.Items.Add("None");
            this.TransportSelection.SelectedItem = "None";
            switch (TransportTypeSelection.SelectedItem.ToString())
            {
                default:
                    SelectedList = InputParser.Cars;
                    foreach (Car Item in InputParser.Cars)
                    {
                        this.TransportSelection.Items.Add(Item.ToString());
                    }
                    break;
                case "Boat":
                    SelectedList = InputParser.Boats;
                    foreach (Boat Item in InputParser.Boats)
                    {
                        this.TransportSelection.Items.Add(Item.ToString());
                    }
                    break;
                case "Aircraft":
                    SelectedList = InputParser.Aircrafts;
                    foreach (Aircraft Item in InputParser.Aircrafts)
                    {
                        this.TransportSelection.Items.Add(Item.ToString());
                    }
                    break;
                case "Train":
                    SelectedList = InputParser.Trains;
                    foreach (Train Item in InputParser.Trains)
                    {
                        this.TransportSelection.Items.Add(Item.ToString());
                    }
                    break;

            }
        }
    }
}

