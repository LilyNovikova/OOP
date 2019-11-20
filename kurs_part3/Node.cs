using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using kurs_part3;

namespace kurs_part3
{

    //что первично: вершины или рёбра? (т.е. вершина может быть без вход|выход рёбер или ребро может быть без нач|конеч вершин?)
    public class Node
    {
        
        private string name;
        private Edge[] edge_out;
        private Edge[] edge_in;
        private int number_out;
        private int number_in;
        public static int count = 0;

        public Node() { name = null; number_out = 0; number_in = 0; edge_out = new Edge[0]; edge_in = new Edge[0]; }
        public Node(string new_name) { name = (string)new_name.Clone(); number_out = 0; number_in = 0; edge_out = new Edge[0]; edge_in = new Edge[0]; count++; }
        ~Node() { }

        public string getName() { return name; }
        public Edge[] getEdgesOut() { return edge_out; }
        public Edge[] getEdgesIn() { return edge_in; }
        public int getNumberOut() { return number_out; }
        public int getNumberIn() { return number_in; }

        public void addEdgeIn(Edge new_edge)
        {
            edge_in = Utils<Edge>.ResizeArray(edge_in, (uint)edge_in.Length + 1);
            edge_in[edge_in.Length - 1] =  new_edge;
            number_in++;
        }

        public void addEdgeOut(Edge new_edge)
        {
            edge_out = Utils<Edge>.ResizeArray(edge_out, (uint)edge_out.Length + 1);
            edge_out[edge_out.Length - 1] = new_edge;
            number_out++;
        }

        public bool exist()
        {
            if (name != null) return true;
            return false;
        }

        public Node copy()
        {
            Node new_node = new Node(name);
            new_node.edge_in = edge_in;
            new_node.edge_out = edge_out;
            new_node.number_in = number_in;
            new_node.number_out = number_out;
            return new_node;
        }

        //finding way from this node to the sink node
        public Edge[] findWay(Node sink, ref Edge[] way, out bool way_found_flag)
        {
            way_found_flag = false;
            if (!exist()) throw new NullReferenceException();
            if (this == sink)
            {
                way_found_flag = true;
                return way;
            }

            int way_length = way.Length;

            if (edge_out.Length != 0 || edge_in.Length != 0)
            {
                Edge[] current_way = new Edge[0];
                //
                for (int i = 0; i < number_out; i++)
                {
                    bool no_cycles = true;
                    for (int j = 0; j < way_length && no_cycles; j++)
                        if (way[j].Equals(edge_out[i]))
                            no_cycles = false;

                    if (edge_out[i].getFlow() < edge_out[i].getBandwidth() && no_cycles)
                    {
                        //delete last and add this el or just add in empty space???
                        way = Utils<Edge>.ResizeArray(way, (uint)way.Length + 1);
                        way[way.Length - 1] = edge_out[i];
                        current_way = edge_out[i].getEnd().findWay(sink, ref way, out way_found_flag);
                        if (current_way.Length != 0)
                        {
                            way_found_flag = true;
                            return current_way;
                        }
                        //way = cut_array(way, way_length, len + 1);
                    }
                }
                //
                for (int i = 0; i < number_in; i++)
                {
                    bool no_cycles = true;
                    for (int j = 0; j < way_length && no_cycles; j++)
                        if (way[j].Equals(edge_in[i]))
                            no_cycles = false;

                    if (edge_in[i].getFlow() > 0 && no_cycles)
                    {
                        //delete last and add this el or just add in empty space???
                        way = Utils<Edge>.ResizeArray(way, (uint)way.Length + 1);
                        way[way.Length - 1] = edge_in[i];
                        way_length++;
                        current_way = edge_in[i].getBegin().findWay(sink, ref way, out way_found_flag);
                        if (current_way.Length != 0)
                        {
                            way_found_flag = true;
                            return current_way;
                        }
                        //way = cut_array(way, way_length, len + 1);
                    }
                }

            }
            return way;
        }
    }

}
