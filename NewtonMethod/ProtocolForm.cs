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
using OptMethod;
using System.IO;

namespace NewtonMethod
{
    public partial class ProtocolForm : Form
    {
        private Function F;
        private List<Matrix> points;
        private List<double> values;

        public ProtocolForm(Function F, List<Matrix> points, List<double> values)
        {
            InitializeComponent();
            this.F = F;
            this.points = points;
            this.values = values;
        }

        private void ProtocolBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProtocolForm_Load(object sender, EventArgs e)
        {
            FunctionLabel.Text = F.Expression;
            ProtocolBox.Text = "";
            for (int i = 0; i < points.Count; i++)
            {
                ProtocolBox.Text += " " + i + 
                    ": X (" + points.ElementAt(i).Transpose().ToString().TrimEnd(Environment.NewLine.ToCharArray()) + ")" + 
                    Environment.NewLine + "     F: " + values.ElementAt(i) + Environment.NewLine + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream DataStream;
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((DataStream = saveFileDialog1.OpenFile()) != null)
                    {
                        Encoding En = new UTF8Encoding();
                        byte[] buff = En.GetBytes(ProtocolBox.Text.ToCharArray());
                        DataStream.Write(buff, 0, buff.Length);
                        DataStream.Close();
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
