using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functions;

namespace NewtonMethod
{
    public class Newton
    {
        public const double Tolerance = 0.0001;

        public double FindMinimum(Function F, Matrix CenterPoint, Matrix Width, out int feval, out Matrix MinPoint)
        {
            feval = 0;
            Dictionary<double, Matrix> values = GetValues(F, CenterPoint, Width, out feval);
            double MinValue = values.Keys.Min(Key=>Key);
            if (values.TryGetValue(MinValue, out MinPoint))
            {
                return MinValue;
            }
            else throw new Exception("Smth wrong with dictionary");
        }

        private Dictionary<double, Matrix> GetValues(Function F, Matrix CenterPoint, Matrix Width, out int feval)
        {
            Dictionary<double, Matrix> values = new Dictionary<double, Matrix>();
            if (CenterPoint.Height != Width.Height)
            {
                throw new ArgumentException();
            }
            feval = 0;
            Matrix StartPoint = CenterPoint;
            for (int i = 0; i < CenterPoint.Height; i++)
            {
                StartPoint[i, 0] += Width[i, 0] / 2;
            }
            Matrix Point = StartPoint;
            double Step = Tolerance * 2;
            for (int i = 0; i < CenterPoint.Height; i++)
            {
                Point[1, 0] = StartPoint[1, 0];
                for (int j = 0; j < CenterPoint.Height; j++)
                {
                    values.Add(F.GetValue(Point), Point);
                    feval++;
                    Point[1, 0] += Step;
                }
                Point[0, 0] += Step;
            }
            return values;
        }
    }
}
