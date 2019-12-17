using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1
{
    public class Admin
    {
        public event EventHandler<Request> RequestRemoved;
        public event EventHandler<Request> RequestReceived;

        public static Stat Statistics { get; private set; }
        public static int ImitationStart { get; } = 600;//Schedule.GetTimeInMinutes((int)Schedule.StartDay, Schedule.StartHour, 0);
        public static int MaxDisperciaPercent { get; } = ConfigParser.MaxDisperciaPercent;
        public static int RequestReceivingFrequency { get; } = ConfigParser.RequestReceivingFrequency;
        public int ImitationStep { get; set; } = 60;
        public static int ImitationDuration { get; } = Schedule.GetTimeInMinutes(ConfigParser.ImitationDuration, 0, 0);
        public static int MaxWaitingTime { get; } = Schedule.GetTimeInMinutes(ConfigParser.MaxWaitingTime, 0 , 0);
        public static int MaxTasksInRequest { get; } = ConfigParser.MaxTasksInRequest;
        public const int NumberOfTaskTypes = 4;
        public const int MaxTaskDuration = 9000;
        public const int MaxTaskPrice = 100000;
        public static int Now { get; set; } = ImitationStart; //in minutes
        //public static int NumberOfRooms = 4;
        public List<Room> RoomsList = new List<Room>();
        public List<Request> RequestsList = new List<Request>();
        public int[] NumberOfWorkersPerRoom = { 6, 1, 1, 1 };
        public bool IsPaused = true;
        public int NextRequestReceivingTime; //время появление следующей заявки

        public Admin(int ImitStep, int InspectionRoomWorkersNum, int EngineRepairRoomWorkersNum,
            int TireFittingRoomWorkersNum, int BodyRepairRoomWorkersNum)
        {
            Reset();
            this.ImitationStep = ImitStep;
            NumberOfWorkersPerRoom[0] = InspectionRoomWorkersNum;
            NumberOfWorkersPerRoom[1] = EngineRepairRoomWorkersNum;
            NumberOfWorkersPerRoom[2] = TireFittingRoomWorkersNum;
            NumberOfWorkersPerRoom[3] = BodyRepairRoomWorkersNum;
            NextRequestReceivingTime = ImitationStart + RequestReceivingFrequency + Utils.GetRandomDiff(RequestReceivingFrequency, MaxDisperciaPercent);
            InitRooms(NumberOfWorkersPerRoom);
            int sum = 0;
            foreach (int Num in NumberOfWorkersPerRoom) { sum += Num; }
            Statistics = new Stat(sum);
        }

        public Admin()
        {
            Reset();
            NextRequestReceivingTime = ImitationStart + RequestReceivingFrequency + Utils.GetRandomDiff(RequestReceivingFrequency, MaxDisperciaPercent);
            InitRooms(NumberOfWorkersPerRoom);
        }

        //обнуление статических переменных
        private static void Reset()
        {
            Utils.Reset();
            Task.Reset();
            Request.Reset();
            Room.Reset();
            Worker.Reset();
            Now = ImitationStart;
        }

        //моделирования нового шага
        public void GoToNextImitStep()
        {
            do
            {
                //если закрыто, но пришло время открываться
                if (Schedule.IsOpened && IsPaused)
                {
                    Start();
                }
                //если открыто, но пора закрываться
                else if (!Schedule.IsOpened && !IsPaused)
                {
                    int PauseDuration = Schedule.GetTimeInMinutes(Schedule.GetDayNumber() + 1, Schedule.StartHour, 0) - Admin.Now;
                    NextRequestReceivingTime += PauseDuration;
                    Pause(PauseDuration);
                }
                //если рабочее время
                if (!IsPaused)
                {
                    if (Now == NextRequestReceivingTime)
                    {
                        Request Request = Request.GetRandomRequest();
                        RequestsList.Add(Request);
                        SortTasks(Request);
                        NextRequestReceivingTime = NextRequestReceivingTime + RequestReceivingFrequency + Utils.GetRandomDiff(RequestReceivingFrequency, MaxDisperciaPercent);
                        RequestReceived(this, Request);
                    }
                }

                RemoveOverdueRequests();
                Next();
                //если полночь - подсчёт статистики
                if (Now % (Schedule.MinutesPerHour * Schedule.HoursPerDay) == 0)
                {
                    SetCurrentStat();
                    Statistics.SumStat();
                }
                //move time
                Now++;
            }
            while (Now <= ImitationDuration && (Now - ImitationStart) % ImitationStep != 0);
        }

        //сортировка заданий по цехам
        private void SortTasks(Request Request)
        {
            foreach (var Task in Request.TasksToDoList)
            {
                try
                {
                    (from R in RoomsList where R.Type == Task.Type select R).ToList().First().AddTask(Task);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No room for tasktype '{0}'", Task.Type);
                }
            }
        }

        //моделирование новой минуты
        private void Next()
        {
            foreach (Room Room in RoomsList)
            {
                Room.Next();
            }
        }

        //инициализация цехов
        private void InitRooms(int[] NumOfWorkers)
        {
            for (int i = 0; i < NumOfWorkers.Length; i++)
            {
                RoomsList.Add(new Room((Request.TaskTypes)i, NumOfWorkers[i]));
            }
        }

        //удаление просроченных заявок
        private void RemoveOverdueRequests()
        {
            //выбор заявок
            List<Request> ToRemove = (from R in RequestsList where (R.WaitingTime > MaxWaitingTime && !R.IsReady) select R).ToList();
            //удаление
            foreach (Room Room in RoomsList)
            {
                foreach (Request Request in ToRemove)
                {
                    Room.RemoveRequest(Request);
                    RequestsList.Remove(Request);
                    RequestRemoved(this, Request);
                }
            }
        }

        //приостановка работы автосервиса
        private void Pause(int PauseDuration)
        {
            IsPaused = true;
            foreach (Room Room in RoomsList)
            {
                Room.Pause(PauseDuration);
            }
        }

        //запуск работы
        private void Start()
        {
            IsPaused = false;
            foreach (Room Room in RoomsList)
            {
                Room.Start();
            }
        }

        //обновление статистики
        private void SetCurrentStat()
        {
            //обновление статистики цехов
            double AvgQueue = 0;
            double AvgWorkingPercent = 0;
            foreach (Room R in RoomsList)
            {
                AvgQueue += R.AverageRequestQueueLength;
                AvgWorkingPercent += R.AverageWorkingTimePercent;
            }
            Statistics.CurrentQueue = AvgQueue / RoomsList.Count;
            Statistics.CurrentWorkingPercent = AvgWorkingPercent / RoomsList.Count;

            //обновление статистики заявок
            double AvgWait = 0;
            int NumFinished = 0;
            foreach(Request R in RequestsList)
            {
                AvgWait += R.WaitingTime;
                if(R.IsReady)
                {
                    NumFinished++;
                }
            }
            Statistics.CurrentWaitingTime = AvgWait / RequestsList.Count;
            Statistics.CurrentNumberOfFinishedRequests = NumFinished;
        }
    }
}
