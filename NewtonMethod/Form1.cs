using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Functions;
using NewtonMethod;

namespace OptMethod
{
    public partial class Form1 : Form
    {
        private static Function F;
        private static Matrix StartPoint;
        private static int MaxVariables = 4;
        private static int feval;
        private static int iterations = 0;
        private static Matrix MinPoint;
        private static double MinValue;
        private static List<Matrix> points;
        private static List<double> values;
        public Form1()
        {
            InitializeComponent();
        }

        private void XUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void XUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        //парсинг введённой функции
        private void ParseFuncBtn_Click(object sender, EventArgs e)
        {
            try
            {
                F = new Function(FuncTextBox.Text);
                if (F.NumberOfVariables <= MaxVariables)
                {
                    X1ValBox.Enabled = true;
                    X2ValBox.Enabled = true;
                    X3ValBox.Enabled = true;
                    X4ValBox.Enabled = true;
                    TolBox.Enabled = true;
                    TolBox.Text = Optimisation.Tolerance.ToString();
                }
                else
                {
                    ExceptionLabel.Text = string.Format("Too many variables: {0} (possible only 1 or 2)", F.NumberOfVariables);
                }
                ResultsTextBox.Clear();
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            X1ValBox.Enabled = false;
            X2ValBox.Enabled = false;
            X3ValBox.Enabled = false;
            X4ValBox.Enabled = false;
            TolBox.Enabled = false;
            ProtocolBtn.Enabled = false;
        }

        //поиск минимума
        private void FindMinBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<double> StartP = new List<double>();
                if (F.NumberOfVariables > 0)
                {
                    StartP.Add(double.Parse(X1ValBox.Text));
                }
                if (F.NumberOfVariables > 1)
                {
                    StartP.Add(double.Parse(X2ValBox.Text));
                }
                if (F.NumberOfVariables > 2)
                {
                    StartP.Add(double.Parse(X3ValBox.Text));
                }
                if (F.NumberOfVariables > 3)
                {
                    StartP.Add(double.Parse(X4ValBox.Text));
                }


                StartPoint = new Matrix(StartP);
                Optimisation.Tolerance = double.Parse(TolBox.Text);

                MinValue = Math.Round(Optimisation.Newton(F, StartPoint, out feval, out points, out values, out MinPoint), 10);
                iterations = values.Count;
                ShowResults();
                ProtocolBtn.Enabled = true;
            }
            catch (OutOfMemoryException ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + ": tolerance value is too small";

            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
        }

        private void ShowResults()
        {
            ResultsTextBox.Text = "Min value: " + MinValue + Environment.NewLine
                + "Point of minimum: " + Environment.NewLine + MinPoint.ToString()
                + Environment.NewLine + "Feval: " + feval + Environment.NewLine +
                "Iterations: " + iterations + Environment.NewLine +
                "Tolerance: " + Optimisation.Tolerance;


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void ProtocolBtn_Click(object sender, EventArgs e)
        {
            ProtocolForm P = new ProtocolForm(F, points, values);
            P.ShowDialog();
        }
    }
}
