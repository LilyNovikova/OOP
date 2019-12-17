using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs_part1
{
    public partial class Form1 : Form
    {
        private static IEnumerable SelectedList;
        private static Dictionary<string, IEnumerable> Lists = new Dictionary<string, IEnumerable>();
        public void TransportType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //добавляение соответствующего списка 
            TransportSelection.Items.Clear();
            //получаем из словаря нужный список
            Lists.TryGetValue(TransportTypeSelection.SelectedItem.ToString(), out SelectedList);
            //добавляем дефолтный вариант
            this.TransportSelection.Items.Add("None");
            this.TransportSelection.SelectedItem = "None";
            //добавляем элементы списка в combobox
            foreach (Transport T in SelectedList)
            {
                TransportSelection.Items.Add(T);
            }
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
                //вывод значений полей выбранного экземпляра
                SetLabels((Transport)TransportSelection.SelectedItem);
            }
            catch (InvalidCastException)
            {

            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //добавляем в словарь список с ключом и ключ в 
                TransportTypeSelection.Items.Add("Cars");
                Lists.Add("Cars", InputParser.Cars);
                TransportTypeSelection.Items.Add("Boats");
                Lists.Add("Boats", InputParser.Boats);
                TransportTypeSelection.Items.Add("Aircrafts");
                Lists.Add("Aircrafts", InputParser.Aircrafts);
                TransportTypeSelection.Items.Add("Trains");
                Lists.Add("Trains", InputParser.Trains);
            }
            catch (ArgumentNullException)
            {

            }
        }
    }
}
