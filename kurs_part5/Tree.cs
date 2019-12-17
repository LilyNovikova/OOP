using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
    public class Tree
    {
        public Node Root { get; set; }//корень
        public Node Current { get; set; }//текущий узел
        //вывод дерева
        public void Show()
        {
            Root.Show(0);
        }
    }
}
