using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] names = { "1", "2", "3", "4", "5", "6", "7", "8" };
                int[][] data = Utils.ToIntArray(Utils.GetTextFromFile("input.txt"), " ,\n");
                Table table = new Table(names, data);
                Console.WriteLine(table);
                table.Optimize();
                Console.WriteLine("***");
                Console.WriteLine(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().ToString());
            }

        }
    }
}
