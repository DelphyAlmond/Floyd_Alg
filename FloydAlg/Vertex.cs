using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydAlg
{
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
