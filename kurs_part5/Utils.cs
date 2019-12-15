using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    class Utils
    {
        public static string GetNChars(int number, char c)
        {
            string s = "";
            for(int i = 0; i < number; i++)
            {
                s += c;
            }
            return s;
        }
    }
}
