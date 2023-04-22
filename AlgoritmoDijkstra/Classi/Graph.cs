using System;
using System.Collections.Generic;

namespace Dijkstra.Dijkstra
{
    public class Graph : ICloneable
    {
        public List<Node> Nodes { get; } = new List<Node>();

        public Dictionary<string, int> Connections { get; } = new Dictionary<string, int>();

        public Graph()
        {

        }

        private Graph(List<Node> nodes, Dictionary<string, int> connections)
        {

        }

        //Aggiungo i nodi
        public void AddNode(string name)
        {
            Nodes.Add(new Node(name));
        }

        //Aggiungo le connsessioni tra i nodi e i loro pesi
        public void AddConnection(string name, int weight)
        {
            if (name.Length == 2 && !Connections.ContainsKey(name.ToUpper()))
            {
                string from = name.Substring(0, 1).ToUpper();
                string to = name.Substring(1, 1).ToUpper();
                if (ContainsNode(from) && ContainsNode(to))
                {
                    Connections[from + to] = weight;
                    Connections[to + from] = weight;
                }
            }
        }

        public bool ContainsNode(string name)
        {
            return Nodes.Exists(node => node.Name.Equals(name));

        }

        public Node GetNode(string name)
        {
            return Nodes.Find(node => node.Name.Equals(name));
        }


        public object Clone()
        {
            return new Graph(new List<Node>(Nodes), new Dictionary<string, int>(Connections));
        }

        public override string ToString()
        {
            return "Graph{" +
                   "\nnodes=\n" + string.Join(Environment.NewLine, Nodes) +
                   ", \nconnections=\n" + string.Join(Environment.NewLine, Connections) +
                   "\n}";
        }
    }
}