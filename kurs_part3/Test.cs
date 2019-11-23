using System;

namespace kurs_part3
{
    class Test
    {
        public static string InputFileName = "net.txt";
        public static Web web;
        public static string[] FileContent;

        public static void Main()
        {
            try
            {
                FileContent = FileUtils.ReadText(InputFileName);
                web = new Web();
                web.SourceName = FileContent[0].Split(' ')[0];
                web.SinkName = FileContent[0].Split(' ')[1];
                web.AddEdges(FileContent);

                Console.WriteLine("E: {0}; N: {1}", web.NumberEdges, web.NumberNodes);

                Node[] nodes = web.GetAllNodes();

                web.FordFulkersonAlgorithm();
                int flow = web.SummFlow();
                Console.WriteLine("Flow: {0}", flow);
                Console.WriteLine(Utils<Edge>.ArrayToText(web.Edges));

                //check if in- and out-flows are correct for each node 
                bool IsOK = true;
                for (int i = 0; i < nodes.Length; i++)
                {
                    int NodeFlowIn = 0;
                    int NodeFlowOut = 0;
                    Edge[] In = nodes[i].EdgeIn;
                    Edge[] Out = nodes[i].EdgeOut;
                    for (int j = 0; j < In.Length; j++)
                    {
                        NodeFlowIn += In[j].Flow;
                    }
                    for (int j = 0; j < Out.Length; j++)
                    {
                        NodeFlowOut += Out[j].Flow;
                    }
                    //for middle nodes
                    if (NodeFlowIn != NodeFlowOut && i != 0 && i != (nodes.Length - 1))
                    {
                        IsOK = false;
                        Console.Write("! ");
                    }
                    //for source
                    if ((NodeFlowIn != 0 || NodeFlowOut != flow) && i == 0)
                    {
                        IsOK = false;
                        Console.Write("! ");
                    }
                    //for sink
                    if ((NodeFlowIn != flow || NodeFlowOut != 0) && i == (nodes.Length - 1))
                    {
                        IsOK = false;
                        Console.Write("! ");
                    }
                    Console.WriteLine(nodes[i].Name + ": in=" + NodeFlowIn + ", out=" + NodeFlowOut);
                }
                Console.WriteLine("result: {0}", IsOK);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
