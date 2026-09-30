using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPlus
{
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                string[] text = FileUtils.ReadFile("input.txt").Split(',');
                NumberString NS1 = new NumberString(text[0]);
                NumberString NS2 = new NumberString(text[1]);

                NumberString NS3 = NumberString.plus(NS1,NS2);
                FileUtils.Write("output.txt", NS3.number);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().ToString() + '\n' + e.Message);
            }

        }
    }
}
