using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1.Tasks
{
    /* класс: задание "Кузовной ремонт"
     */
    public class BodyRepair : Task
    {
        public const int NumberOfTypes = 4;
        public enum TaskTypes
        {
            T1,
            T2,
            T3,
            T4
        }
        public BodyRepair(TaskTypes type) : base()
        {
            Type = Request.TaskTypes.BodyRepair;
            int TaskDuration = 0;
            switch (type)
            {
                case TaskTypes.T1:
                    this.Price = 12000;
                    TaskDuration = 300;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T2:
                    this.Price = 4000;
                    TaskDuration = 100;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T3:
                    this.Price = 6000;
                    TaskDuration = 150;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T4:
                    this.Price = 1000;
                    TaskDuration = 25;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
            }
        }

        public static new BodyRepair GetRandom()
        {
            return new BodyRepair((TaskTypes)Utils.GetRandomInt(0, NumberOfTypes));
        }
    }
}
