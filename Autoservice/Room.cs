using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Autoservice
{
    public class Room
    {
        private Queue<Worker> Workers;
        private Queue<Task> TasksQueue;
        private delegate void WorkDelegate();
        private event WorkDelegate OnAddTask;
        public int SimulationTime = 0;
        TimerCallback WorkCB;
        Timer WorkTimer;
        private int TaskCount = 0;
        private int NumberOfWorkers = 2;

        public int QueueLength
        {
            get
            {
                return TasksQueue.Count;
            }
        }
        public Room()
        {
            Logger.Write(DateTime.Now, "Room: Creating new room");
            Workers = new Queue<Worker>();
            InitWorkers();
            OnAddTask += Work;
            TasksQueue = new Queue<Task>();
            WorkCB = new TimerCallback(Done);
        }

        public void Work()
        {
            while ((DateTime.Now - Admin.StartTime).TotalMilliseconds < 720)
            {
                if (Workers.Count > 0)
                {
                    if (TasksQueue.Count > 0)
                    {
                        try
                        {
                            Worker Executor = Workers.Dequeue();
                            Task CurrentTask = TasksQueue.Dequeue();
                            CurrentTask.Executor = Executor;
                            Logger.Write(DateTime.Now, "Room: Time to work! Worker{0} Task{0}", Executor.Id, CurrentTask.Id);

                            Executor.Work(CurrentTask);
                            WorkTimer = new Timer(WorkCB, CurrentTask, 0, CurrentTask.Duration);
                        }
                        catch (InvalidOperationException)
                        {
                            Logger.Write(DateTime.Now, "Room: WHY TASK QUEUE IS EMPTY?!");
                        }
                    }
                    else
                    {
                        Logger.Write(DateTime.Now, "Room: W QTasks: {0}; QWorkers: {1}", TasksQueue.Count, Workers.Count);
                        try
                        {
                            SimulationTime += Workers.Peek().Wait();
                        }
                        catch (InvalidOperationException)
                        {
                            Logger.Write(DateTime.Now, "Room: WHY WORKERS QUEUE IS EMPTY?!");
                        }

                    }
                }
                Thread.Sleep(5);
                SimulationTime += 5;
                Logger.Write(DateTime.Now, "time {0}", SimulationTime);
            }

        }



        public void AddTask(Task Task)
        {

            TasksQueue.Enqueue(Task);
            Logger.Write(DateTime.Now, "Room: Got new task! ID: {0}", Task.Id);
            Logger.Write(DateTime.Now, "Room: A QTasks: {0}; QWorkers: {1}", TasksQueue.Count, Workers.Count);
            if (Workers.Count > 0)
            {
                Logger.Write(DateTime.Now, "Room: A Let's go!");
                OnAddTask();
            }


        }

        public void Done(object obj)
        {
            Logger.Write(DateTime.Now, "Room: Task is done! {0}", TaskCount++);
            Task Task = (Task)obj;
            if (Task.IsDone)
            {
                SimulationTime += Task.Duration;
                Logger.Write(DateTime.Now, "Room: Task is done! ID: {0}", Task.Id);
                WorkTimer.Change(System.Threading.Timeout.Infinite, 0);
                Workers.Enqueue(Task.Executor);
                if (TasksQueue.Count > 0)
                {
                    OnAddTask();
                }
            }
            else
            {
                Logger.Write(DateTime.Now, "Room: TASK IS NOT READY! ID: {0}", Task.Id);
            }
        }

        public override string ToString()
        {
            return string.Format("Room ({0})", TasksQueue.Count);
        }

        private void InitWorkers()
        {
            for (int i = 0; i < NumberOfWorkers; i++)
            {
                Worker NewWorker = new Worker();
                Workers.Enqueue(NewWorker);

            }
        }
    }
}
