using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1
{
    public class Worker
    {
        private static int ID = 0;
        public static int WagePercent { get; } = ConfigParser.WagePercent;
        public static int MinimumDailyWage { get; } = ConfigParser.MinimumWage;

        public int Id { get; private set; }
        public double EarnedMoney { get; private set; } = 0;
        public double EarnedToday { get; private set; } = 0;
        public int WorkingTime { get; private set; } = 0;
        public int PauseTime { get; private set; } = 0;
        public bool IsBusy { get; private set; } = false; //работает ли в данный момент
        public bool IsPaused { get; private set; } = false;
        private int PausedUntilTime = 0;
        public Task CurrentTask { get; private set; } = null;
        public Room WorkingRoom { get; private set; } = null;

        public Worker(Room Room)
        {
            this.Id = ID;
            this.WorkingRoom = Room;
            ID++;
        }

        //начать выполнение задания
        public void StartTask(Task Task)
        {
            if (!this.IsBusy)
            {
                this.IsBusy = true;
                this.CurrentTask = Task;
                Task.StartTime = Admin.Now;
            }
            else //если рабочий уже занят другим заданием
            {
                throw new InvalidOperationException(string.Format("[{0}]R{1} Worker{2}: BUSY", Admin.Now, WorkingRoom.Id, Id));
            }
        }

        //завершить выполнение задания
        public Task FinishTask()
        {
            try
            {
                Task FinishedTask = CurrentTask;
                FinishedTask.FinishTime = Admin.Now;
                this.CurrentTask = null;
                this.IsBusy = false;

                this.EarnedToday += (double)FinishedTask.Price * WagePercent / 100;
                this.WorkingTime += FinishedTask.Duration;
                return FinishedTask;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("[{0}]R{1} Worker{2}: CurrentTask is NULL", Admin.Now, WorkingRoom.Id, Id);
                return null;
            }
        }

        //прерывание просроченного задания
        public void StopCurrentTask()
        {
            try
            {
                this.IsBusy = false;
                this.WorkingTime += Admin.Now - CurrentTask.StartTime;
                this.CurrentTask = null;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("[{0}]R{1} Worker{2}: CurrentTask is NULL", Admin.Now, WorkingRoom.Id, Id);
            }
        }

        public override string ToString()
        {
            if (CurrentTask != null)
            {
                return string.Format("{0} (IB: {1}, CT: {2}, EM: {3}, WR: {4})", Id, IsBusy, CurrentTask.Id, EarnedMoney, WorkingRoom.Id);
            }
            else
            {
                return string.Format("{0} (IB: {1}, EM: {2}, WR: {3})", Id, IsBusy, EarnedMoney, WorkingRoom.Id);
            }
        }

        //обнуление статических переменных
        public static void Reset()
        {
            ID = 0;
        }

        //приостановка работы
        public void Pause(int PauseDuration)
        {
            if (PauseDuration < 0)
            {
                throw new ArgumentException("PauseDuration must be >= 0");
            }
            //если рабочий выполняет задание, приостанавливаем его
            if (CurrentTask != null)
            {
                try
                {
                    CurrentTask.Pause(PauseDuration);
                }
                catch (Exception e)
                {
                    if (!e.GetType().Equals(typeof(InvalidOperationException)) || !e.GetType().Equals(typeof(ArgumentException)))
                    {
                        Console.WriteLine(e.GetType().ToString() + " " + e.Message);
                    }
                }
            }
            PauseTime += PauseDuration;
            PausedUntilTime = Admin.Now + PauseDuration;
            IsPaused = true;
        }

        //запуск работы
        public void Start()
        {
            //если пауза закончилась, запускаем
            if (Admin.Now >= PausedUntilTime)
            {
                IsPaused = false;
            }
        }

        //sets today's wage returns and sets it 0
        public double GetDailyWage()
        {
            double Money = EarnedToday;
            //если рабочий заработал больше минимума
            if (EarnedToday > MinimumDailyWage)
            {
                EarnedMoney += EarnedToday;
            }
            else//иначе выплачиваем минимум
            {
                EarnedMoney += MinimumDailyWage;
            }
            EarnedToday = 0;
            return Money;
        }
    }
}
