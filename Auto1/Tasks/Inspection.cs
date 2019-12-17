using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1.Tasks
{
    /* класс: задание "Техосмотр
     */
    public class Inspection : Task
    {
        public const int NumberOfTypes = 4;
        public enum TaskTypes
        {
            T1,
            T2,
            T3,
            T4
        }
        public Inspection(TaskTypes type) : base()
        {
            Type = Request.TaskTypes.Inspection;
            int TaskDuration = 0;
            switch (type)
            {
                case TaskTypes.T1:
                    this.Price = 5000;
                    TaskDuration = 500;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T2:
                    this.Price = 10000;
                    TaskDuration = 1000;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T3:
                    this.Price = 7500;
                    TaskDuration = 750;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T4:
                    this.Price = 6000;
                    TaskDuration = 550;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
            }
        }

        public static new Inspection GetRandom()
        {
            return new Inspection((TaskTypes)Utils.GetRandomInt(0, NumberOfTypes));
        }
    }
}
