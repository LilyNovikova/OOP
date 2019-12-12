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

        private void FinishTasks()
        {
            List<Task> TasksToFinish = (from T in CurrentTasks where T.IsFinished select T).ToList();
            foreach (Task Task in TasksToFinish)
            {
                WorkersQueue.Enqueue(Task.Finish());
                CurrentTasks.Remove(Task);
                FinishedTasks.Add(Task);
                TotalProfit += Task.Price;
                Admin.Statistics.CurrentProfit += Task.Price;
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
                            //Console.WriteLine("[{0}]R{1} IOE No available tasks", Admin.Now, Id);
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

        public void AddTask(Task Task)
        {
            TasksQueue.Add(Task);
        }

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

        public void GetStat()
        {
            Console.WriteLine("R'{0}' TQ: {1} (RQ: {2}) WQ: {3} Done: {4} Stopped: {5} Total: {6}",
                Type, TasksQueue.Count, GetRequestsQueue().Count, WorkersQueue.Count, FinishedTasks.Count, NumberOfStoppedTasks,
                TasksQueue.Count + CurrentTasks.Count + FinishedTasks.Count + NumberOfStoppedTasks);
            Console.WriteLine("R'{0}' AQ: {1} (RQ: {2}) AW: {3} LP: {4} TP: {5}",
                Type, Utils.StringToLength(AverageQueueLength.ToString(), 4), Utils.StringToLength(AverageRequestQueueLength.ToString(), 4),
                Utils.StringToLength(AverageWorkingTimePercent.ToString(), 4), Utils.StringToLength(LostProfit.ToString(), 8),
                Utils.StringToLength(TotalProfit.ToString(), 8));
            foreach (Worker Worker in Workers)
            {
                //Worker.GetStat();
                Worker.GetProfitStat();
            }
        }

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

        public List<Request> GetRequestsQueue()
        {
            return (from T in TasksQueue select T.AttachedRequest).ToList().Distinct().ToList();
        }

        public List<Request> GetProcessingRequests()
        {
            return (from T in CurrentTasks select T.AttachedRequest).ToList().Distinct().ToList();
        }

        public List<Task> GetTasksQueue()
        {
            return TasksQueue;
        }

        public static void Reset()
        {
            ID = 0;
        }

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

        public void Start()
        {
            foreach (Worker Worker in Workers)
            {
                Worker.Start();
            }
        }
    }
}
