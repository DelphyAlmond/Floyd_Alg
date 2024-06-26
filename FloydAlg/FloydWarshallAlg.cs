﻿using System;
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
        public int[,] currentFill;
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

            int n = graph.Vertices.Count;
            dist = new int[n, n];
            next = new int[n, n];
            elms = n;

            // Initialize distance and next arrays
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
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
                    int endIndex = vertexIndexMap[endVertex.Name];
                    int weight = startVertex.Connections[endVertex];
                    dist[startIndex, endIndex] = weight;
                    next[startIndex, endIndex] = endIndex;
                }
            }

            currentFill = dist;
        }

        /* For using in Scene */
        public void SearchPath()
        {
            int n = dist.GetLength(0);

            // Floyd-Warshall algorithm :

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[i, k] != 101 && dist[k, j] != 101 &&
                            dist[i, j] > dist[i, k] + dist[k, j]) {

                            dist[i, j] = dist[i, k] + dist[k, j];
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }

            currentFill = dist;
        }

        /* Use after second step of recounting [ !!! ]     -----   [!] add functions and buttons to
         * the form, printing next steps of recounting matrix
        public int GetShortestDistance(string start, string end)
        {
            if (vertexIndexMap.ContainsKey(start) && vertexIndexMap.ContainsKey(end))
            {
                int startIndex = vertexIndexMap[start];
                int endIndex = vertexIndexMap[end];
                return dist[startIndex, endIndex];
            }
            else
            {
                // Return - if vertices are not found (change to 101 [?])
                return -1;
            }
        }
        */

        /* No use with the dict [?]
        public List<string> GetShortestPath(string start, string end, Graph gr)
        {
            List<string> path = new List<string>();

            if (vertexIndexMap.ContainsKey(start) && vertexIndexMap.ContainsKey(end))
            {
                int startIndex = vertexIndexMap[start];
                int endIndex = vertexIndexMap[end];

                if (next[startIndex, endIndex] == -1)
                {
                    // No path exists
                    return path;
                }

                // Reconstruct shortest path using next array
                int current = startIndex;
                while (current != endIndex)
                {
                    path.Add("");
                    current = next[current, endIndex];
                }
                path.Add(end);
            }

            return path;
        }
        */
    }
}
