using System;

namespace kurs_part3
{

    //что первично: вершины или рёбра? (т.е. вершина может быть без вход|выход рёбер или ребро может быть без нач|конеч вершин?)
    public class Node
    {

        public string Name { get; private set; }
        public Edge[] EdgeOut { get; private set; }
        public Edge[] EdgeIn { get;private set; }
        public int NumberOut { get;private set; }
        public int NumberIn { get;private set; }
        public static int Count { get; set; } = 0;

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Node node)
        {
            return node.Name.Equals(Name);
        }

        public Node(string NewName) { Name = (string)NewName.Clone(); NumberOut = 0; NumberIn = 0; EdgeOut = new Edge[0]; EdgeIn = new Edge[0]; Count++; }

        //добавление входящей вершины
        public void AddEdgeIn(Edge NewEdge)
        {
            EdgeIn = Utils<Edge>.ResizeArray(EdgeIn, (uint)EdgeIn.Length + 1);
            EdgeIn[EdgeIn.Length - 1] = NewEdge;
            NumberIn++;
        }

        //добавление выходящей вершины
        public void AddEdgeOut(Edge NewEdge)
        {
            EdgeOut = Utils<Edge>.ResizeArray(EdgeOut, (uint)EdgeOut.Length + 1);
            EdgeOut[EdgeOut.Length - 1] = NewEdge;
            NumberOut++;
        }

        //проверка существования вершины
        public bool Exist()
        {
            if (Name != null) return true;
            return false;
        }

        //finding way from this node to the sink node
        public Edge[] FindWay(Node sink, ref Edge[] way, out bool IsFoundWay)
        {
            IsFoundWay = false;
            if (!Exist()) throw new NullReferenceException();
            if (this == sink) //проверка, не пришли ли мы в сток
            {
                IsFoundWay = true;
                return way;
            }

            uint WayLength = (uint)way.Length;
            way = Utils<Edge>.ResizeArray(way, WayLength + 1);
            if (EdgeOut.Length != 0 || EdgeIn.Length != 0)
            {
                Edge[] CurrentWay = new Edge[0];
                //find next edge in EdgeOut
                for (int i = 0; i < NumberOut; i++)
                {
                    //проверка на циклы в построенном пути
                    bool IsNoCycles = true;
                    for (int j = 0; j < WayLength && IsNoCycles; j++)
                        if (way[j].Equals(EdgeOut[i]))
                            IsNoCycles = false;
                    //поиск пути среди выходящих вершин
                    if (EdgeOut[i].Flow < EdgeOut[i].Bandwidth && IsNoCycles)
                    {
                        way[WayLength] = EdgeOut[i];
                        WayLength++;
                        CurrentWay = EdgeOut[i].End.FindWay(sink, ref way, out IsFoundWay);
                        if (CurrentWay.Length != 0)
                        {
                            IsFoundWay = true;
                            return CurrentWay;
                        }
                        way = Utils<Edge>.ResizeArray(way, WayLength--);
                    }
                }
                //find next edge in EdgeIn
                for (int i = 0; i < NumberIn; i++)
                {
                    //проверка на циклы в построенном пути
                    bool IsNoCycles = true;
                    for (int j = 0; j < WayLength && IsNoCycles; j++)
                        if (way[j].Equals(EdgeIn[i]))
                            IsNoCycles = false;
                    //поиск пути среди выходящих вершин
                    if (EdgeIn[i].Flow > 0 && IsNoCycles)
                    {
                        way[WayLength] = EdgeIn[i];
                        WayLength++;
                        CurrentWay = EdgeIn[i].Begin.FindWay(sink, ref way, out IsFoundWay);
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
