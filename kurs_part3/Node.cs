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
        private Edge[] EdgeOut;
        private Edge[] EdgeIn;
        private int number_out;
        private int number_in;
        public static int count = 0;

        public override string ToString()
        {
            return name;
        }

        public bool Equals(Node node)
        {
            return node.name.Equals(name);
        }

        public Node() { name = null; number_out = 0; number_in = 0; EdgeOut = new Edge[0]; EdgeIn = new Edge[0]; }
        public Node(string new_name) { name = (string)new_name.Clone(); number_out = 0; number_in = 0; EdgeOut = new Edge[0]; EdgeIn = new Edge[0]; count++; }
        ~Node() { }

        public string GetName() { return name; }
        public Edge[] GetEdgesOut() { return EdgeOut; }
        public Edge[] getEdgesIn() { return EdgeIn; }
        public int getNumberOut() { return number_out; }
        public int getNumberIn() { return number_in; }

        public void addEdgeIn(Edge new_edge)
        {
            EdgeIn = Utils<Edge>.ResizeArray(EdgeIn, (uint)EdgeIn.Length + 1);
            EdgeIn[EdgeIn.Length - 1] = new_edge;
            number_in++;
        }

        public void addEdgeOut(Edge new_edge)
        {
            EdgeOut = Utils<Edge>.ResizeArray(EdgeOut, (uint)EdgeOut.Length + 1);
            EdgeOut[EdgeOut.Length - 1] = new_edge;
            number_out++;
        }

        public bool Exist()
        {
            if (name != null) return true;
            return false;
        }

        public Node copy()
        {
            Node new_node = new Node(name);
            new_node.EdgeIn = EdgeIn;
            new_node.EdgeOut = EdgeOut;
            new_node.number_in = number_in;
            new_node.number_out = number_out;
            return new_node;
        }

        //finding way from this node to the sink node
        public Edge[] FindWay(Node sink, ref Edge[] way, out bool IsFoundWay)
        {
            IsFoundWay = false;
            if (!Exist()) throw new NullReferenceException();
            if (this == sink)
            {
                IsFoundWay = true;
                return way;
            }

            uint WayLength = (uint)way.Length;
            way = Utils<Edge>.ResizeArray(way, WayLength + 1);
            if (EdgeOut.Length != 0 || EdgeIn.Length != 0)
            {
                Edge[] CurrentWay = new Edge[0];
                //
                for (int i = 0; i < number_out; i++)
                {
                    bool IsNoCycles = true;
                    for (int j = 0; j < WayLength && IsNoCycles; j++)
                        if (way[j].Equals(EdgeOut[i]))
                            IsNoCycles = false;

                    if (EdgeOut[i].GetFlow() < EdgeOut[i].GetBandwidth() && IsNoCycles)
                    {
                        way[WayLength] = EdgeOut[i];
                        WayLength++;
                        CurrentWay = EdgeOut[i].GetEnd().FindWay(sink, ref way, out IsFoundWay);
                        if (CurrentWay.Length != 0)
                        {
                            IsFoundWay = true;
                            return CurrentWay;
                        }
                        way = Utils<Edge>.ResizeArray(way, WayLength--);
                    }
                }
                //
                for (int i = 0; i < number_in; i++)
                {
                    bool IsNoCycles = true;
                    for (int j = 0; j < WayLength && IsNoCycles; j++)
                        if (way[j].Equals(EdgeIn[i]))
                            IsNoCycles = false;

                    if (EdgeIn[i].GetFlow() > 0 && IsNoCycles)
                    {
                        way[WayLength] = EdgeIn[i];
                        WayLength++;
                        CurrentWay = EdgeIn[i].GetBegin().FindWay(sink, ref way, out IsFoundWay);
                        if (CurrentWay.Length != 0)
                        {
                            IsFoundWay = true;
                            return CurrentWay;
                        }
                        way = Utils<Edge>.ResizeArray(way, WayLength--);
                    }
                }

            }
            return new Edge[0];
        }
    }

}
