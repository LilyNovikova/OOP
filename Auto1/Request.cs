using Auto1.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1
{
    public class Request
    {

        private static int ID = 0;
        public int Id { get; private set; }
        public int InitTime { get; private set; }
        public int StartTime { get; private set; } = -1;
        public int FinishTime { get; private set; } = -1;
        public int WaitingTime
        {
            get
            {
                return (FinishTime == -1 ? Admin.Now : FinishTime) - InitTime;
            }
        }
        public int FutureAddPrice { get; private set; } = 0; //цена невыполненных заданий
        public int Price { get; private set; } = 0; //цена выполненны заданий
        public List<Task> TasksToDoList;
        public List<Task> FinishedTasksList;
        public bool IsProcessing { get; private set; } = false;
        public Room ProcessingRoom { get; private set; } = null;
        public bool IsReady
        {
            get
            {
                return TasksToDoList.Count == 0;
            }
        }

        public enum TaskTypes
        {
            Inspection,
            EngineRepair,
            TireFitting,
            BodyRepair,
            Default
        }

        public Request()
        {
            Id = ID;
            InitTime = Admin.Now;
            TasksToDoList = new List<Task>();
            FinishedTasksList = new List<Task>();
            ID++;
        }

        //генерация случайной заявки
        public static Request GetRandomRequest()
        {
            Request Request = new Request();
            int NumberTasks = Utils.GetRandomInt(1, Admin.MaxTasksInRequest + 1);
            for (int i = 0; i < NumberTasks; i++)
            {
                int TaskType = Utils.GetRandomInt(0, Admin.NumberOfTaskTypes);
                switch ((TaskTypes)TaskType)
                {
                    case TaskTypes.EngineRepair:
                        Request.AddTask(EngineRepair.GetRandom());
                        break;
                    case TaskTypes.BodyRepair:
                        Request.AddTask(BodyRepair.GetRandom());
                        break;
                    case TaskTypes.TireFitting:
                        Request.AddTask(TireFitting.GetRandom());
                        break;
                    case TaskTypes.Inspection:
                        Request.AddTask(Inspection.GetRandom());
                        break;
                }
            }
            return Request;
        }

        public bool Equals(Request Request)
        {
            return Id == Request.Id;
        }

        //доабвление задания в заявку
        public void AddTask(Task Task)
        {
            Task.ConnectWithRequest(this);
            TasksToDoList.Add(Task);
            InitTime = Admin.Now;
            FutureAddPrice += Task.Price;
        }

        //старт выполнения задания
        public void Start(Task Task)
        {
            //если начато первое задание, старт выполнения заявки
            if (StartTime == -1)
            {
                StartTime = Admin.Now;
            }
            ProcessingRoom = Task.ProcessingRoom;
            IsProcessing = true;
        }

        //завершение выполнения задания
        public void Finish(Task Task)
        {
            TasksToDoList.Remove(Task);
            FinishedTasksList.Add(Task);
            //если заявка не была завершена и завершаемое задание - последнее невыполненное, завершаем заявку
            if (FinishTime == -1 && TasksToDoList.Count == 0)
            {
                FinishTime = Admin.Now;
            }
            ProcessingRoom = null;
            IsProcessing = false;
            FutureAddPrice -= Task.Price;
            Price += Task.Price;
        }

        public override string ToString()
        {
            return string.Format("R#{0} [{1}/{2}] t = {3}",
                Id, FinishedTasksList.Count, TasksToDoList.Count + FinishedTasksList.Count, WaitingTime);
        }

        //обнуление статических переменных
        public static void Reset()
        {
            ID = 0;
        }
    }
}
