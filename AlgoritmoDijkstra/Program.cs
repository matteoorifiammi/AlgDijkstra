using System;

namespace Dijkstra
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(string.Join(Environment.NewLine, new Dijkstra.Algorithm(Example()).FindPaths("A")));

            //Da qui inserirsco il percorso che voglio trovare
            Console.WriteLine("\nIl percorso tra i nodi e la loro distanza e':");
            Console.WriteLine(new Dijkstra.Algorithm(Example()).FindPath("C", "E"));
            Console.ReadKey();
        }

        private static Dijkstra.Graph Example()
        {

            Dijkstra.Graph graph = new Dijkstra.Graph();
            //Si potrebbe migliorare facendo aggiungere all'utente i nodi e pesi vari, ma credo possa andare benissimo così

            //Aggiungo i nodi della rete che voglio cercare
            graph.AddNode("A");
            graph.AddNode("B");
            graph.AddNode("C");
            graph.AddNode("D");
            graph.AddNode("E");
            graph.AddNode("F");
            graph.AddNode("G");
            graph.AddNode("H");

            //Aggiungo i collegamenti tra i nodi e il loro peso
            graph.AddConnection("AB", 1);
            graph.AddConnection("AC", 1);
            graph.AddConnection("AH", 2);
            graph.AddConnection("BE", 2);
            graph.AddConnection("CD", 7);
            graph.AddConnection("CF", 6);
            graph.AddConnection("DG", 3);
            graph.AddConnection("EG", 4);
            graph.AddConnection("FG", 2);
            graph.AddConnection("FH", 5);
            return graph;
        }
    }
}