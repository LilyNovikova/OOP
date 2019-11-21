using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using kurs_part3;

namespace kurs_part3
{
    public class Web
    {
        private string SourceName;
        private string SinkName;
        private Node source;
        private Node sink;
        private Edge[] edges; //array of pointers to edges
        int number_edges, number_nodes;

        public int GetNumberEdges() { return number_edges; }
        public int GetNumberNodes() { return number_nodes; }

        public Node GetSource() { return source; }

        public void ResShowInWidth(Node current)
        {
            for (int i = 0; i < current.getNumberOut(); i++)
            {
                Console.Write(current.GetEdgesOut()[i]);
                ResShowInWidth(current.GetEdgesOut()[i].GetEnd());
            }
        }

        public Node[] GetAllNodes()
        {
            if (source.Exist())
            {
                Node[] res = new Node[1];
                res[0] = source;
                int num = 1;
                for (int i = 0; i < number_edges; i++)
                {
                    bool flag = true;
                    for (int j = 0; j < num && flag; j++)
                        if (edges[i].GetEnd() == res[j])
                            flag = false;
                    if (flag)
                    {
                        res = Utils<Node>.ResizeArray(res, (uint)res.Length + 1);
                        res[res.Length - 1] = edges[i].GetEnd();
                        //cout << res[num]->name << "  ";
                        num++;
                    }
                }
                return res;
            }
            throw new ArgumentNullException("This web has no nodes");
        }

        public Web()
        {
            edges = new Edge[0];
            number_edges = 0;
            number_nodes = 0;
            SourceName = null;
            SinkName = null;
        }

        public Web(string WebSourceName, string WebSinkName)
        {
            SourceName = (string)WebSourceName.Clone();
            SinkName = (string)WebSinkName.Clone();
            number_edges = 0;
            number_nodes = 0;
        }

        public string getSourceName() { return SourceName; }
        public string getSinkName() { return SinkName; }

        public void SetSourceName(string WebSourceName)
        {
            if (WebSourceName == null) throw new ArgumentNullException();
            SourceName = WebSourceName;
        }

        public void SetSinkName(string WebSinkName)
        {
            if (WebSinkName == null) throw new ArgumentNullException();
            SinkName = WebSinkName;
        }

        public bool IsEmpty()
        {
            if (number_edges > 0) return false;
            return true;
        }

        ~Web()
        {
        }

        private void AddEdge(string NewBegin, string NewEnd, int NewBandwidth)
        {
            if ((NewBegin != NewEnd) && NewBandwidth > 0)
            {
                bool create = true;
                bool new_end_node = true, new_begin_node = true;
                Edge new_edge = new Edge(NewBandwidth);

                for (int i = 0; i < number_edges && create && edges != null; i++)    //find out if nodes with this name exist
                {
                    //if such edge alreadry exist
                    if (edges[i].GetBegin().GetName() == NewBegin && edges[i].GetEnd().GetName()
                        == NewEnd && edges[i].GetBandwidth() == NewBandwidth) create = false;

                    //if any node already exist
                    if (edges[i].GetBegin().GetName().Equals(NewBegin))
                    {
                        new_edge.SetBegin(edges[i].GetBegin());
                        new_begin_node = false;
                    }
                    if (edges[i].GetEnd().GetName().Equals(NewBegin))
                    {
                        new_edge.SetBegin(edges[i].GetEnd());
                        new_begin_node = false;
                    }

                    if (edges[i].GetBegin().GetName().Equals(NewEnd))
                    {
                        new_edge.SetEnd(edges[i].GetBegin());
                        new_end_node = false;
                    }
                    if (edges[i].GetEnd().GetName().Equals(NewEnd))
                    {
                        new_edge.SetEnd(edges[i].GetEnd());
                        new_end_node = false;
                    }
                }

                if (create)
                {
                    if (new_begin_node)
                    {
                        new_edge.SetBegin(new Node(NewBegin));
                        number_nodes++;
                    }
                    if (new_end_node)
                    {
                        new_edge.SetEnd(new Node(NewEnd));
                        number_nodes++;
                    }

                    if (NewBegin.Equals(SourceName))
                        source = new_edge.GetBegin();
                    if (NewEnd.Equals(SinkName))
                        sink = new_edge.GetEnd();

                    //initialize edge to nodes
                    new_edge.GetBegin().addEdgeOut(new_edge);
                    new_edge.GetEnd().addEdgeIn(new_edge);

                    edges = Utils<Edge>.ResizeArray(edges, (uint)edges.Length + 1);
                    edges[edges.Length - 1] = new_edge;
                    number_edges++;

                }
                else
                    throw new ArgumentException("Trying add an existing edge");
            }
            else
            {
                if (NewBegin.Equals(NewEnd)) throw new ArgumentException("Trying to add loop edge");
                else throw new ArgumentException("Trying to add edge with bandwidth less 1");
            }
        }

