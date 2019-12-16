using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Autoservice
{
    public class Admin
    {
        public static DateTime StartTime = DateTime.Now;
        public static Room Room = new Room();
        public static void Main1()
        {
            
            TimerCallback AddTaskCB = new TimerCallback(AddTask);
            Timer AddTaskTimer = new Timer(AddTaskCB, null, 0, 10);
            TimerCallback GetStatCB = new TimerCallback(GetStat);
            Timer StatTimer = new Timer(GetStatCB, Room, 0, 200);
            Room.Work();

        }

        public static void AddTask(object obj)
        {
            Room.AddTask(new Task());
        }

        public static void GetStat(object obj)
        {
            Room SelectedRoom = (Room)obj;
            Logger.Write(DateTime.Now, "Admin: *** queue:{0} time:{1} ***", SelectedRoom.QueueLength, Room.SimulationTime);
        }
    }
}
