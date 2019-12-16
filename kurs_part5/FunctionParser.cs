using System;
using System.Collections.Generic;
namespace Functions
{
    public class FunctionParser
    {
        public const double PI = 3.14159265358979323846;
        public const double E = 2.71828182845904523536;
        public Dictionary<int, double> x = new Dictionary<int, double>();
        public Tree FunctionTree = new Tree();
        private int index = 0;
        public string Expression { get; private set; }
        // операции, определяемые парсером
        private double Add(Node a, Node b)
        {
            return a.Value + b.Value;
        }
        private double Sub(Node a, Node b)
        {
            return a.Value - b.Value;
        }
        private double Mul(Node a, Node b)
        {
            return a.Value * b.Value;
        }
        private double Div(Node a, Node b)
        {
            return a.Value / b.Value;
        }
        private double Cos(Node a, Node b)
        {
            return Math.Cos(a.Value * Math.PI / 180);
        }
        private double Sin(Node a, Node b)
        {
            return Math.Sin(a.Value * Math.PI / 180);
        }
        private double Sqrt(Node a, Node b)
        {
            return Math.Sqrt(a.Value);
        }
        private double Exp(Node a, Node b)
        {
            return Math.Exp(a.Value);
        }
        private double Log(Node a, Node b)
        {
            return Math.Log(a.Value);
        }
        private double Pow(Node a, Node b)
        {
            return Math.Pow(a.Value, b.Value);
        }
        private double X(Node a, Node b)
        {
            return x[Convert.ToInt32(a.Value)];
        }

        public FunctionParser(string expr)
        {
            Expression = expr;
            ReadExpr();
        }
        private void ReadExpr()
        {
            while (index < Expression.Length) // читает всю строку
            {
                NextRead(Expression);
            }
        }

        private void BeginMinus()
        {
            Node N = new Node(Sub);
            FunctionTree.Root = N;
            N.Left = new Node(0);
            N.Left.Parent = N;
            FunctionTree.Current = N;
            FunctionTree.Current.IsEnd = false;
            index++;
        }

        private void BracketsExpr()
        {
            if (FunctionTree.Root != null) // если дерево не пустое
            {
                Node TrueRoot = FunctionTree.Root;
                Node TrueCurrent = FunctionTree.Current;
                FunctionTree.Root = null;
                FunctionTree.Current = null;
                index++;
                while (Expression[index] != ')')
                {
                    NextRead(Expression);
                }
                index++;
                TrueCurrent.Right = FunctionTree.Root;
                FunctionTree.Root.Parent = TrueCurrent;
                FunctionTree.Root = TrueRoot;
                FunctionTree.Current = TrueCurrent;
            }
            else
            {
                // пока не встретим закрывающую скобку, соответствующую уровню вложения
                index++;
                while (Expression[index] != ')')
                {
                    NextRead(Expression);
                }
                index++;
                // если после скобочного выражения оператор умножения или деления
                if ((index != Expression.Length) && (Expression[index] == '*' || Expression[index] == '/' || Expression[index] == '^'))
                {
                    Node N = null;
                    switch (Expression[index])
                    {
                        case '*':
                            N = new Node(Mul);
                            break;
                        case '/':
                            N = new Node(Div);
                            break;
                        case '^':
                            N = new Node(Pow);
                            break;
                    }
                    FunctionTree.Current = FunctionTree.Root;
                    FunctionTree.Root = N;
                    N.Left = FunctionTree.Current;
                    FunctionTree.Current.Parent = N;
                    FunctionTree.Current = N;
                    FunctionTree.Current.IsEnd = false;
                    index++;
                }
                // else
                //index--;
            }
        }

        private void SpecialFunction()
        {
            Node N = null;
            if (Expression.Length - index < 3)
                throw new Exception("Некорректный ввод");
            switch (Expression.Substring(index, 3))
            {
                case "cos":
                    N = new Node(Cos);
                    break;
                case "sqr":
                    N = new Node(Sqrt);
                    break;
                case "sin":
                    N = new Node(Sin);
                    break;
                case "exp":
                    N = new Node(Exp);
                    break;
                case "log":
                    N = new Node(Log);
                    break;
                default:
                    break;
            }
            index = Expression.IndexOf('(', index); // начинаем читать выражение в скобках
            if (FunctionTree.Current == null)
            {
                FunctionTree.Root = N;
            }
            else
            {
                FunctionTree.Current.Right = N;
                N.Parent = FunctionTree.Current;
            }
            FunctionTree.Current = N;
            N.IsEnd = false;
            Node TrueRoot = FunctionTree.Root;
            Node TrueCurrent = FunctionTree.Current;
            FunctionTree.Root = null;
            FunctionTree.Current = null;
            index++;
            while (Expression[index] != ')')
            {
                NextRead(Expression);
            }
            index++;
            TrueCurrent.Left = FunctionTree.Root;
            FunctionTree.Root.Parent = TrueCurrent;
            FunctionTree.Root = TrueRoot;
            if (TrueCurrent.Parent != null)
                FunctionTree.Current = TrueCurrent.Parent;
            else
                FunctionTree.Current = TrueCurrent;
        }

