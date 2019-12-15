using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    class Test
    {
        public static void Main()
        {            
            try
            {
                Function F = new Function("2.3*x1^2+3*exp(x2) + x3");
                List<double> XValues = new List<double>();
                XValues.Add(1);
                XValues.Add(0);
                XValues.Add(2);
                Matrix X = new Matrix(XValues);
                Console.WriteLine(F.GetValue(X));
            }
            catch(IndexOutOfRangeException)
            {

            }
            catch(StackOverflowException)
            {

            }
        }
    }
}
