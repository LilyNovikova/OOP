using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class Gradient
    {
        public const double DeltaConst = 0.1;
        public static Matrix NumericalGradient(Function Function, Matrix CurrentPoint) //численное дифференцирование
        {
            Matrix g1 = new Matrix(CurrentPoint.Height, 1);
            Matrix PreviousPoint = new Matrix(CurrentPoint.Height, 1);
            for (int i = 0; i < CurrentPoint.Height; i++)
            {
                PreviousPoint[i, 0] = CurrentPoint[i, 0]; // координаты предыдущей точки равны координатам текущей (0;0) изначально
            }
            double h = 0.00001;
            for (int i = 0; i < CurrentPoint.Height; i++)
            {
                PreviousPoint[i, 0] = PreviousPoint[i, 0] - h;
                g1[i, 0] = Function.GetValue(CurrentPoint) - Function.GetValue(PreviousPoint) / h;
                PreviousPoint[i, 0] = PreviousPoint[i, 0] + h;
            }
            return g1;
        }
        public static Matrix gradient2(Function Function, Matrix CurrentPoint) //численное дифференцирование
        {
            Matrix g1 = new Matrix(CurrentPoint.Height, 1);
            Matrix PreviousPoint = new Matrix(CurrentPoint.Height, 1);
            for (int i = 0; i < CurrentPoint.Height; i++)
            {
                PreviousPoint[i, 0] = CurrentPoint[i, 0];//координаты предыдущей точки равны координатам текущей (0;0) изначально
            }
            double h = 0.00001;
            for (int i = 0; i < CurrentPoint.Height; i++)
            {
                PreviousPoint[i, 0] = PreviousPoint[i, 0] - h;
                CurrentPoint[i, 0] = CurrentPoint[i, 0] + h;
                g1[i, 0] = Function.GetValue(CurrentPoint) - Function.GetValue(PreviousPoint) / (2 * h);
                PreviousPoint[i, 0] = PreviousPoint[i, 0] + h;
                CurrentPoint[i, 0] = CurrentPoint[i, 0] - h;
            }
            return g1;
        }
        public static Matrix gradient3(Function Function, Matrix CurrentPoint) //численное дифференцирование
        {
            Matrix g1 = new Matrix(CurrentPoint.Height, 1);
            Matrix PreviousPoint = new Matrix(CurrentPoint.Height, 1);
            Matrix NextPoint = new Matrix(CurrentPoint.Height, 1);
            for (int i = 0; i < CurrentPoint.Height; i++)
            {
                PreviousPoint[i, 0] = CurrentPoint[i, 0];//координаты предыдущей точки равны координатам текущей (0;0) изначально
                NextPoint[i, 0] = CurrentPoint[i, 0];
            }
            double h = 0.00001;
            for (int i = 0; i < CurrentPoint.Height; i++)
            {
                PreviousPoint[i, 0] = PreviousPoint[i, 0] - h;
                NextPoint[i, 0] = NextPoint[i, 0] + h;
                g1[i, 0] = 3 * Function.GetValue(NextPoint) + Function.GetValue(PreviousPoint) - 4 * Function.GetValue(CurrentPoint) / (2 * h);
                PreviousPoint[i, 0] = PreviousPoint[i, 0] + h;
                NextPoint[i, 0] = NextPoint[i, 0] - h;
            }
            return g1;
        }
        public static Matrix gradient4(Function Function, Matrix CurrentPoint)//численное дифференцирование
        {
            Matrix g1 = new Matrix(CurrentPoint.Height, 1);
            Matrix PreviousPoint = new Matrix(CurrentPoint.Height, 1);
            Matrix NextPoint = new Matrix(CurrentPoint.Height, 1);
            Matrix NextNextPoint = new Matrix(CurrentPoint.Height, 1);
            Matrix PreviPrevPoint = new Matrix(CurrentPoint.Height, 1);
            for (int i = 0; i < CurrentPoint.Height; i++)
            {
                PreviousPoint[i, 0] = CurrentPoint[i, 0];//координаты предыдущей точки равны координатам текущей (0;0) изначально
                NextPoint[i, 0] = CurrentPoint[i, 0];
                NextNextPoint[i, 0] = CurrentPoint[i, 0];
                PreviPrevPoint[i, 0] = CurrentPoint[i, 0];
            }
            double h = 0.00001;
            for (int i = 0; i < CurrentPoint.Height; i++)
            {
                PreviPrevPoint[i, 0] = PreviPrevPoint[i, 0] - 2 * h;
                PreviousPoint[i, 0] = PreviousPoint[i, 0] - h;
                NextNextPoint[i, 0] = NextNextPoint[i, 0] + 2 * h;
                NextPoint[i, 0] = NextPoint[i, 0] + h;
                g1[i, 0] = (8 * Function.GetValue(NextPoint) - 8 * Function.GetValue(PreviousPoint) 
                    - Function.GetValue(NextNextPoint) + Function.GetValue(PreviPrevPoint)) / (12 * h);
                PreviPrevPoint[i, 0] = PreviPrevPoint[i, 0] + 2 * h;
                PreviousPoint[i, 0] = PreviousPoint[i, 0] + h;
                NextNextPoint[i, 0] = NextNextPoint[i, 0] - 2 * h;
                NextPoint[i, 0] = NextPoint[i, 0] - h;
            }
            return g1;
        }

        public static Matrix HesseMatrix(Function[] DF, double DFValue, Matrix CurrentPoint, double Tolerance)
        {
            int n = CurrentPoint.Height;
            Matrix Hessian = new Matrix();
            Hessian.Height = n;
            Hessian.Width = n;
            double DeltaX = DeltaConst * Tolerance;
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n;j++)
                {
                    CurrentPoint[j, 0] = DeltaX + CurrentPoint[j, 0];
                    double temp = (DF[j].GetValue(CurrentPoint) - DFValue) / DeltaX;
                    CurrentPoint[j, 0] = CurrentPoint[j, 0] - DeltaX;
                }
            }
            return Hessian;
        }
    }


}
