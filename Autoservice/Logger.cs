using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice
{
    public class Logger
    {
        public static void Write(string FormatStr, params object[]  input)
        {
            var time = DateTime.Now;
            Console.WriteLine(string.Format("[{0}] ", (time - Admin.StartTime).TotalMilliseconds.ToString().Substring(0,5))
                + string.Format(FormatStr, input));
        }

        public static void Write(DateTime Time, string FormatStr, params object[] input)
        {
            var time = DateTime.Now;
            Console.WriteLine(string.Format("[{0}] ", (Time-Admin.StartTime).TotalMilliseconds.ToString().Substring(0, 5))
                + string.Format(FormatStr, input));
        }
    }
}
