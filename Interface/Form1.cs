using kurs_part3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class FordFulkerson : Form
    {

        private static string InputFileName = "net.txt";
        private static Web web;
        private static string[] FileContent;
        private static int Flow;

        public FordFulkerson()
        {
            InitializeComponent();
        }

        private void NumNodesUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (NumNodesUpDown.Value >= 0)
            {
                TableToSize((int)NumNodesUpDown.Value);
            }
            else
            {
                NumNodesUpDown.Value = 0;
            }
            ColorTableMediane();
            SourceUpDown.Value = 1;
            SinkUpDown.Value = NumNodesUpDown.Value;
        }

        private void SourceUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void SinkUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TableToSize(int size)
        {
            if (size != Table.ColumnCount)
            {
                if (size > Table.ColumnCount)
                {
                    while (size > Table.ColumnCount)
                    {
                        string ColumnName = (Table.ColumnCount + 1).ToString();
                        Table.Columns.Add(ColumnName, ColumnName);

                        DataGridViewRow row = new DataGridViewRow();
                        row.HeaderCell = new DataGridViewRowHeaderCell();
                        row.HeaderCell.Value = Table.ColumnCount.ToString();
                        Table.Rows.Add(row);
                    }
                }
                else
                {
                    while (size < Table.ColumnCount)
                    {
                        try
                        {
                            Table.Rows.RemoveAt(Table.RowCount - 1);
                        }
                        catch (InvalidOperationException e)
                        {
                            ExceptionLabel.Text = e.GetType().ToString() + " " + e.Message;
                        }

                        Table.Columns.RemoveAt(Table.ColumnCount - 1);
                    }
                }
            }

        }

        private void SetTableValues(Web Web)
        {
            foreach (Edge E in Web.Edges)
            {
                try
                {
                    Table[int.Parse(E.End.Name) - 1, int.Parse(E.Begin.Name) - 1].Value = string.Format("{0}", E.Bandwidth);
                }
                catch (Exception e)
                {
                    ExceptionLabel.Text = e.GetType().ToString() + " " + e.Message;
                }
            }
        }

        private void SetFlowValues(Web Web)
        {
            foreach (Edge E in Web.Edges)
            {
                try
                {
                    Table[int.Parse(E.End.Name) - 1, int.Parse(E.Begin.Name) - 1].Value = string.Format("{0}/{1}", E.Flow, E.Bandwidth);
                }
                catch (Exception e)
                {
                    ExceptionLabel.Text = e.GetType().ToString() + " " + e.Message;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void GraphFromFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                FileContent = FileUtils.ReadText(InputFileName);
                web = new Web();
                web.SourceName = FileContent[0].Split(' ')[0];
                web.SinkName = FileContent[0].Split(' ')[1];
                web.AddEdges(FileContent);
                TableToSize(web.NumberNodes);
                SetTableValues(web);
                SinkUpDown.Value = int.Parse(web.SinkName);
                SourceUpDown.Value = int.Parse(web.SourceName);
                NumNodesUpDown.Value = web.NumberNodes;
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }

        }

        private void CountMaxFlowBtn_Click(object sender, EventArgs e)
        {
            try
            {
                GraphFromTable();
                if (web.NumberEdges == 0)
                {
                    ExceptionLabel.Text = "Please, enter graph parameters";
                }
                else
                {
                    web.FordFulkersonAlgorithm();
                    Flow = web.SummFlow();
                    MaxFlowValueLabel.Text = Flow.ToString();
                    SetFlowValues(web);
                }
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
        }

        private void ClearTableBtn_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Table.RowCount; i++)
                {
                    for (int j = 0; j < Table.ColumnCount; j++)
                    {
                        Table[j, i].Value = "";
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
        }

        private void GraphFromTable()
        {
            Flow = 0;
            web = new Web();
            web.SourceName = SourceUpDown.Value.ToString();
            web.SinkName = SinkUpDown.Value.ToString();

            for (int i = 0; i < Table.RowCount; i++)
            {
                for (int j = 0; j < Table.ColumnCount; j++)
                {
                    int Bandwidth = 0;
                    try
                    {
                        if (int.TryParse(Table[j, i].Value.ToString(), out Bandwidth))
                        {
                            if (i == j)
                            {
                                Table[j, i].Value = "";
                                ExceptionLabel.Text = "Loops are not allowed in this graph";
                            }
                            else
                            {
                                web.AddEdge((i + 1).ToString(), (j + 1).ToString(), Bandwidth);
                                Table[j, i].Value = string.Format("{0}/{1}", 0, Bandwidth);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
                    }
                }
            }
        }

        private void ColorTableMediane()
        {
            try
            {
                for (int i = 0; i < Table.RowCount; i++)
                {
                    Table[i, i].Style.BackColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
        }
    }
}
