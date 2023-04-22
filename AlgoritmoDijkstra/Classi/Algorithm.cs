using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Dijkstra
{
    public class Algorithm
    {
        //Qui funziona l'algoritmo vero e proprio, che prende i nodi e le loro connessioni e li ordina a seconda della destinazione
        private readonly Graph graph1;

        public Algorithm(Graph graph)
        {
            graph1 = graph;
        }

        public List<Node> FindPaths(string start)
        {
            graph1.GetNode(start).Distance = 0;

            bool running = true;

            while (running)
            {
                graph1.Nodes.Sort(Comparer<Node>.Create((n, n1) => n.Distance - n1.Distance));
                foreach (Node n in graph1.Nodes)
                {
                    if (n.Distance != -1 && !n.Iterated)
                    {
                        foreach (string s in graph1.Connections.Keys)
                        {
                            if (s.StartsWith(n.Name))
                            {
                                Node current = graph1.GetNode(s.Substring(1, 1));
                                if (current.Distance > graph1.GetNode(n.Name).Distance + graph1.Connections[s] || current.Distance == -1)
                                {
                                    graph1.GetNode(s.Substring(1, 1)).Distance = graph1.GetNode(n.Name).Distance + graph1.Connections[s];
                                    graph1.GetNode(s.Substring(1, 1)).Previous = n.Name;
                                    graph1.GetNode(s.Substring(1, 1)).Iterated = false;
                                }
                            }
                        }
                        n.Iterated = true;
                    }
                }

                running = false;
                foreach (Node n in graph1.Nodes)
                {
                    if (n.Distance == -1)
                    {
                        running = true;
                        break;
                    }
                }
            }


            graph1.Nodes.Sort(Comparer<Node>.Create((n, n1) => n.Name.ToCharArray()[0] - n1.Name.ToCharArray()[0]));

            return graph1.Nodes;
        }

        public string FindPath(string start, string end)
        {
            StringBuilder path = new StringBuilder();
            path.Append(end);
            List<Node> nodes = FindPaths(start);
            Node node = graph1.GetNode(end);
            int distance = node.Distance;

            while (!node.Previous.Equals(""))
            {
                path.Append(node.Previous);
                node = graph1.GetNode(node.Previous);
            }

            if (!path.ToString().StartsWith(end) || !path.ToString().EndsWith(start))
            {
                return "Non esiste alcun percorso tra i 2 nodi selezionati";
            }

            char[] chars = path.ToString().ToCharArray();
            Array.Reverse(chars);

            return new string(chars) + " : " + distance;
        }
    }
}