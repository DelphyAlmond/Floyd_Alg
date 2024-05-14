using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydAlg
{
    public class Graph
    {
        public Dictionary<string, Vertex> Vertices { get; private set; }

        public Graph()
        {
            Vertices = new Dictionary<string, Vertex>();
        }

        public Graph Clone()
        {
            Graph clone = new Graph();

            foreach (var vertex in Vertices.Keys)
            {
                clone.AddVertex(vertex);

                foreach (var edge in Vertices[vertex].Connections)
                {
                    clone.Vertices[vertex].AddConnection(edge.Key, edge.Value);
                }
            }

            return clone;
        }

        public void AddVertex(string name)
        {
            if (!Vertices.ContainsKey(name))
            {
                Vertices[name] = new Vertex(name); // name <-> obj of vertex
            }
        }

        public void AddEdge(string sourceName, string destinationName, int weight)
        {
            if (Vertices.ContainsKey(sourceName) && Vertices.ContainsKey(destinationName))
            {
                Vertex source = Vertices[sourceName];
                Vertex destination = Vertices[destinationName];
                source.AddConnection(destination, weight);
            }
            else
            {
                throw new ArgumentException("One or more vertices do not exist in the graph.");
            }
        }

        public void Clear()
        {
            Vertices.Clear();
        }
    }

    public class Vertex
    {
        public string Name { get; }
        public Dictionary<Vertex, int> Connections { get; }

        public Vertex(string name)
        {
            Name = name;
            Connections = new Dictionary<Vertex, int>();
        }

        public void AddConnection(Vertex neighbor, int weight)
        {
            Connections[neighbor] = weight; // obj of vertex <-> price of connection
        }
    }
}
