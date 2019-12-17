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
        public static double Tolerance { get; set; } = 0.1;//точность вычисления

        //поиск минимума методо перебора
        public static double FindMinimum(Function F, Matrix StartPoint, Matrix Width, out int feval, out Matrix MinPoint)
        {
            feval = 0;
            //получение списка пар (точка, значение)
            List<KeyValuePair<Matrix, double>> values = GetValues(F, StartPoint, Width, out feval);

            KeyValuePair<Matrix, double> MinPair = values.OrderBy(Pair => Math.Round(Pair.Value, 3)).First();
            MinPoint = MinPair.Key;
            List<double> MinList = new List<double>();
            //отсеивание лишних координат 
            for(int i = 0;i < F.NumberOfVariables;i++)
            {
                MinList.Add(Math.Round( MinPoint[i, 0], 3));
            }
            MinPoint = new Matrix(MinList);
            return MinPair.Value;
        }

        //вычисление значений функции в точках области
        private static List<KeyValuePair<Matrix, double>> GetValues(Function F, Matrix StartPoint, Matrix Width, out int feval)
        {
            List<KeyValuePair<Matrix, double>> values = new List<KeyValuePair<Matrix, double>>();
            if (StartPoint.Height != Width.Height)
            {
                throw new ArgumentException();
            }
            feval = 0;
            Matrix Point = StartPoint.Copy();
            double Step = Tolerance;
            //вычисление значений в точках
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
