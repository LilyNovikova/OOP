using System;

namespace kurs_part3
{
    public class Edge
    {
        public Node Begin { get; set; }
        public Node End { get; set; }
        public int Bandwidth { get; private set; }
        public int Flow { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}[{2}/{3}]", Begin, End, Flow, Bandwidth);
        }

        public bool Equals(Edge edge)
        {
            return (edge.Begin.Equals(Begin) && edge.End.Equals(End) || edge.Begin.Equals(End) && edge.End.Equals(Begin));
        }

        public Edge (int EdgeBandwidth)
        {
            Bandwidth = EdgeBandwidth;
            Begin = null;
            End = null;
            Flow = 0;
        }

        public Edge(Node BeginNode, Node EndNode, int EdgeBandwidth)
        {
            if (!BeginNode.Exist()) throw new ArgumentNullException("Nonexisting begin node");
            if (!EndNode.Exist()) throw new ArgumentNullException("Nonexisting end node");
            Begin = BeginNode.copy();
            End = EndNode.copy();
            Bandwidth = EdgeBandwidth;
            Flow = 0;
        }

        ~Edge() { }

    }

}
