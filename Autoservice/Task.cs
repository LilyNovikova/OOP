using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice
{
    public class Task
    {
        private static int ID = -1;
        public int Duration { get; private set; }
        public Worker Executor;
        public int Id { get; private set; }
        public bool IsDone { get; set; }

        public Task()
        {
            //Logger.Write(DateTime.Now, "Task: Created new task! ID is {0}", ID+1);
            ID++;
            Duration = 40;
            Id = ID;
            IsDone = false;
        }

        public override string ToString()
        {
            return "Task (" + Id + ')';
        }
    }
}
