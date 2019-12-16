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

namespace OptMethod
{
    public partial class Form1 : Form
    {
        private static Function F;
        private static Matrix StartPoint;
        private static Matrix AreaWidth;
        private static int feval = 0;
        private static Matrix MinPoint;
        private static double MinValue;
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

        private void ParseFuncBtn_Click(object sender, EventArgs e)
        {
            try
            {
                F = new Function(FuncTextBox.Text);
                if (F.NumberOfVariables <= 2)
                {
                    X1ValBox.Enabled = true;
                    X2ValBox.Enabled = true;
                    X1WidthBox.Enabled = true;
                    X2WidthBox.Enabled = true;
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
            X1WidthBox.Enabled = false;
            X2WidthBox.Enabled = false;
            TolBox.Enabled = false;
        }

        private void FindMinBtn_Click(object sender, EventArgs e)
        {
            try
            {
                List<double> StartP = new List<double>();
                StartP.Add(double.Parse(X1ValBox.Text));
                StartP.Add(double.Parse(X2ValBox.Text));

                List<double> Widths = new List<double>();
                Widths.Add(double.Parse(X1WidthBox.Text));
                Widths.Add(double.Parse(X2WidthBox.Text));

                StartPoint = new Matrix(StartP);
                AreaWidth = new Matrix(Widths);
                Optimisation.Tolerance = double.Parse(TolBox.Text);

                MinValue = Optimisation.FindMinimum(F, StartPoint, AreaWidth, out feval, out MinPoint);
                ShowResults();
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
                "Tolerance: " + Optimisation.Tolerance;


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
