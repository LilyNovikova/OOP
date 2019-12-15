using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public delegate double Operation(Node a, Node b);
    public class Node
    {
        public bool IsEnd; // конечен ли узел
        public Node Left { get; set; } // левый дочерний узел
        public Node Right { get; set; } // правый дочерний узел
        public Node Parent { get; set; } // родительский узел
        public Operation Op { get; set; } // операция
        private double _Value; // численное значение
        public double Value // значение дерева из узла
        {
            get
            {
                switch (IsEnd)
                {
                    case true:
                        return _Value;
                    case false:
                        return Op(Left, Right);
                    default:
                        return 0;
                }
            }
        }
        public Node()
        {
            this.IsEnd = true;
            this.Left = null;
            this.Right = null;
            this.Parent = null;
        }
        public Node(double value) : this()
        {
            this.Op = null;
            this._Value = value;
        }
        public Node(Operation x) : this()
        {
            this.Op = x;
            this._Value = 0;
        }

        public override string ToString()
        {
            return "[" + (Op != null ? Op.Method.Name : _Value.ToString()) + "]";
        }
        public void Show(int level)
        {
            if (this != null)
            {
                //right subtree
                if (Right != null)
                {
                    Right.Show(level + 1);
                }

                //this
                for (int i = 1; i < level; i++)
                {
                    Console.Write(Utils.GetNChars(11, ' ') + '|');
                }
                if (level != 0)
                {
                    Console.Write(Utils.GetNChars(11, ' ') + '|');
                }
                Console.Write(this);

                if (Left != null && Right != null)
                {
                    Console.WriteLine("<");
                }
                else
                if (Right != null)
                {
                    Console.WriteLine("/");
                }
                else
                if (Left != null)
                {
                    Console.WriteLine("\\");
                }
                else
                {
                    Console.WriteLine("");
                }

                //left subtree
                if (Left != null)
                {
                    Left.Show(level + 1);
                }
                Console.WriteLine("");
            }
        }

    }
}
