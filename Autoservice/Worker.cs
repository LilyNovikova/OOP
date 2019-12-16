using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Autoservice
{
    public class Worker
    {
        private static int ID = -1;
        public int TaskCheckFrequency { get; private set; } = 10;
        public bool IsBusy { get; set; }
        public int Id { get; private set; }

        public Thread WorkingThread;
        public Worker()
        {
            ID++;
            Id = ID;
            IsBusy = false;
        }
        public void Work(Task Task)
        {
            if (!IsBusy)
            {
                IsBusy = true;
                var time = DateTime.Now;
                Logger.Write(DateTime.Now, "Worker{0}: Is working for {1} ms. TaskID: {2}", Id, Task.Duration, Task.Id);
                SpendTime(Task.Duration / 2);
                Logger.Write(DateTime.Now, "Worker{0}: Half of task {1} is done", Id, Task.Id);
                SpendTime(Task.Duration / 2);
                Logger.Write(DateTime.Now, "Worker{0}: Task {1} is done", Id, Task.Id);
                IsBusy = false;
                Task.IsDone = true;
            }
            else
            {
                Logger.Write(DateTime.Now, "Worker{0}: Don't you see I'm busy?!", Id);
            }

        }

        public int Wait()
        {
            Logger.Write(DateTime.Now, "Worker{0}: Is waiting for a new task", Id);
            SpendTime(TaskCheckFrequency);
            return TaskCheckFrequency;
        }

        public override string ToString()
        {
            return string.Format("Worker{0} ({1})", Id, IsBusy ? "busy" : "waiting");
        }

        public void SpendTime(int time)
        {
            TimerCallback WorkCB = new TimerCallback(True);
            bool b = false;
            Timer WorkTimer = new Timer(WorkCB, b, time, 0);
            while(true)
            {
                if(b)
                {
                    break;
                }
            }
            WorkTimer.Change(System.Threading.Timeout.Infinite, 0);

        }

        public void True(object obj)
        {
            obj = true;
        }
    }
}
