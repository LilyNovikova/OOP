using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using kurs_part3;

namespace kurs_part3
{
    class Test
    {
        public static void Main()
        {
            try
            {
                Web web = new Web();
                web.from_file("file1.txt");
                Console.WriteLine("Nodes {0}", Node.count);
                Console.WriteLine("E: {0}; N: {1}", web.getNumberEdges(), web.getNumberNodes());
                web.show_edges();
                web.res_show_in_width(web.getSource());
                int num = web.getNumberNodes();
                Console.WriteLine(web.get_all_nodes(ref num).ToString());
                web.FordFulkerson();
                int flow = web.summ_flow();
                Console.WriteLine("Flow: {0}", flow);
                web.show_edges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
