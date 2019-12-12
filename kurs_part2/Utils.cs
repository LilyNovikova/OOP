using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kurs_part2
{
    public class Utils
    {
        public static string[] GetTextFromFile(string Filename)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);
            string[] content = File.ReadAllLines(path + "\\" + Filename);
            return content;
        }

        public static int[][] ToIntArray(string[] text, string SplitString)
        {
            int[][] array = new int[text.Length][];
            for(int i = 0; i < array.Length; i++)
            {
                string[] ArrayItems = text[i].Split(SplitString.ToCharArray());
                array[i] = new int[ArrayItems.Length];
                for (int j = 0; j < ArrayItems.Length; j++)
                {
                    array[i][j] = int.Parse(ArrayItems[j]);
                }
            }
            return array;
        }
    }
}
