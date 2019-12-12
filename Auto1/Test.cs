using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1
{
    class Test
    {
        static void Main()
        {
            ConfigParser Config = new ConfigParser();
            //Schedule sch = new Schedule();
            Admin admin = new Admin(120, 2, 2, 2, 2);
            admin.Work();
        }
    }
}
