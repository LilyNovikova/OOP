using System;

namespace kurs_part3
{
    public class Web
    {
        private string _SourceName;
        public string SourceName
        {
            get
            {
                return _SourceName;
            }
            set
            {
                if (value == null) { throw new ArgumentNullException("Source name is null"); }
                _SourceName = value;
            }
        }
        private string _SinkName;
        public string SinkName
        {
            get
            {
                return _SinkName;
            }
            set
            {
                if (value == null) { throw new ArgumentNullException("Sink name is null"); }
                _SinkName = value;
            }
        }
        private Node Source;
        private Node Sink;
        public Edge[] Edges { get; private set; }//array of pointers to edges
        public int NumberEdges { get; private set; }
        public int NumberNodes { get; private set; }

        public Node[] GetAllNodes()
        {
            if (Source.Exist())
            {
                Node[] res = new Node[1];
                res[0] = Source;
                int num = 1;
                for (int i = 0; i < NumberEdges; i++)
                {
                    bool flag = true;
                    for (int j = 0; j < num && flag; j++)
                        if (Edges[i].End == res[j])
                            flag = false;
                    if (flag)
                    {
                        res = Utils<Node>.ResizeArray(res, (uint)res.Length + 1);
                        res[res.Length - 1] = Edges[i].End;
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
            Edges = new Edge[0];
            NumberEdges = 0;
            NumberNodes = 0;
        }
        public Web(string WebSourceName, string WebSinkName)
        {
            SourceName = (string)WebSourceName.Clone();
            SinkName = (string)WebSinkName.Clone();
            NumberEdges = 0;
            NumberNodes = 0;
        }

        public void AddEdge(string NewBegin, string NewEnd, int NewBandwidth)
        {
            if ((NewBegin != NewEnd) && NewBandwidth > 0)
            {
                bool create = true;
                bool NewEndNode = true, NewBeginNode = true;
                Edge NewEdge = new Edge(NewBandwidth);

                foreach(Edge Edge in Edges)    //find out if nodes with this name exist
                {
                    //if such edge alreadry exist
                    if (Edge.Begin.Name == NewBegin && Edge.End.Name
                        == NewEnd && Edge.Bandwidth == NewBandwidth)
                    {
                        create = false;
                        break;
                    }
                    //if any node already exist
                    if (Edge.Begin.Name.Equals(NewBegin))
                    {
                        NewEdge.Begin = Edge.Begin;
                        NewBeginNode = false;
                    }
                    if (Edge.End.Name.Equals(NewBegin))
                    {
                        NewEdge.Begin = Edge.End;
                        NewBeginNode = false;
                    }

                    if (Edge.Begin.Name.Equals(NewEnd))
                    {
                        NewEdge.End = Edge.Begin;
                        NewEndNode = false;
                    }
                    if (Edge.End.Name.Equals(NewEnd))
                    {
                        NewEdge.End = Edge.End;
                        NewEndNode = false;
                    }
                }

                if (create)
                {
                    if (NewBeginNode)
                    {
                        NewEdge.Begin = new Node(NewBegin);
                        NumberNodes++;
                    }
                    if (NewEndNode)
                    {
                        NewEdge.End = new Node(NewEnd);
                        NumberNodes++;
                    }

                    if (NewBegin.Equals(SourceName))
                        Source = NewEdge.Begin;
                    if (NewEnd.Equals(SinkName))
                        Sink = NewEdge.End;

                    //initialize edge to nodes
                    NewEdge.Begin.AddEdgeOut(NewEdge);
                    NewEdge.End.AddEdgeIn(NewEdge);

                    Edges = Utils<Edge>.ResizeArray(Edges, (uint)Edges.Length + 1);
                    Edges[Edges.Length - 1] = NewEdge;
                    NumberEdges++;

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

        private int FindMinAdditionalFlow(Edge[] path)
        {
            int MinAddFlow = path[0].Bandwidth - path[0].Flow;
            bool PrevDirection = true;
            for (int i = 1; i < path.Length; i++)
            {
                if ((path[i - 1].End.Name.Equals(path[i].Begin.Name) && PrevDirection) ||
                    ((path[i - 1].Begin.Name).Equals(path[i].Begin.Name) && !PrevDirection))
                {
                    if (path[i].Bandwidth - path[i].Flow < MinAddFlow)
                    {
                        MinAddFlow = path[i].Bandwidth - path[i].Flow;
                    }
                    PrevDirection = true;
                }
                else
                {
                    PrevDirection = false;
                    if (path[i].Flow < MinAddFlow)
                    {
                        MinAddFlow = path[i].Flow;
                    }
                }
            }
            return MinAddFlow;
        }

        private Edge[] AddFlow(Edge[] path, int AdditionalFlow)
        {
            path[0].Flow = path[0].Flow + AdditionalFlow;
            bool PrevDirection = true;
            for (int i = 1; i < path.Length; i++)
            {
                if ((path[i - 1].End.Name.Equals(path[i].Begin.Name) && PrevDirection) ||
                   ((path[i - 1].Begin.Name).Equals(path[i].Begin.Name) && !PrevDirection))
                {
                    PrevDirection = true;
                    path[i].Flow = path[i].Flow + AdditionalFlow;
                }
                else
                {
                    PrevDirection = false;
                    path[i].Flow = path[i].Flow - AdditionalFlow;
                }
            }
            return path;
        }
 
        public void FordFulkersonAlgorithm()
        {
            if (!SourceName.Equals(Source.Name)) throw new ArgumentNullException("No source in the web");
            if (!SinkName.Equals(Sink.Name)) throw new ArgumentNullException("No sink in the web");

            Edge[] path = new Edge[0];
            bool IsWayFound = false;
            path = Source.FindWay(Sink, ref path, out IsWayFound);//find a find_way way from source to sink

            if (path.Length < 1) throw new Exception("Can't find way from source to sink");
            while (IsWayFound)
            {
                //finding min flow
                int AdditionalFlow = FindMinAdditionalFlow(path);

                //setting new flows for the path
                path = AddFlow(path, AdditionalFlow);

                path = new Edge[0];
                path = Source.FindWay(Sink, ref path, out IsWayFound);   //find a find_way way from source to sink
            }
        }

        public int SummFlow()
        {
            if (SourceName.Equals(Source.Name))
            {
                int res = 0;
                for (int i = 0; i < Source.NumberOut; i++)
                    res += Source.EdgeOut[i].Flow;
                return res;
            }
            else throw new Exception("No source node to count flow");
        }

        /*string format: "{BeginNode} {EndNode} {Bandwidth}"*/
        public void AddEdges(string[] EdgesStringArray)
        {
            foreach (string EdgeString in EdgesStringArray)
            {
                string[] StrArray = EdgeString.Split(' ');
                if (StrArray.Length > 2)
                {
                    string EdgeIn = null;
                    string EdgeOut = null;
                    int Bandwidth;

                    EdgeOut = StrArray[0];
                    EdgeIn = StrArray[1];

                    //check if string StrArray[2] contains NonDigits and cut them
                    char[] CharArr = StrArray[2].ToCharArray();
                    int i = 0;
                    foreach (char c in CharArr)
                        if (c > '9' || c < '0') break;
                        else i++;
                    Bandwidth = int.Parse(StrArray[2].Substring(0, i));
                    AddEdge(EdgeOut, EdgeIn, Bandwidth);
                }
            }
        }

    }
}
