using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class Function
    {
        private Tree FunctionTree;
        private FunctionParser Parser;
        public int NumberOfVariables //число переменных
        {
            get
            {
                return Parser.x.Count;
            }
        }
        public Function(string expr)
        {
            Parser = new FunctionParser(expr);
            FunctionTree = Parser.FunctionTree;
        }

        //вычисление значения функции в точке
        public double GetValue(Matrix x)
        {
            for (int i = 0; i < Parser.x.Count; i++)
            {
                Parser.x[i + 1] = x[i, 0];
            }
            return FunctionTree.Root.Value; // возвращает значение дерева пропарсенной функции, подставляя нужный икс
        }
    }
}
