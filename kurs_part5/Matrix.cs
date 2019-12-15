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
        public string Print()
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
        public Matrix(List<Double> point)
        {
            this.height = point.Count;
            this.width = 1;
            M = new double[this.height, this.width];
            for (int i = 0; i < point.Count; i++)
                M[i, 0] = point[i];
        }
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
        public static Matrix operator +(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.Height, A.Width);
            for (int i = 0; i < A.Height; i++)
            {
                for (int j = 0; j < A.Width; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C;
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
        public static Matrix operator *(Matrix A, double alpha)
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
        public static Matrix operator /(Matrix A, Matrix B)
        {
            return A * Transponding(B) * (1 / Math.Abs(Determinant(B)));
        }
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
        public static Matrix Transponding(Matrix A)
        {
            Matrix T = new Matrix(A.Width, A.Height);
            for (int i = 0; i < A.Width; i++)
                for (int j = 0; j < A.Height; j++)
                    T[i, j] = A[j, i];
            return T;
        }
        public static Matrix Norming(Matrix A)
        {
            Matrix res = A.Copy();
            double norma = 0;
            for (int i = 0; i < res.Height; i++)
            {
                norma += Math.Pow(res[i, 0], 2);
            }
            norma = Math.Sqrt(norma);
            for (int i = 0; i < res.Height; i++)
            {
                res[i, 0] = res[i, 0] / norma;
            }
            return res;
        }
        public static double Norm(Matrix A)
        {
            Matrix res = A.Copy();
            double norma = 0;
            for (int i = 0; i < res.Height; i++)
            {
                norma += Math.Pow(res[i, 0], 2);
            }
            return Math.Sqrt(norma);
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
        public static double ToNumber(Matrix A)
        {
            if (A.Height == 1 && A.Width == 1)
                return A[0, 0];
            else
                return 0;
        }

    }
}
