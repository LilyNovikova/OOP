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
    }
}
