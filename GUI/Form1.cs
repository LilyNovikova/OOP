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
        private static string InputFileName = "input.txt";
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

        //приводит таблицу к нужному размеру
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
            //добавляем нужное количество колонок
            ColumnsToSize(Columns);
            //добавляем нужное количество рядов
            RowsToSize(Rows);

            //выставляем на счётчиках нужные значения
            ColumnsUpDown.Value = DataTable.ColumnCount;
            RowsUpDown.Value = DataTable.RowCount;
        }

        //записываем в таблицу формы значения из таблицы наборов
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

        //взять таблицу из файла
        private void DataFromFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] names = { "1", "2", "3", "4", "5", "6", "7", "8" };
                int[][] data = Utils.ToIntArray(FileUtils.ReadText(InputFileName), " ,\n");
                Table = new Table(names, data);
                //output table
                SetTable(Table);
            }
            catch (Exception ex)
            {
                ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
            }
        }

     
        //извлечение содержимого таблицы формы в строку 
        private string GetTableContent()
        {
            string content = "";
            int Rows = DataTable.RowCount;
            foreach (DataGridViewRow Row in DataTable.Rows)
            {
                foreach (DataGridViewCell Cell in Row.Cells)
                {
                    int value;
                    if (int.TryParse(Cell.Value.ToString(), out value))
                        content += Cell.Value.ToString() + ',';
                    else
                    {
                        throw new ArgumentException("Unallowed symbols in table");
                    }
                }
                content = content.TrimEnd(',');
                content += '\n';
            }
            content = content.TrimEnd('\n');
            return content;
        }
        //создаём таблицу наборов по значениями в таблице формы
        private void DataFromTable()
        {
            string[] names = new string[DataTable.RowCount];
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = i.ToString();
            }
            //получаем содержимое таблицы формы
            string content = GetTableContent();

            Table = new Table(names, Utils.ToIntArray(content.Split('\n'), " ,\n"));

        }

        private void SelectBtn_Click(object sender, EventArgs e)
        {
            if (Table != null)
            {
                try
                {
                    //получение таблицы
                    DataFromTable();
                    //селекция
                    Table.Optimize();
                    //вывод результата селекции
                    SetTable(Table);
                }
                catch (Exception ex)
                {
                    ExceptionLabel.Text = ex.GetType().ToString() + " " + ex.Message;
                }
            }
        }

        //очистка содержимого таблицы
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
