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
        private int ImitStep = 120;
        private int MaxImitStep = 10080;
        private static int DefaultWorkersNumber = 2;
        private int InspectionWorkersNum = DefaultWorkersNumber;
        private int EngineRepairWorkersNum = DefaultWorkersNumber;
        private int TireFittingWorkersNum = DefaultWorkersNumber;
        private int BodyRepairWorkersNum = DefaultWorkersNumber;
        private bool IsPaused = true;
        private Timer Timer;

        public Form1()
        {
            InitializeComponent();
        }

        //проверка, не приостановлено ли моделирование
        private void Check(object sender, EventArgs e)
        {
            try
            {
                //если да, останавливаем таймер
                if (IsPaused)
                {
                    Timer.Stop();
                }
                else //иначе моделируем следующий шаг
                {
                    ImitNextStep();
                    Timer.Start();
                }
            }
            catch (Exception)
            {
            }
        }

        //выводим в форму очереди в цехах
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

        //выводим текущие заявки 
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
            //если моделирование остановлено - запускаем
            //и наоборот
            IsPaused = !IsPaused;
            StatusLabel.Text = IsPaused ? "Pause" : "Play";
            Check(this, e);
        }

        //вывод сообщения об удалении заявки
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

        //вывод сообщения о появлении заявки
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

        //моделирование следующего шага
        private void ImitNextStep()
        {
            //если автосервис пока не инициализирован
            if (Admin == null)
            {
                //считываем параметры сервиса
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
            //выводим текущие проценты занятости рабочих
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
            //выставление значений по умолчанию
            ImitStepUpDown.Maximum = MaxImitStep;
            ImitStepUpDown.Value = ImitStep;
            InspectionUpDown.Value = DefaultWorkersNumber;
            EngineRepairUpDown.Value = DefaultWorkersNumber;
            TireFittingUpDown.Value = DefaultWorkersNumber;
            BodyRepairUpDown.Value = DefaultWorkersNumber;

            //создание таймера обновления 
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
