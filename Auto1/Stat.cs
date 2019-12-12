using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1
{
    public class Stat
    {
        private int DaysPassed = Schedule.GetDayNumber() - 1;
        private int WorkersAmount;
        private int WagePercent = ConfigParser.WagePercent;

        ////current 
        public double InspectionCurrentWorkingTimePercent { get; private set; } = 0;
        public double EngineRepairCurrentWorkingTimePercent { get; private set; } = 0;
        public double TireFittingCurrentWorkingTimePercent { get; private set; } = 0;
        public double BodyRepairCurrentWorkingTimePercent { get; private set; } = 0;

        public double CurrentProfit { get; set; } = 0;
        public double CurrentLostProfit { get; set; } = 0;
        public double CurrentWage { get; set; } = 0;

        public double CurrentNumberOfFinishedRequests { get; set; } = 0;
        public double CurrentFinishedInspectionTasks { get; set; } = 0;
        public double CurrentFinishedEngineRepairTasks { get; set; } = 0;
        public double CurrentFinishedTireFittingTasks { get; set; } = 0;
        public double CurrentFinishedBodyRepairTasks { get; set; } = 0;

        public double CurrentQueue { get; set; } = 0;
        public double CurrentWaitingTime { get; set; } = 0;
        public double CurrentWorkingPercent { get; set; } = 0;

        ////avg
        public double Profit { get; private set; } = 0;
        public double WagePerWorker { get; private set; } = 0;
        public double LostProfit { get; private set; } = 0;
        public double LostWagePerWorker { get; private set; } = 0;

        public double NumberOfFinishedRequests { get; private set; } = 0;
        public double FinishedInspectionTasks { get; private set; } = 0;
        public double FinishedEngineRepairTasks { get; private set; } = 0;
        public double FinishedTireFittingTasks { get; private set; } = 0;
        public double FinishedBodyRepairTasks { get; private set; } = 0;

        public double AvgQueue { get; private set; } = 0;
        public double AvgWaitingTime { get; private set; } = 0;
        public double AvgWorkingPercent { get; private set; } = 0;
        public double AvgWagePerDay { get; private set; } = 0;

        public Stat(int WorkersAmount)
        {
            this.WorkersAmount = WorkersAmount;
        }

        public void SetCurrentWorkingPercent(Room ProcessingRoom)
        {
            switch (ProcessingRoom.Type)
            {
                case Request.TaskTypes.BodyRepair:
                    BodyRepairCurrentWorkingTimePercent = ProcessingRoom.CurrentWorkingTimePercent;
                    break;
                case Request.TaskTypes.EngineRepair:
                    EngineRepairCurrentWorkingTimePercent = ProcessingRoom.CurrentWorkingTimePercent;
                    break;
                case Request.TaskTypes.Inspection:
                    InspectionCurrentWorkingTimePercent = ProcessingRoom.CurrentWorkingTimePercent;
                    break;
                case Request.TaskTypes.TireFitting:
                    TireFittingCurrentWorkingTimePercent = ProcessingRoom.CurrentWorkingTimePercent;
                    break;
            }
        }

        public void SumStat()
        {
            Profit += CurrentProfit;
            WagePerWorker += CurrentWage / WorkersAmount;
            LostProfit += CurrentLostProfit;
            LostWagePerWorker = LostProfit / WorkersAmount * WagePercent / 100;

            NumberOfFinishedRequests = CurrentNumberOfFinishedRequests;
            FinishedInspectionTasks += CurrentFinishedInspectionTasks;
            FinishedEngineRepairTasks += CurrentFinishedEngineRepairTasks;
            FinishedTireFittingTasks += CurrentFinishedTireFittingTasks;
            FinishedBodyRepairTasks += CurrentFinishedBodyRepairTasks;

            if (DaysPassed < 1)
            {
                AvgQueue = CurrentQueue;
                AvgWagePerDay = CurrentProfit * WagePercent / 100;
                AvgWaitingTime = CurrentWaitingTime;
                AvgWorkingPercent = CurrentWorkingPercent;
            }
            else
            {
                AvgQueue = AvgQueue / (DaysPassed + 1) * DaysPassed + CurrentQueue / (DaysPassed + 1);
                AvgWagePerDay = AvgWagePerDay / (DaysPassed + 1) * DaysPassed + CurrentProfit * WagePercent / 100 / (DaysPassed + 1);
                AvgWaitingTime = AvgWaitingTime / (DaysPassed + 1) * DaysPassed + CurrentWaitingTime / (DaysPassed + 1);
                AvgWorkingPercent = AvgWorkingPercent / (DaysPassed + 1) * DaysPassed + CurrentWorkingPercent / (DaysPassed + 1);
            }

            CurrentFinishedBodyRepairTasks = 0;
            CurrentFinishedEngineRepairTasks = 0;
            CurrentFinishedInspectionTasks = 0;
            CurrentFinishedTireFittingTasks = 0;
            CurrentLostProfit = 0;
            CurrentNumberOfFinishedRequests = 0;
            CurrentProfit = 0;
            CurrentWage = 0;
            CurrentQueue = 0;
            CurrentWaitingTime = 0;
            CurrentWorkingPercent = 0;
        }
    }
}
