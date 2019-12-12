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

    }

}
