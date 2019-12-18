using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auto1;
using System.IO;

namespace GUI
{
    public partial class StatForm : Form
    {
        private Stat Statistics;
        private string OutputFileName = "results.txt";

        public StatForm(Stat Stat)
        {
            this.Statistics = Stat;
            InitializeComponent();
        }

        private void StatForm_Load(object sender, EventArgs e)
        {
            try
            {
                ProfitLabel.Text =Utils.StringToLength( Statistics.Profit.ToString(), 10);
                WagePerWorkerLabel.Text = Utils.StringToLength(Statistics.WagePerWorker.ToString(), 10);
                LostProfitLabel.Text = Utils.StringToLength(Statistics.LostProfit.ToString(), 10);
                LostWagePerWorker.Text = Utils.StringToLength(Statistics.LostWagePerWorker.ToString(), 10);

                NumberOfFinishedRequestsLabel.Text = Utils.StringToLength(Statistics.NumberOfFinishedRequests.ToString(), 10);
                FinishedInspectionTasksLabel.Text = Utils.StringToLength(Statistics.FinishedInspectionTasks.ToString(), 10);
                FinishedEngineRepairTasksLabel.Text = Utils.StringToLength(Statistics.FinishedEngineRepairTasks.ToString(), 10);
                FinishedTireFittingTasksLabel.Text = Utils.StringToLength(Statistics.FinishedTireFittingTasks.ToString(), 10);
                FinishedBodyRepairTasksLabel.Text = Utils.StringToLength(Statistics.FinishedBodyRepairTasks.ToString(), 10);

                AvgQueueLabel.Text = Utils.StringToLength(Statistics.AvgQueue.ToString(), 10);
                AvgWaitingTimeLable.Text = Utils.StringToLength(Statistics.AvgWaitingTime.ToString(), 10);
                AvgWorkingPercentLabel.Text = Utils.StringToLength(Statistics.AvgWorkingPercent.ToString(), 10);
                AvgWagePerDayLabel.Text = Utils.StringToLength(Statistics.AvgWagePerDay.ToString(), 10);


            }
            catch (Exception ex)
            {

            }
        }

        private void ToFileBtn_Click(object sender, EventArgs e)
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
                        byte[] buff = En.GetBytes(string.Format("[{0}]\n{1}", DateTime.Now, Statistics).ToCharArray());
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
