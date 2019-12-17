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

        //запись текущего процента занятости рабочих 
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

        //суммирование статистики за день
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
                AvgWagePerDay = CurrentProfit * WagePercent / 100 / WorkersAmount;
                AvgWaitingTime = CurrentWaitingTime;
                AvgWorkingPercent = CurrentWorkingPercent;
            }
            else
            {
                AvgQueue = AvgQueue / (DaysPassed + 1) * DaysPassed + CurrentQueue / (DaysPassed + 1);
                AvgWagePerDay = AvgWagePerDay / (DaysPassed + 1) * DaysPassed + (CurrentProfit * WagePercent / 100 / (DaysPassed + 1)) / WorkersAmount;
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

        public override string ToString()
        {
            string StatStr = "";
            StatStr += Utils.StringToLength("Profit: ", 27) + Utils.StringToLength(Profit.ToString(), 10)+ "\n";
            StatStr += Utils.StringToLength("WagePerWorker:", 27) + Utils.StringToLength(WagePerWorker.ToString(), 10)+ "\n";
            StatStr += Utils.StringToLength("LostProfit:", 27) + Utils.StringToLength(LostProfit.ToString(), 10)+ "\n";
            StatStr += Utils.StringToLength("LostWagePerWorker: ", 27) + Utils.StringToLength(LostWagePerWorker.ToString(), 10)+ "\n\n";

            StatStr += Utils.StringToLength("NumberOfFinishedRequests:", 27) + Utils.StringToLength(NumberOfFinishedRequests.ToString(), 10)+ "\n";
            StatStr += Utils.StringToLength("FinishedInspectionTasks:", 27) + Utils.StringToLength(FinishedInspectionTasks.ToString(), 10)+ "\n";
            StatStr += Utils.StringToLength("FinishedEngineRepairTasks:", 27) + Utils.StringToLength(FinishedEngineRepairTasks.ToString(), 10)+ "\n";
            StatStr += Utils.StringToLength("FinishedTireFittingTasks:", 27) + Utils.StringToLength(FinishedTireFittingTasks.ToString(), 10)+ "\n";
            StatStr += Utils.StringToLength("FinishedBodyRepairTasks:", 27) + Utils.StringToLength(FinishedBodyRepairTasks.ToString(), 10)+ "\n\n";

            StatStr += Utils.StringToLength("AvgQueue:", 27) + Utils.StringToLength(AvgQueue.ToString(), 10)+ "\n";
            StatStr += Utils.StringToLength("AvgWaitingTime: ", 27) + Utils.StringToLength(AvgWaitingTime.ToString(), 10)+ "\n";
            StatStr += Utils.StringToLength("AvgWorkingPercent:", 27) + Utils.StringToLength(AvgWorkingPercent.ToString(), 10)+ "\n";
            StatStr += Utils.StringToLength("AvgWagePerDay:", 27) + Utils.StringToLength(AvgWagePerDay.ToString(), 10);
            return StatStr;
        }
    }
}
