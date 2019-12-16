using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functions;

namespace OptMethod
{
    public class Optimisation
    {
        public static double Tolerance { get; set; } = 0.1;

        /*public static void Main()
        {
            Function F = new Function("x1^2 + (x2-3)^2");
            List<double> CenterP = new List<double>();
            CenterP.Add(-0.5);
            CenterP.Add(2.5);
            List<double> WidthList = new List<double>();
            WidthList.Add(5);
            WidthList.Add(3);
            Matrix CenterPoint = new Matrix(CenterP);
            Matrix Width = new Matrix(WidthList);
            Matrix Min;
            int feval = 0;
            Console.WriteLine(Math.Round( Optimisation.FindMinimum(F, CenterPoint, Width, out feval, out Min), 2) + "\nmin: " +Min + "\nfeval:" + feval);
        }*/
        public static double FindMinimum(Function F, Matrix StartPoint, Matrix Width, out int feval, out Matrix MinPoint)
        {
            feval = 0;
            List<KeyValuePair<Matrix, double>> values = GetValues(F, StartPoint, Width, out feval);
            KeyValuePair<Matrix, double> MinPair = values.OrderBy(Pair => Math.Round(Pair.Value, 3)).First();
            MinPoint = MinPair.Key;
            List<double> MinList = new List<double>();
            for(int i = 0;i < F.NumberOfVariables;i++)
            {
                MinList.Add(Math.Round( MinPoint[i, 0], 3));
            }
            MinPoint = new Matrix(MinList);
            return MinPair.Value;
        }

        private static List<KeyValuePair<Matrix, double>> GetValues(Function F, Matrix CenterPoint, Matrix Width, out int feval)
        {
            List<KeyValuePair<Matrix, double>> values = new List<KeyValuePair<Matrix, double>>();
            if (CenterPoint.Height != Width.Height)
            {
                throw new ArgumentException();
            }
            feval = 0;
            Matrix StartPoint = CenterPoint.Copy();
            Matrix Point = StartPoint.Copy();
            double Step = Tolerance;
            for (double i = 0; i < Width[0, 0]; i += Step)
            {
                Point[1, 0] = StartPoint[1, 0];
                for (double j = 0; j < Width[1, 0]; j += Step)
                {
                    values.Add(new KeyValuePair<Matrix, double>(Point.Copy(), F.GetValue(Point)));
                    feval++;
                    Point[1, 0] += Step;
                }
                Point[0, 0] += Step;
            }
            return values;
        }
    }
}
