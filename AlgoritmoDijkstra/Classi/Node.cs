namespace Dijkstra.Dijkstra
{
    public class Node
    {
        public Node(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public int Distance { get; set; } = -1;
        public string Previous { get; set; } = "";
        public bool Iterated { get; set; } = false;

        public override string ToString()
        {
            return "Nodo {" +
                   Name +
                   ", distanza=" + Distance +
                   ", precedente='" + Previous + '\'' +
                   '}';
        }
    }
}