        private void Constant()
        {
            Node N = null;
            if (Expression[index] == 'p')
            {
                if (Expression[index + 1] != 'i')
                {
                    throw new Exception("Некорректные символы");
                }
                index++;
                N = new Node(PI);
                N.IsEnd = true;
                index++;
            }
            else
           if (Expression[index] == 'e')
            {
                N = new Node(E);
                N.IsEnd = true;
                index++;
            }
        }

        private void NumberOrVariable()
        {
            Node N = null;
            if (Expression[index] == 'x')
            {
                index++;
                int n = (int)Char.GetNumericValue(Expression[index]);
                N = new Node(X);
                Node Nn = new Node(n);
                Nn.IsEnd = true;
                N.Left = Nn;
                Nn.Parent = N;
                index++;
                N.IsEnd = false;
                try
                {
                    x.Add(n, 0);
                }
                catch(ArgumentException)
                {

                }
            }           
            else
            {
                string StrNum = "";
                while ((Expression[index] >= '0' && Expression[index] <= '9') || Expression[index] == ',' || Expression[index] == '.')
                {
                    if(Expression[index] == '.')
                    {
                        StrNum += ',';
                    }
                    else
                    {
                        StrNum += Expression[index];
                    }
                    index++;
                    if (index == Expression.Length)
                    {
                        break;
                    }
                }
                double n = Double.Parse(StrNum);
                N = new Node(n);
                N.IsEnd = true;
            }
            if (FunctionTree.Current == null)
            {
                FunctionTree.Current = N;
                FunctionTree.Root = N;
            }
            else
            {
                FunctionTree.Current.Right = N;
                N.Parent = FunctionTree.Current;
            }
        }

        private void AddOrSub()
        {
            Node N = null;
            switch (Expression[index])
            {
                case '+':
                    N = new Node(Add);
                    break;
                case '-':
                    N = new Node(Sub);
                    break;
            }
            FunctionTree.Current = FunctionTree.Root;
            FunctionTree.Root = N;
            N.Left = FunctionTree.Current;
            FunctionTree.Current.Parent = N;
            FunctionTree.Current = N;
            FunctionTree.Current.IsEnd = false;
            index++;
        }

        private void MulOrDiv()
        {
            Node N = null;
            switch (Expression[index])
            {
                case '*':
                    N = new Node(Mul);
                    break;
                case '/':
                    N = new Node(Div);
                    break;
                case '^':
                    N = new Node(Pow);
                    break;
            }
            if ((FunctionTree.Current.Right != null) && FunctionTree.Current.Op != Mul && FunctionTree.Current.Op != Div)
            {
                N.Left = FunctionTree.Current.Right;
                N.Parent = FunctionTree.Current;
                FunctionTree.Current.Right = N;
            }
            else
            {
                if ((FunctionTree.Current.Right != null) && (FunctionTree.Current.Op == Mul || FunctionTree.Current.Op == Div))
                {
                    if (FunctionTree.Root == FunctionTree.Current)
                        FunctionTree.Root = N;
                    else
                        FunctionTree.Current.Parent.Right = N;
                    N.Parent = FunctionTree.Current.Parent;
                }
                else
                {
                    FunctionTree.Root = N;
                }
                N.Left = FunctionTree.Current;
                FunctionTree.Current.Parent = N;
            }
            FunctionTree.Current = N;
            FunctionTree.Current.IsEnd = false;
            index++;
        }

        private void Pow()
        {
            Node N = new Node(Pow);
            if ((FunctionTree.Current.Right != null))
            {
                N.Left = FunctionTree.Current.Right;
                N.Parent = FunctionTree.Current;
                FunctionTree.Current.Right = N;
            }
            else
            {
                FunctionTree.Root = N;
                N.Left = FunctionTree.Current;
                FunctionTree.Current.Parent = N;
            }
            FunctionTree.Current = N;
            FunctionTree.Current.IsEnd = false;
            index++;
        }

        private void NextRead(string Expression)
        {
            // если в начале минус
            if (FunctionTree.Root == null && Expression[index] == '-')
            {
                BeginMinus();
            }
            else
            // скобочное выражение
            if (Expression[index] == '(')
            {
                BracketsExpr();
            }
            else
            // если встретили cos/sin/sqrt/log/exp
            if (Expression[index] == 'c' || Expression[index] == 's' || Expression[index] == 'l')
            {
                SpecialFunction();
            }
            else
            // если число или переменная
            if ((Expression[index] >= '0' && Expression[index] <= '9') || Expression[index] == ',' || Expression[index] == 'x' )
            {
                NumberOrVariable();
            }
            else
            if(Expression[index] == 'e' || Expression[index] == 'p')
            {
                if(Expression[index] == 'e' && Expression[index+1] == 'x')
                {
                    SpecialFunction();
                }
                else
                {
                    Constant();
                }
            }
            else
            // если сложение или вычитание, то создаём новый узел, а старое дерево делаем левый узлом
            if (Expression[index] == '+' || Expression[index] == '-')
            {
                AddOrSub();
            }
            else
            // умножение/деление
            if (Expression[index] == '*' || Expression[index] == '/')
            {
                MulOrDiv();
            }
            else
            // степень
            if (Expression[index] == '^')
            {
                Pow();
            }
            else 
            // пробел
            if(Expression[index] == ' ')
            {
                index++;
            }
            else
            {
                throw new Exception("Некорректные символы");
            }

        }
    }
}

