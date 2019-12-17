using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1
{
    public class Room
    {

        private static int ID = 0;
        public Request.TaskTypes Type;
        public int Id { get; private set; }
        private int NumberOfWorkers;
        private List<Worker> Workers;
        private Queue<Worker> WorkersQueue;
        private List<Task> TasksQueue;
        private List<Task> FinishedTasks;
        private List<Task> CurrentTasks;

        public int TotalProfit { get; private set; } = 0;
        public int LostProfit { get; private set; } = 0;
        public double CurrentWorkingTimePercent { get; private set; } = 0;
        public double AverageQueueLength { get; private set; } = 0;
        public double AverageRequestQueueLength { get; private set; } = 0;
        public double AverageWorkingTimePercent { get; private set; } = 0;
        public int NumberOfStoppedTasks { get; private set; } = 0;


        public Room(Request.TaskTypes Type, int NumberOfWorkers)
        {
            Id = ID;
            this.Type = Type;
            this.NumberOfWorkers = NumberOfWorkers;
            Workers = new List<Worker>();
            WorkersQueue = new Queue<Worker>();
            InitWorkers();
            TasksQueue = new List<Task>();
            FinishedTasks = new List<Task>();
            CurrentTasks = new List<Task>();
            ID++;
        }

        //завершение заданий
        private void FinishTasks()
        {
            //выбор завершённых заданий
            List<Task> TasksToFinish = (from T in CurrentTasks where T.IsFinished select T).ToList();
            foreach (Task Task in TasksToFinish)
            {
                //возвращение рабочего в очередь на получение задания
                WorkersQueue.Enqueue(Task.Finish());
                //удаление из списка текущих заданий
                CurrentTasks.Remove(Task);
                //добавление в список завершённых
                FinishedTasks.Add(Task);
                TotalProfit += Task.Price;
                Admin.Statistics.CurrentProfit += Task.Price;

                //подсчёт завершённых заданий разных типов
                switch (Task.Type)
                {
                    case Request.TaskTypes.BodyRepair:
                        Admin.Statistics.CurrentFinishedBodyRepairTasks++;
                        break;
                    case Request.TaskTypes.EngineRepair:
                        Admin.Statistics.CurrentFinishedEngineRepairTasks++;
                        break;
                    case Request.TaskTypes.Inspection:
                        Admin.Statistics.CurrentFinishedInspectionTasks++;
                        break;
                    case Request.TaskTypes.TireFitting:
                        Admin.Statistics.CurrentFinishedTireFittingTasks++;
                        break;
                }
            }
        }

        //старт новых заданий
        private void StartTasks()
        {
            if (TasksQueue.Count > 0)
            {
                if (WorkersQueue.Count > 0)
                {
                    while (TasksQueue.Count > 0 && WorkersQueue.Count > 0)
                    {
                        Task Task = null;
                        //find available task (tasks request is not processing)
                        try
                        {
                            Task = (from T in TasksQueue where (!T.AttachedRequest.IsProcessing || T.AttachedRequest.ProcessingRoom.Equals(this)) select T).ToList().First();
                        }
                        catch (InvalidOperationException)
                        {
                        }
                        //start task if it is found
                        if (Task != null)
                        {
                            try
                            {
                                Task.Start(WorkersQueue.Dequeue());
                                CurrentTasks.Add(Task);
                            }
                            catch (InvalidOperationException)
                            {
                                Console.WriteLine("InvalidOperationException(Room, str 75)");
                            }
                            TasksQueue.Remove(Task);
                        }
                        else
                        {
                            //no available tasks => stop seeking
                            break;
                        }
                    }
                }
            }
        }

        //моделирование новой минуты
        public void Next()
        {
            //check current tasks if some are finished
            FinishTasks();
            //check tasks' and workers' queues if some tasks can be done by availale workers
            StartTasks();

            //count current
            CurrentWorkingTimePercent = 100 - 100 * WorkersQueue.Count / NumberOfWorkers;
            Admin.Statistics.SetCurrentWorkingPercent(this);

            //count average
            AverageQueueLength = AverageQueueLength * Admin.Now / (Admin.Now + 1) + (double)TasksQueue.Count / (Admin.Now + 1);

            AverageRequestQueueLength = AverageRequestQueueLength * Admin.Now / (Admin.Now + 1) + (double)GetRequestsQueue().Count / (Admin.Now + 1);
            AverageWorkingTimePercent = 0;
            if (Admin.Now != 0)
            {
                foreach (Worker Worker in Workers)
                {
                    AverageWorkingTimePercent += (double)Worker.WorkingTime / Admin.Now * 100 / NumberOfWorkers;
                }
            }

            //if workers' today wage is <1000, add money to 1000 
            if (Admin.Now > 0 && Admin.Now % (Schedule.HoursPerDay * Schedule.MinutesPerHour) == 0)
            {
                foreach (Worker W in Workers)
                {
                    Admin.Statistics.CurrentWage += W.GetDailyWage();
                }
            }
        }

        //добавление задания в очередь на выполнение
        public void AddTask(Task Task)
        {
            TasksQueue.Add(Task);
        }

        //инициализация рабочих
        private void InitWorkers()
        {
            for (int i = 0; i < NumberOfWorkers; i++)
            {
                Worker NewWorker = new Worker(this);
                Workers.Add(NewWorker);
                WorkersQueue.Enqueue(NewWorker);
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}] R{1} TQ: {2} WQ: {3}", Admin.Now, Id, TasksQueue.Count, WorkersQueue.Count);
        }

        public bool Equals(Room Room)
        {
            if (Room == null)
            {
                return this == null;
            }
            return this.Id == Room.Id;
        }

        //удаление просроченных заданий
        public void RemoveRequest(Request Request)
        {
            //from queue
            List<Task> TasksToRemoveFromQueue = (from T in TasksQueue where T.AttachedRequest.Equals(Request) select T).ToList();
            foreach (Task Task in TasksToRemoveFromQueue)
            {
                TasksQueue.Remove(Task);
                LostProfit += Task.Price;
                NumberOfStoppedTasks++;
                Admin.Statistics.CurrentLostProfit += Task.Price;
                // Console.WriteLine("[{0}] Rq{1} is overdue (R{2} QT{3})", Admin.Now, Task.AttachedRequest.Id, Id, Task.Id);
            }

            //from current
            List<Task> TasksToRemoveFromCurrent = (from T in CurrentTasks where T.AttachedRequest.Equals(Request) select T).ToList();
            foreach (Task Task in TasksToRemoveFromCurrent)
            {
                CurrentTasks.Remove(Task);
                try
                {
                    Task.Executor.StopCurrentTask();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Suddenly no executor Room str=176");
                }
                WorkersQueue.Enqueue(Task.Executor);
                LostProfit += Task.Price;
                Admin.Statistics.CurrentLostProfit += Task.Price;
                NumberOfStoppedTasks++;
                // Console.WriteLine("[{0}] Rq{1} is overdue (R{2} CT{3})", Admin.Now, Task.AttachedRequest.Id, Id, Task.Id);
            }
        }
        
        //возвращает очередь заявок
        public List<Request> GetRequestsQueue()
        {
            return (from T in TasksQueue select T.AttachedRequest).ToList().Distinct().ToList();
        }

        //возвращает очередь выполняющихся заявок
        public List<Request> GetProcessingRequests()
        {
            return (from T in CurrentTasks select T.AttachedRequest).ToList().Distinct().ToList();
        }
       
        //возвращает очередь заданий
        public List<Task> GetTasksQueue()
        {
            return TasksQueue;
        }

        //обнуление статических переменных
        public static void Reset()
        {
            ID = 0;
        }

        //приостанавливает работу цеха
        public void Pause(int PauseDuration)
        {
            foreach (Worker Worker in Workers)
            {
                try
                {
                    Worker.Pause(PauseDuration);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetType().ToString() + " " + e.Message);
                }

            }
        }

        //запускает работу цеха
        public void Start()
        {
            foreach (Worker Worker in Workers)
            {
                Worker.Start();
            }
        }
    }
}
