using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kurs_part1
{
    public static class Program
    {
        public static InputParser Input = new InputParser();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 form = new Form1();
                Application.Run(form);
            }
            catch (TypeInitializationException e)
            {
                Console.WriteLine(e.InnerException);
            }
            /*catch(InvalidOperationException e)
            {
                Console.WriteLine(e.InnerException);
            }*/

        }

    }
}
