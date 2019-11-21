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
                web.from_file("file.txt");
                Console.WriteLine("Nodes {0}", Node.count);
                Console.WriteLine("E: {0}; N: {1}", web.GetNumberEdges(), web.GetNumberNodes());
                web.ShowEdges();
                //web.ResShowInWidth(web.GetSource());
                int num = web.GetNumberNodes();
                Node[] nodes = web.GetAllNodes();
                Console.WriteLine(nodes.ToString());
                web.FordFulkerson();
                int flow = web.SummFlow();
                Console.WriteLine("Flow: {0}", flow);
                web.ShowEdges();

                bool IsOK = true;
                for (int i = 0; i < nodes.Length && IsOK; i++)
                {
                    int NodeFlowIn = 0;
                    int NodeFlowOut = 0;
                    Edge[] In = nodes[i].getEdgesIn();
                    Edge[] Out = nodes[i].GetEdgesOut();
                    for (int j = 0; j < In.Length; j++)
                    {
                        NodeFlowIn += In[j].GetFlow();
                    }
                    for (int j = 0; j < Out.Length; j++)
                    {
                        NodeFlowOut += Out[j].GetFlow();
                    }
                    
                    if (NodeFlowIn != NodeFlowOut)
                    {
                        //IsOK = false;
                        Console.Write("! ");
                    }
                    Console.WriteLine(nodes[i].GetName() + ": in=" + NodeFlowIn + ", out=" + NodeFlowOut);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
