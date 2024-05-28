using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydAlg
{
    public class FloydWarshallAlg
    {
        private Dictionary<string, int> vertexIndexMap;
        private int[,] dist;
        private int[,] next;
        public int[,] firstFill;
        public int elms = 0;

        public FloydWarshallAlg(Graph graph)
        {
            Implement(graph);
        }

        private void Implement(Graph graph)
        {
            // Create a mapping from vertex names to {0, 1, 2, 3, ...}
            vertexIndexMap = new Dictionary<string, int>();
            int index = 0;
            foreach (var vertexName in graph.Vertices.Keys)
            {
                vertexIndexMap[vertexName] = index;
                index++;
            }

            elms = graph.Vertices.Count;
            dist = new int[elms, elms];
            next = new int[elms, elms];

            // Initialize distance and next arrays
            for (int i = 0; i < elms; i++)
            {
                for (int j = 0; j < elms; j++)
                {
                    dist[i, j] = (i == j) ? 0 : 101;
                    // according to NumericUpDown -> 1 - 100(max)
                    next[i, j] = -1;
                }
            }

            // Fill distance array
            // based on graph(obj of current Graph in Scene) connections
            foreach (var startVertexName in graph.Vertices.Keys)
            {
                var startVertex = graph.Vertices[startVertexName];
                int startIndex = vertexIndexMap[startVertexName];

                foreach (var endVertex in startVertex.Connections.Keys)
                {
                    int endIndex = vertexIndexMap[endVertex.Name]; // remove unabled vertex connections in scene [!]
                    int weight = startVertex.Connections[endVertex];
                    dist[startIndex, endIndex] = weight;
                    next[startIndex, endIndex] = endIndex;
                }
            }

            firstFill = dist;
        }

        /* For using in Scene */
        public int[,] SearchPath()
        {
            // Floyd-Warshall algorithm :
            for (int k = 0; k < elms; k++)
            {
                for (int i = 0; i < elms; i++)
                {
                    for (int j = 0; j < elms; j++)
                    {
                        if (dist[i, k] != 101 && dist[k, j] != 101 &&
                            dist[i, j] > dist[i, k] + dist[k, j]) {

                            dist[i, j] = dist[i, k] + dist[k, j];
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }

            return dist;
        }

        public int[,] GetIndexAlgStep()
        {
            return next;
        }

        public int GetShortestDistance(string start, string end)
        {
            if (vertexIndexMap.ContainsKey(start) && vertexIndexMap.ContainsKey(end))
            {
                int startIndex = vertexIndexMap[start];
                int endIndex = vertexIndexMap[end];
                return dist[startIndex, endIndex];
            }
            else // Vertices are not found
            {
                return -1;
            }
        }

        /* reassamble (make sure current information states) */
        public List<string> GetShortestPath(string start, string end)
        {
            List<string> path = new List<string>();

            if (vertexIndexMap.ContainsKey(start) && vertexIndexMap.ContainsKey(end))
            {
                int startIndex = vertexIndexMap[start];
                int endIndex = vertexIndexMap[end];
                if (next[startIndex, endIndex] == -1)
                {
                    // No path exists
                    return null;
                }

                List<string> keys = vertexIndexMap.Keys.ToList();

                // Reconstruct shortest path using next array
                int current = startIndex;
                while (current != endIndex)
                {
                    path.Add(keys[current]);
                    current = next[current, endIndex];
                }
                path.Add(end);
            }

            return path;
        }
    }
}