        public void FordFulkerson()
        {
            if (!SourceName.Equals(source.GetName())) throw new ArgumentNullException("No source in the web");
            if (!SinkName.Equals(sink.GetName())) throw new ArgumentNullException("No sink in the web");

            Edge[] path = new Edge[0];
            bool IsWayFound = false;
            path = source.FindWay(sink, ref path, out IsWayFound);//find a find_way way from source to sink

            if (path.Length <= 1) throw new Exception("Can't find way from source to sink");
            while (IsWayFound)
            {
                //finding min flow
                int MinBandwidth = path[0].GetBandwidth() - path[0].GetFlow();
                bool PrevDirection = true;
                for (int i = 1; i < path.Length; i++)
                {
                    if ((path[i - 1].GetEnd().GetName().Equals(path[i].GetBegin().GetName()) && PrevDirection) ||
                        ((path[i - 1].GetBegin().GetName()).Equals(path[i].GetBegin().GetName()) && !PrevDirection))
                    {
                        if (path[i].GetBandwidth() - path[i].GetFlow() < MinBandwidth)
                        {
                            MinBandwidth = path[i].GetBandwidth() - path[i].GetFlow();
                        }
                        PrevDirection = true;
                    }
                    else
                    {
                        PrevDirection = false;
                        if (path[i].GetFlow() < MinBandwidth)
                        {
                            MinBandwidth = path[i].GetFlow();
                        }
                    }
                }

                path[0].SetFlow(path[0].GetFlow() + MinBandwidth);
                PrevDirection = true;
                for (int i = 1; i < path.Length; i++)
                {
                    if ((path[i - 1].GetEnd().GetName().Equals(path[i].GetBegin().GetName()) && PrevDirection) ||
                       ((path[i - 1].GetBegin().GetName()).Equals(path[i].GetBegin().GetName()) && !PrevDirection))
                    {
                        PrevDirection = true;
                        path[i].SetFlow(path[i].GetFlow() + MinBandwidth);
                    }
                    else
                    {
                        PrevDirection = false;
                        path[i].SetFlow(path[i].GetFlow() - MinBandwidth);
                    }
                }

                path = new Edge[0];
                path = source.FindWay(sink, ref path, out IsWayFound);   //find a find_way way from source to sink
                ////End of debug block////
            }
        }

        public void ShowEdges()
        {
            for (int i = 0; i < number_edges; i++)
                Console.WriteLine(edges[i]);
        }

        public int SummFlow()
        {
            if (SourceName.Equals(source.GetName()))
            {
                int res = 0;
                for (int i = 0; i < source.getNumberOut(); i++)
                    res += source.GetEdgesOut()[i].GetFlow();
                return res;
            }
            else throw new Exception("No source node to count flow");
        }

        public void from_file(string filename)
        {
            StreamReader read = new StreamReader(filename);
            //go to the beginning of the file

            string str = read.ReadLine();
            string[] str_array = str.Split(' ');
            SourceName = str_array[0];
            SinkName = str_array[1];
            while (read.Peek() != -1)
            {
                str = read.ReadLine();
                if (str.Length > 4)
                {
                    string edge_in = null, edge_out = null;
                    int bandwidth;

                    str_array = str.Split(' ');

                    edge_out = str_array[0];
                    edge_in = str_array[1];

                    //check if string str_array[2] contains nonnumeric symbols and cut them
                    char[] char_arr = str_array[2].ToCharArray();
                    int i = 0;
                    foreach (char c in char_arr)
                        if (c > '9' || c < '0') break;
                        else i++;
                    bandwidth = int.Parse(str_array[2].Substring(0, i));
                    AddEdge(edge_out, edge_in, bandwidth);
                }
                //Console.WriteLine(str);

            }
            read.Close();
        }

    }
}
