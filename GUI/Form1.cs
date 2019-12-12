using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kurs_part2;

namespace GUI
{
    public partial class Form1 : Form
    {
        private static string InputFileName = "net.txt";
        private static string[] FileContent;
        private static Table Table;

        public Form1()
        {
            InitializeComponent();
        }

        private void RowsUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (RowsUpDown.Value >= 0)
            {
                TableToSize((int)RowsUpDown.Value, (int)ColumnsUpDown.Value);
            }
            else
            {
                RowsUpDown.Value = 0;
            }
        }

        private void ColumnsUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ColumnsUpDown.Value >= 0)
            {
                TableToSize((int)RowsUpDown.Value, (int)ColumnsUpDown.Value);
            }
            else
            {
                ColumnsUpDown.Value = 0;
            }
        }

        private void RowsToSize(int Rows)
        {
            if (Rows != DataTable.RowCount)
            {
                if (Rows > DataTable.RowCount)
                {
                    while (Rows > DataTable.RowCount)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.HeaderCell = new DataGridViewRowHeaderCell();
                        row.HeaderCell.Value = (DataTable.RowCount + 1).ToString();
                        DataTable.Rows.Add(row);
                    }
                }
                else
                {
                    while (Rows < DataTable.RowCount)
                        try
                        {
                            DataTable.Rows.RemoveAt(DataTable.RowCount - 1);
                        }
                        catch (InvalidOperationException e)
                        {
                            ExceptionLabel.Text = e.GetType().ToString() + " " + e.Message;
                        }
                }
            }
        }

        private void ColumnsToSize(int Columns)
        {
            if (Columns != DataTable.ColumnCount)
            {
                if (Columns > DataTable.ColumnCount)
                {
                    while (Columns > DataTable.ColumnCount)
                    {
                        string ColumnName = (DataTable.ColumnCount + 1).ToString();
                        DataTable.Columns.Add(ColumnName, "P" + ColumnName);
                    }
                }
                else
                {
                    while (Columns < DataTable.ColumnCount)
                    {
                        DataTable.Columns.RemoveAt(DataTable.ColumnCount - 1);
                    }
                }
            }
        }

        private void TableToSize(int Rows, int Columns)
        {
            //add rows when there is no columns
            if (Rows > 0 && DataTable.ColumnCount == 0 && Columns == 0)
            {
                ColumnsUpDown.Value = 1;
                Columns = 1;
            }
            //delete last column
            else if (Rows > 0 && DataTable.ColumnCount != 0 && Columns == 0)
            {
                RowsUpDown.Value = 0;
                Rows = 0;
            }
            //delete last row
            else if (Rows == 0 && DataTable.ColumnCount != 0 && Columns != 0)
            {
                ColumnsUpDown.Value = 0;
                Columns = 0;
            }
            ColumnsToSize(Columns);
            RowsToSize(Rows);

            ColumnsUpDown.Value = DataTable.ColumnCount;
            RowsUpDown.Value = DataTable.RowCount;
        }

        private void SetTableValues(Table T)
        {
            int i = 0;
            foreach (Set S in T)
            {
                int j = 0;
                foreach (int param in S)
                {
                    try
                    {
                        DataTable[j, i].Value = param.ToString();
                    }
                    catch (Exception e)
                    {
                        ExceptionLabel.Text = e.GetType().ToString() + " " + e.Message;
                    }
                }

            }
        }

        private void SetTable(Table T)
        {
            try
            {
                ColumnsUpDown.Value = T.ColumnsCount;
                RowsUpDown.Value = T.RowsCount;
                ColumnsUpDown_ValueChanged(this, new EventArgs());
                //output table
                int RowIndex = 0;
                int ColumnIndex = 0;
                foreach (Set Set in T)
                {
                    foreach (int Item in Set)
                    {
                        DataTable[ColumnIndex, RowIndex].Value = Item;
                        ColumnIndex++;
                    }
                    ColumnIndex = 0;
                    RowIndex++;
                }
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
        }

        private void DataFromFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] names = { "1", "2", "3", "4", "5", "6", "7", "8" };
                int[][] data = Utils.ToIntArray(FileUtils.ReadText("input.txt"), " ,\n");
                Table = new Table(names, data);
                //output table
                SetTable(Table);
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
        }

        private string GetTableContent()
        {
            string content = "";
            try
            {
                int Rows = DataTable.RowCount;
                foreach (DataGridViewRow Row in DataTable.Rows)
                {
                    foreach (DataGridViewCell Cell in Row.Cells)
                    {
                        int value;
                        if (int.TryParse(Cell.Value.ToString(), out value))
                            content += Cell.Value.ToString() + ',';
                    }
                    content = content.TrimEnd(',');
                    content += '\n';
                }
                content = content.TrimEnd('\n');
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
            return content;
        }
        private void DataFromTableBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] names = new string[DataTable.RowCount];
                for (int i = 0; i < names.Length; i++)
                {
                    names[i] = i.ToString();
                }
                string content = GetTableContent();
                Table = new Table(names, Utils.ToIntArray(content.Split('\n'), " ,\n"));
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (Table != null)
            {
                Table.Optimize();
                SetTable(Table);
            }
        }

        private void ClearTableBtn_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < DataTable.RowCount; i++)
                {
                    for (int j = 0; j < DataTable.ColumnCount; j++)
                    {
                        DataTable[j, i].Value = "";
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
