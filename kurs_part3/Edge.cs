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

        public override string ToString()
        {
            return string.Format("{0}-{1}[{2}/{3}]", begin, end, flow, bandwidth);
        }

        public bool Equals(Edge edge)
        {
            return (edge.begin.Equals(begin) && edge.end.Equals(end) || edge.begin.Equals(end) && edge.end.Equals(begin));
        }

        public bool HasCommonNode(Edge edge)
        {
            return (edge.begin.Equals(begin) || edge.end.Equals(end) || edge.begin.Equals(end) || edge.end.Equals(begin));
        }

        public Edge (int edge_bandwidth)
        {
            bandwidth = edge_bandwidth;
            begin = null;
            end = null;
            flow = 0;
        }

        public Edge(Node begin_node, Node end_node, int edge_bandwidth)
        {
            if (!begin_node.Exist()) throw new ArgumentNullException("Nonexisting begin node");
            if (!end_node.Exist()) throw new ArgumentNullException("Nonexisting end node");
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
            new_edge.SetFlow(flow);
            return new_edge;
        }
        public void SetBegin(Node EdgeBegin) { begin = EdgeBegin; }
        public void SetEnd(Node EdgeEnd) { end = EdgeEnd; }

        public Node GetBegin() { return begin; }
        public Node GetEnd() { return end; }
        public int GetBandwidth() { return bandwidth; }
        public int GetFlow() { return flow; }

        public void SetFlow(int new_flow) { flow = new_flow; }
    }

}
