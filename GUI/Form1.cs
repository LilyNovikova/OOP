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

namespace GUI
{
    public partial class Form1 : Form
    {
        private const int TimerFrqcy = 1000;
        private Admin Admin = null;
        private int ImitStep = 0;
        private static int DefaultworkersNumber = 2;
        private int InspectionWorkersNum = DefaultworkersNumber;
        private int EngineRepairWorkersNum = DefaultworkersNumber;
        private int TireFittingWorkersNum = DefaultworkersNumber;
        private int BodyRepairWorkersNum = DefaultworkersNumber;
        private bool IsPaused = true;
        private Timer Timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Check(object sender, EventArgs e)
        {
            try
            {

                if (IsPaused)
                {
                    Timer.Stop();
                }
                else
                {
                    ImitNextStep();
                    Timer.Start();
                }
            }
            catch (Exception)
            {
            }
        }

        private void SetQueues()
        {
            foreach (Room R in Admin.RoomsList)
            {
                if (R.Type == Request.TaskTypes.Inspection)
                {
                    InspectionQBox.Text = Utils.ToString(R.GetRequestsQueue());
                }
                else if (R.Type == Request.TaskTypes.EngineRepair)
                {
                    EngineRepairQBox.Text = Utils.ToString(R.GetRequestsQueue());
                }
                else if (R.Type == Request.TaskTypes.TireFitting)
                {
                    TireFittingQBox.Text = Utils.ToString(R.GetRequestsQueue());
                }
                else if (R.Type == Request.TaskTypes.BodyRepair)
                {
                    BodyRepairQBox.Text = Utils.ToString(R.GetRequestsQueue());
                }
            }
        }

        private void SetCurrentRequests()
        {
            foreach (Room R in Admin.RoomsList)
            {
                if (R.Type == Request.TaskTypes.Inspection)
                {
                    InspectionRoomLabel.Text = Utils.ToString(R.GetProcessingRequests());
                }
                else if (R.Type == Request.TaskTypes.EngineRepair)
                {
                    EngineRepairRoomLabel.Text = Utils.ToString(R.GetProcessingRequests());
                }
                else if (R.Type == Request.TaskTypes.TireFitting)
                {
                    TireFittingRoomLabel.Text = Utils.ToString(R.GetProcessingRequests());
                }
                else if (R.Type == Request.TaskTypes.BodyRepair)
                {
                    BodyRepairRoomLabel.Text = Utils.ToString(R.GetProcessingRequests());
                }
            }
        }

        private void ImitBtn_Click(object sender, EventArgs e)
        {
            IsPaused = !IsPaused;
            StatusLabel.Text = IsPaused ? "Pause" : "Play";
            Check(sender, e);
        }

        private void ShowRemovedRequest(object obj, Request Request)
        {
            try
            {
                OverdueLabel.Text = "R#" + Request.Id + " is overdue" + Environment.NewLine + "Lost Profit: " + Request.FutureAddPrice;
            }
            catch (InvalidOperationException)
            {

            }
        }

        private void ShowReceivedRequest(object obj, Request Request)
        {
            try
            {
                NewRequestLabel.Text = "New request R#" + Request.Id + Environment.NewLine + "Tasks: " + Request.TasksToDoList.Count + Environment.NewLine + "Price: " + Request.FutureAddPrice;
            }
            catch (InvalidOperationException)
            {

            }
        }

