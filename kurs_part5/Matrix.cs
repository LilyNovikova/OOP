using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class Matrix
    {
        private int width;
        private int height;
        private double[,] M;
        public Matrix() { }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < this.height; i++)
            {
                for (int j = 0; j < this.width; j++)
                {
                    str = str + this[i, j] + "; ";
                }
                str = str + Environment.NewLine;
            }
            return str;
        }
        public int Width // число столбцов
        {
            get { return width; }
            set { if (value > 0) width = value; }
        }
        public int Height // число строк
        {
            get { return height; }
            set { if (value > 0) height = value; }
        }
        public Matrix(int height, int width)
        {
            this.height = height;
            this.width = width;
            M = new double[this.height, this.width];
        }
        //создание вектора(матрицы из 1 столбца)
        public Matrix(List<Double> point)
        {
            this.height = point.Count;
            this.width = 1;
            M = new double[this.height, this.width];
            for (int i = 0; i < point.Count; i++)
                M[i, 0] = point[i];
        }
        //получение элемента матрицы (строка i, столбец j)
        public double this[int i, int j]
        {
            get
            {
                return M[i, j];
            }
            set
            {
                M[i, j] = value;
            }
        }
        //копирование матрицы
        public Matrix Copy()
        {
            Matrix NewMatrix = new Matrix(this.height, this.width);
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                    NewMatrix[j, i] = this[j, i];
            }
            return NewMatrix;
        }

        //returns transposed matrix
        public Matrix Transpose()
        {
            Matrix T = new Matrix(Width, Height);
            for (int i = 0; i < T.Height; i++)
            {
                for (int j = 0; j < T.Width; j++)
                {
                    T[i, j] = this[j, i];
                }
            }
            return T;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.Height, A.Width);
            for (int i = 0; i < A.Height; i++)
            {
                for (int j = 0; j < A.Width; j++)
                {
                    C[i, j] = A[i, j] - B[i, j];
                }
            }
            return C;
        }

        public void SetRow(Matrix Row, int RowNumber)
        {
            if (RowNumber < this.Height && RowNumber >= 0)
            {
                for (int j = 0; j < Row.Width && j < this.Width; j++)
                {
                    this[RowNumber, j] = Row[0, j];
                }
            }
        }

        public static Matrix Gradient(Function F, Matrix Point, double Tolerance)
        {
            List<double> GradientList = new List<double>();
            Matrix Point1 = Point.Copy();
            for (int i = 0; i < F.NumberOfVariables; i++)
            {
                Point1[i, 0] = Point[i, 0] - Tolerance;
                GradientList.Add((F.GetValue(Point) - F.GetValue(Point1)) / Tolerance);
                Point1[i, 0] = Point[i, 0];
            }
            return new Matrix(GradientList);
        }

        public static Matrix Gessian(Function F, Matrix Point, double Tolerance)
        {
            List<double> GradientList = new List<double>();
            Matrix Point1 = Point.Copy();
            Matrix G = new Matrix(F.NumberOfVariables, F.NumberOfVariables);
            for (int i = 0; i < F.NumberOfVariables; i++)
            {
                Point1[i, 0] = Point[i, 0] - Tolerance;
                var g1 = (1 / Tolerance) * Matrix.Gradient(F, Point, Tolerance);
                var g2 = (1 / Tolerance) * Matrix.Gradient(F, Point1, Tolerance);
                G.SetRow(g1.Transpose() - g2.Transpose(), i);
                Point1[i, 0] = Point[i, 0];
            }
            return G;
        }

        public static Matrix Inverse(Matrix A)
        {
            if (A.Height != A.Width)
            {
                return null;
            }
            if (A.Width == 1)
            {
                A[0, 0] = 1 / A[0, 0];
                return A;
            }
            else
            {
                return ((1 / Determinant(A)) * A.Transpose());
            }
        }

        public static Matrix Div(Matrix A, Matrix B)
        {
            return Inverse(B)*A;
        }

        static public double Determinant(Matrix M) // определитель матрицы М
        {
            if (M.Height == 1)
            {
                return M[0, 0];
            }
            else
            if (M.Height == 2) // если n = 2, то функция возвращает определитель 2-го порядка, путем вычитания побочной диагонали из главной
            {
                return (M[0, 0] * M[1, 1] - M[1, 0] * M[0, 1]);
            }
            else
            {
                double res = 0;
                bool bo = false;
                Matrix A = new Matrix(M.Height, M.Height); // объявляем матрицу n-го порядка
                A = M.Copy();
                Matrix B = new Matrix(M.Height - 1, M.Height - 1); // объявляем матрицу (n-1)-го порядка
                for (int d = 0; d < M.Height; d++) // задаем цикл: эти элементы будем вычерки-вать
                {
                    for (int j = 0; j < M.Height; j++) // задаем цикл: это строки матрицы
                    {
                        for (int k = 0; k < M.Width; k++) // задаем цикл: это столбцы матрицы
                        {
                            if (k != d) // проверяем: не этот столбец мы вычеркнули
                            {
                                if (j != 0) // проверяем: не эту строку мы вычеркнули
                                {
                                    if (!bo)
                                        B[j - 1, k] = A[j, k];
                                    else
                                        B[j - 1, k - 1] = A[j, k]; // проверяем: до или после столбца, который мы вычеркнули
                                }
                            }
                            else bo = true;
                        }
                        bo = false;
                    }
                    if (((d + 2) % 2) == 0)
                        res += A[0, d] * Determinant(B);
                    else
                        res -= A[0, d] * Determinant(B);
                }
                return res;
            }
        }
        public static Matrix operator *(double alpha, Matrix A)
        {
            Matrix C = new Matrix(A.Height, A.Width);
            for (int i = 0; i < A.Height; i++)
            {
                for (int j = 0; j < A.Width; j++)
                {
                    C[i, j] = A[i, j] * alpha;
                }
            }
            return C;
        }
        public static Matrix operator *(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.Height, B.Width);
            for (int i = 0; i < C.Width; i++)
            {
                for (int j = 0; j < C.Height; j++)
                {
                    for (int k = 0; k < A.Width; k++)
                    {
                        C[j, i] += A[j, k] * B[k, i];
                    }
                }
            }
            return C;
        }

        public static double NormVector(Matrix A)
        {
            Matrix res = A.Copy();
            double norma = 0;
            for (int i = 0; i < res.Height; i++)
            {
                norma += Math.Pow(res[i, 0], 2);
            }
            return Math.Sqrt(norma);
        }
    }
}
