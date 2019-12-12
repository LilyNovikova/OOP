using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto1
{
    public class Utils
    {
        private static Random Random = new Random();

        public static void Reset()
        {
            Random = new Random();
        }

        public static int GetRandomInt(int min, int max)
        {
            if (max == min)
            {
                return max;
            }
            return Random.Next() % (max - min) + min;
        }

        public static int GetRandomDiff(int value, int MaxPercent)
        {
            return value * (Random.Next() % (2 * MaxPercent) - MaxPercent) / 100;
        }

        public static string StringToLength(string String, int Length)
        {
            if (String.Length == Length)
            {
                return String;
            }
            else
            if (String.Length > Length)
            {
                return String.Substring(0, Length);
            }
            else
            {
                int NumberOfMissingSymbols = Length - String.Length;
                for (int i = 0; i < NumberOfMissingSymbols; i++)
                {
                    String += ' ';
                }
                return String;
            }
        }

        public static string ToTimeFormat(int Hours, int Minutes)
        {
            string str = "";
            if(Hours > 9)
            {
                str += Hours;
            }
            else if(Hours > 0)
            {
                str += "0" + Hours;
            }
            else
            {
                str += "00";
            }
            str += ":";
            if (Minutes > 9)
            {
                str += Minutes;
            }
            else if (Minutes > 0)
            {
                str += "0" + Minutes;
            }
            else
            {
                str += "00";
            }
            return str;
        }

        public static string ToString<T>(IEnumerable<T> Enum)
        {
            string str = "";
            foreach (T Item in Enum)
            {
                str += Item.ToString() + Environment.NewLine;
            }
            return str;
        }

    }
}