        private void ImitNextStep()
        {
            if (Admin == null)
            {
                if (ImitStepUpDown.Value <= 0)
                {
                    ExceptionLabel.Text = "Imitation step must be > 0";
                }
                if (InspectionUpDown.Value <= 0)
                {
                    ExceptionLabel.Text = "Number of workers in Inspection room must be > 0";
                }
                if (EngineRepairUpDown.Value <= 0)
                {
                    ExceptionLabel.Text = "Number of workers in Engine repair room must be > 0";
                }
                if (TireFittingUpDown.Value <= 0)
                {
                    ExceptionLabel.Text = "Number of workers in Tire Fitting room must be > 0";
                }
                if (BodyRepairUpDown.Value <= 0)
                {
                    ExceptionLabel.Text = "Number of workers in Body repair room must be > 0";
                }
                ConfigParser config = new ConfigParser();
                Admin = new Admin((int)ImitStepUpDown.Value,
                    (int)InspectionUpDown.Value,
                    (int)EngineRepairUpDown.Value,
                    (int)TireFittingUpDown.Value,
                    (int)BodyRepairUpDown.Value);
                Admin.RequestRemoved += ShowRemovedRequest;
                Admin.RequestReceived += ShowReceivedRequest;
            }
            Admin.GoToNextImitStep();
            BodyRepairPercentLabel.Text = string.Format("{0, 3} %", Admin.Statistics.BodyRepairCurrentWorkingTimePercent.ToString());
            EngineRepairPercentLabel.Text = string.Format("{0, 3} %", Admin.Statistics.EngineRepairCurrentWorkingTimePercent.ToString());
            TireFittingPercentLabel.Text = string.Format("{0, 3} %", Admin.Statistics.TireFittingCurrentWorkingTimePercent.ToString());
            InspectionPercentLabel.Text = string.Format("{0, 3} %", Admin.Statistics.InspectionCurrentWorkingTimePercent.ToString());

            try
            {
                ExceptionLabel.Text = "Time: " + Schedule.GetTimeString() + " [" + Admin.Now + "] Next request: " + Schedule.GetTimeString(Admin.NextRequestReceivingTime);

            }
            catch (InvalidOperationException)
            {

            }
            SetCurrentRequests();
            SetQueues();
        }

        private void ImitStepUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ImitStepUpDown.Value <= 0)
            {
                ExceptionLabel.Text = "Imitation step must be > 0";
            }
        }

        private void InspectionUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (InspectionUpDown.Value <= 0)
            {
                ExceptionLabel.Text = "Number of workers in Inspection room must be > 0";
            }
            else
            {
                InspectionWorkersNum = (int)InspectionUpDown.Value;
            }
        }

        private void EngineRepairUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (EngineRepairUpDown.Value <= 0)
            {
                ExceptionLabel.Text = "Number of workers in Engine repair room must be > 0";
            }
            else
            {
                EngineRepairWorkersNum = (int)EngineRepairUpDown.Value;
            }
        }

        private void TireFittingUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (TireFittingUpDown.Value <= 0)
            {
                ExceptionLabel.Text = "Number of workers in Tire Fitting room must be > 0";
            }
            else
            {
                TireFittingWorkersNum = (int)TireFittingUpDown.Value;
            }

        }

        private void BodyRepairUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (BodyRepairUpDown.Value <= 0)
            {
                ExceptionLabel.Text = "Number of workers in Body repair room must be > 0";
            }
            else
            {
                BodyRepairWorkersNum = (int)BodyRepairUpDown.Value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImitStepUpDown.Maximum = 10080;
            ImitStepUpDown.Value = 120;
            InspectionUpDown.Value = DefaultworkersNumber;
            EngineRepairUpDown.Value = DefaultworkersNumber;
            TireFittingUpDown.Value = DefaultworkersNumber;
            BodyRepairUpDown.Value = DefaultworkersNumber;
            Timer = new Timer();
            Timer.Interval = TimerFrqcy;
            Timer.Tick += new EventHandler(Check);
            Timer.Start();
        }

        private void StatBtn_Click(object sender, EventArgs e)
        {
            try
            {
                StatForm StatF = new StatForm(Admin.Statistics);
                StatF.Owner = this;
                if (!IsPaused)
                {
                    ImitBtn_Click(sender, e);
                }
                StatF.ShowDialog();

            }
            catch (NullReferenceException)
            {
                try
                {
                    ExceptionLabel.Text = "Can't show statistics";

                }
                catch (InvalidOperationException)
                {

                }
            }

        }
    }
}
