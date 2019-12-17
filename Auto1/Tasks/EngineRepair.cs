using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1.Tasks
{
    /* класс: задание "Ремонт двигателя"
     */
    public class EngineRepair : Task
    {
        public const int NumberOfTypes = 4;
        public enum TaskTypes
        {
            T1,
            T2,
            T3,
            T4
        }
        public EngineRepair(TaskTypes type) : base()
        {
            Type = Request.TaskTypes.EngineRepair;
            int TaskDuration = 0;
            switch (type)
            {
                case TaskTypes.T1:
                    this.Price = 10000;
                    TaskDuration = 150;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T2:
                    this.Price = 20000;
                    TaskDuration = 300;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T3:
                    this.Price = 5000;
                    TaskDuration = 75;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T4:
                    this.Price = 1000;
                    TaskDuration = 15;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
            }
        }

        public static new EngineRepair GetRandom()
        {
            return new EngineRepair((TaskTypes)Utils.GetRandomInt(0, NumberOfTypes));
        }
    }
}
