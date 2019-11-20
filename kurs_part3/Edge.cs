using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kurs_part3;

namespace kurs_part3
{
    public class Edge
    {
        private Node begin;
        private Node end;
        private int bandwidth;
        private int flow;

        public Edge (int edge_bandwidth)
        {
            bandwidth = edge_bandwidth;
            begin = null;
            end = null;
            flow = 0;
        }

        public Edge(Node begin_node, Node end_node, int edge_bandwidth)
        {
            if (!begin_node.exist()) throw new ArgumentNullException("Nonexisting begin node");
            if (!end_node.exist()) throw new ArgumentNullException("Nonexisting end node");
            begin = begin_node.copy();
            end = end_node.copy();
            bandwidth = edge_bandwidth;
            flow = 0;
        }

        ~Edge() { }

        //create a copy of this edge
        public Edge copy()
        {
            Edge new_edge = new Edge(begin, end, bandwidth);
            new_edge.setFlow(flow);
            return new_edge;
        }

      /*  public static LinkedList<Edge> copyEdgeArray(LinkedList<Edge> arr)
        {
            if (arr == null) return null;
            LinkedList<Edge> new_arr = new Edge[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                new_arr[i] = arr[i].copy();
            return new_arr;
        }
        */
        public void SetBegin(Node EdgeBegin) { begin = EdgeBegin; }
        public void SetEnd(Node EdgeEnd) { end = EdgeEnd; }

        public Node getBegin() { return begin; }
        public Node getEnd() { return end; }
        public int getBandwidth() { return bandwidth; }
        public int getFlow() { return flow; }

        public void setFlow(int new_flow) { flow = new_flow; }
    }

}
