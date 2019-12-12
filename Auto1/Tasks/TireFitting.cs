using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1.Tasks
{
    public class TireFitting : Task
    {
        public const int NumberOfTypes = 4;
        public enum TaskTypes
        {
            T1,
            T2,
            T3,
            T4
        }

        public TireFitting(TaskTypes type) : base()
        {
            Type = Request.TaskTypes.TireFitting;
            int TaskDuration = 0;
            switch (type)
            {
                case TaskTypes.T1:
                    this.Price = 3000;
                    TaskDuration = 30;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T2:
                    this.Price = 10000;
                    TaskDuration = 360;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T3:
                    this.Price = 5000;
                    TaskDuration = 60;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
                case TaskTypes.T4:
                    this.Price = 1500;
                    TaskDuration = 30;
                    this.Duration = TaskDuration + Utils.GetRandomDiff(TaskDuration, Admin.MaxDisperciaPercent);
                    break;
            }
        }

        public static new TireFitting GetRandom()
        {
            return new TireFitting((TaskTypes)Utils.GetRandomInt(0, NumberOfTypes));
        }
    }
}
