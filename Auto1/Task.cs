using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1
{
    public class Task
    {
        protected static int ID = 0;
        public Request.TaskTypes Type;
        public int Id { get; protected set; }
        public int Price { get; protected set; }
        public int Duration { get; protected set; }
        public int InitTime { get; protected set; }
        public int StartTime { get; set; } = int.MaxValue;
        public int FinishTime { get; set; } = int.MaxValue;

        public bool IsStarted
        {
            get
            {
                return StartTime <= Admin.Now;
            }
        }
        public bool IsFinished
        {
            get
            {
                return FinishTime <= Admin.Now;
            }
        }

        public Worker Executor { get; protected set; } = null;
        public Request AttachedRequest { get; protected set; } = null;
        public Room ProcessingRoom { get; protected set; } = null;

        public Task()
        {
            Type = Request.TaskTypes.Default;
            InitTime = Admin.Now;
            Id = ID;
            ID++;
        }

        //старт выполнения задания
        public Task Start(Worker Executor)
        {
            this.Executor = Executor;
            this.ProcessingRoom = Executor.WorkingRoom;
            //если уже выполняется другое задание из связанной заявки, но в другом цехе
            //выбрасывает ошибку
            if (AttachedRequest.IsProcessing && !ProcessingRoom.Equals(AttachedRequest.ProcessingRoom))
            {
                this.Executor = null;
                this.ProcessingRoom = null;
                throw new InvalidOperationException("Request is proceessing on another task");
            }

            Executor.StartTask(this);
            StartTime = Admin.Now;
            FinishTime = StartTime + Duration;
            if (AttachedRequest != null)
            {
                AttachedRequest.Start(this);
            }
            return this;
        }

        //приостановка выполнения задания
        public void Pause(int PauseDuration)
        {
            if (PauseDuration < 0)
            {
                throw new ArgumentException("PauseDuration must be >= 0");
            }
            //если задание выполняется, приостанавливаем
            if (IsStarted && !IsFinished)
            {
                FinishTime += PauseDuration;
            }
            else
            {
                throw new InvalidOperationException("Can't pause not processing task");
            }
        }

        //завершение выполнения задания
        public Worker Finish()
        {
            //попытка раннего завершения
            if (Admin.Now < FinishTime)
            {
                throw new InvalidOperationException("Task is not finished");
            }
            Executor.FinishTask();
            if (AttachedRequest != null)
            {
                AttachedRequest.Finish(this);
            }
            return this.Executor;
        }

        public override string ToString()
        {
            return string.Format("{0} Rq{4} (IT: {1}, ST: {2}, FT: {3})",
                Id, InitTime, StartTime, FinishTime, AttachedRequest != null ? AttachedRequest.Id : -1);
        }

        //привязка задания к заявке
        public void ConnectWithRequest(Request Request)
        {
            if (Request == null)
            {
                throw new NullReferenceException();
            }
            this.AttachedRequest = Request;
        }

        //обнуление статических переменных
        public static void Reset()
        {
            ID = 0;
        }
    }
}
