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
        private string source_name;
        private string sink_name;
        private Node source;
        private Node sink;
        private Edge[] edges; //array of pointers to edges
        private Node[] nodes;
        int number_edges, number_nodes;

        public int getNumberEdges() { return number_edges; }
        public int getNumberNodes() { return number_nodes; }

        public Node getSource() { return source; }

        public void res_show_in_width(Node current)
        {
            for (int i = 0; i < current.getNumberOut(); i++)
            {
                Console.Write("{0}{1} {2}/{3}; ", current.getName(), current.getEdgesOut()[i].getEnd().getName(), current.getEdgesOut()[i].getFlow(), current.getEdgesOut()[i].getBandwidth());
                res_show_in_width(current.getEdgesOut()[i].getEnd());
            }
        }

        public Node[] get_all_nodes(ref int num)
        {
            if (source.exist())
            {
                Node[] res = new Node[1];
                res[0] = source;
                num = 1;
                for (int i = 0; i < number_edges; i++)
                {
                    bool flag = true;
                    for (int j = 0; j < num && flag; j++)
                        if (edges[i].getEnd() == res[j])
                            flag = false;
                    if (flag)
                    {
                        res = Utils<Node>.ResizeArray(res, (uint)res.Length + 1);
                        res[res.Length - 1] = edges[i].getEnd();
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
            source_name = null;
            sink_name = null;
        }

        public Web(string web_source_name, string web_sink_name)
        {
            source_name = (string)web_source_name.Clone();
            sink_name = (string)web_sink_name.Clone();
            number_edges = 0;
            number_nodes = 0;
        }


        public string getSourceName() { return source_name; }
        public string getSinkName() { return sink_name; }

        public void setSourceName(string web_source_name)
        {
            if (web_source_name == null) throw new ArgumentNullException();
            source_name = web_source_name;
        }

        public void setSinkName(string web_sink_name)
        {
            if (web_sink_name == null) throw new ArgumentNullException();
            sink_name = web_sink_name;
        }

        public bool isEmpty()
        {
            if (number_edges > 0) return false;
            return true;
        }

        ~Web()
        {
        }

        private void add_edge(string new_begin, string new_end, int new_bandwidth)
        {
            if ((new_begin != new_end) && new_bandwidth > 0)
            {
                bool create = true;
                bool new_end_node = true, new_begin_node = true;
                Edge new_edge = new Edge(new_bandwidth);

                for (int i = 0; i < number_edges && create && edges != null; i++)    //find out if nodes with this name exist
                {
                    //if such edge alreadry exist
                    if (edges[i].getBegin().getName() == new_begin && edges[i].getEnd().getName() 
                        == new_end && edges[i].getBandwidth() == new_bandwidth) create = false;

                    //if any node already exist
                    if (edges[i].getBegin().getName().Equals(new_begin))
                    {
                        new_edge.SetBegin(edges[i].getBegin());
                        new_begin_node = false;
                    }
                    if (edges[i].getEnd().getName().Equals(new_begin))
                    {
                        new_edge.SetBegin(edges[i].getEnd());
                        new_begin_node = false;
                    }

                    if (edges[i].getBegin().getName().Equals(new_end))
                    {
                        new_edge.SetEnd(edges[i].getBegin());
                        new_end_node = false;
                    }
                    if (edges[i].getEnd().getName().Equals(new_end))
                    {
                        new_edge.SetEnd(edges[i].getEnd());
                        new_end_node = false;
                    }
                }

                if (create)
                {
                    if (new_begin_node)
                    {
                        new_edge.SetBegin(new Node(new_begin));
                        number_nodes++;
                    }
                    if (new_end_node)
                    {
                        new_edge.SetEnd(new Node(new_end));
                        number_nodes++;
                    }

                    if (new_begin.Equals(source_name))
                        source = new_edge.getBegin();
                    if (new_end.Equals(sink_name))
                        sink = new_edge.getEnd();

                    //initialize edge to nodes
                    new_edge.getBegin().addEdgeOut(new_edge);
                    new_edge.getEnd().addEdgeIn(new_edge);

                    edges = Utils<Edge>.ResizeArray(edges, (uint)edges.Length + 1);
                    edges[edges.Length - 1] = new_edge;
                    number_edges++;

                }
                else
                    throw new ArgumentException("Trying add an existing edge");
            }
            else
            {
                if (new_begin.Equals(new_end)) throw new ArgumentException("Trying to add loop edge");
                else throw new ArgumentException("Trying to add edge with bandwidth less 1");
            }
        }

        public void FordFulkerson()
        {
            if (!source_name.Equals(source.getName())) throw new ArgumentNullException("No source in the web");
            if (!sink_name.Equals(sink.getName())) throw new ArgumentNullException("No sink in the web");
            Edge[] path = new Edge[0];
            bool way_found_flag = false;
            path = source.findWay(sink, ref path, out way_found_flag);//find a find_way way from source to sink
            if (path.Length <= 1) throw new Exception("Can't find way from source to sink");
            int k = 0;
            while (way_found_flag)
            {
                k++;
                int min_bandwidth = path[0].getBandwidth() - path[0].getFlow();
                bool prev_direction = true;
                for (int i = 1; i < path.Length; i++)
                {
                    if ((path[i-1].getEnd() == path[i].getBegin() && prev_direction) || 
                        (path[i-1].getBegin() == path[i].getBegin() && !prev_direction))
                    {
                        if (path[i].getBandwidth() - path[i].getFlow() < min_bandwidth)
                            min_bandwidth = path[i].getBandwidth() - path[i].getFlow();
                        prev_direction = true;
                    }
                    else
                    {
                        prev_direction = false;
                        if (path[i].getFlow() < min_bandwidth)
                            min_bandwidth = path[i].getFlow();
                    }

                }

                path[0].setFlow(path[0].getFlow() + min_bandwidth);
                prev_direction = true;
                for (int i = 1; i < path.Length; i++)
                    if ((path[i-1].getEnd() == path[i].getBegin() && prev_direction) || 
                        (path[i-1].getBegin() == path[i].getBegin() && !prev_direction))
                    {
                        prev_direction = true;
                        path[i].setFlow(path[i].getFlow() + min_bandwidth);
                    }
                    else
                    {
                        prev_direction = false;
                        path[i].setFlow(path[i].getFlow() + min_bandwidth);
                    }
                for (int i = 0; i < path.Length; i++)
                    //printf("%c%c[%i/%i]", path.ElementAt<Edge>(i)->begin->name, path.ElementAt<Edge>(i)->end->name, path[i]->flow, path[i]->bandwidth);
                    Console.WriteLine("{0} {1} [{2}/{3}]", path[i].getBegin().getName(), path[i].getEnd().getName(), 
                        path[i].getFlow(), path[i].getBandwidth());
                path = source.findWay(sink, ref path, out way_found_flag);   //find a find_way way from source to sink

            }
        }

        public void show_edges()
        {
            for (int i = 0; i < number_edges; i++)
                Console.WriteLine("{0} {1} [{2}/{3}]", edges[i].getBegin().getName(), edges[i].getEnd().getName(), edges[i].getFlow(), edges[i].getBandwidth());
        }

        public int summ_flow()
        {
            if (source_name.Equals(source.getName()))
            {
                int res = 0;
                for (int i = 0; i < source.getNumberOut(); i++)
                    res += source.getEdgesOut()[i].getFlow();
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
            source_name = str_array[0];
            sink_name = str_array[1];
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
                    add_edge(edge_out, edge_in, bandwidth);
                }
                //Console.WriteLine(str);

            }
            read.Close();
        }

    }
}
