using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPlus
{
    public class NumberString
    {
        public string number { get; private set; }

        public NumberString(string num)
        {
            char[] NumChars = num.ToCharArray();
            for (int i = 0; i < num.Length; i++)
            {
                if (!char.IsDigit(NumChars[i]))
                {
                    throw new FormatException("This NumberString contains nondigit");
                }
            }
            number = num;
        }

        public static NumberString plus(NumberString NS1, NumberString NS2)
        {
            //char array with bigger length
            char[] NumChar1 = (NS1.number.Length > NS2.number.Length) ? NS1.number.ToCharArray() : NS2.number.ToCharArray();
            //char array with smaller length
            char[] NumChar2 = (NS1.number.Length > NS2.number.Length) ? NS2.number.ToCharArray() : NS1.number.ToCharArray();

            int[] ResInts = new int[NumChar1.Length];
            int j = NumChar2.Length - 1;
            for (int i = NumChar1.Length - 1; i >= 0; i--)
            {
                if (j >=0)
                {
                    ResInts[i] = (int)(NumChar1[i] + NumChar2[j] - 2 * '0');
                }
                else
                {
                    ResInts[i] = (int)(NumChar1[i] - '0');
                }
                j--;
            }
            return new NumberString(NumIntToNumString(ResInts));
        }


        private static string NumIntToNumString(int[] NumInts)
        {
            string result = "";
            for (int i = NumInts.Length - 1; i >= 0; i--)
            {

                if (NumInts[i] < 10)
                {
                    result = NumInts[i].ToString() + result;
                }
                else
                {
                    result = (NumInts[i] % 10).ToString() + result;
                    if (i > 0)
                    {
                        NumInts[i - 1]++;
                    }
                    else
                    {
                        result = '1' + result;
                    }
                }

            }

            return result;
        }
    }
}
