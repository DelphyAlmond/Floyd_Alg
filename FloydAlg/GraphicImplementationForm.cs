using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Xml.Linq;

namespace FloydAlg
{
    public partial class GraphicImplementationForm : Form
    {
        private Dictionary<string, Vertex> vertices;
        private Dictionary<string, Point> vertexPositions;
        private Graphics g;
        private Timer animationTimer;
        private int[,] dist;
        private int[,] next;
        private Dictionary<string, int> vertexIndexMap;
        private string[] names;
        private int currentK = 0;
        private int currentS = 0;
        private int currentJ = 0;
        private int n;
        private string currVertexName;
        private string currMiddleNeighbourName;
        private string endVertexName;

        public GraphicImplementationForm(Dictionary<string, Vertex> v, Dictionary<string, Point> vP)
        {
            vertices = v;
            vertexPositions = vP;

            InitializeComponent();
            AddTimer();
            InitializeGraph(vertices);

            g = scenePanel.CreateGraphics();
        }

        private void AddTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 200; // ms
            animationTimer.Tick += OnAnimationTick;
            // animationTimer.Tick += new EventHandler(OnAnimationTick);
        }

        private void InitializeGraph(Dictionary<string, Vertex> vertices)
        {
            vertexIndexMap = new Dictionary<string, int>();
            int index = 0;
            foreach (var vertexName in vertices.Keys)
            {
                vertexIndexMap[vertexName] = index++;
            }

            n = vertices.Count;
            names = vertexIndexMap.Keys.ToArray();
            dist = new int[n, n];
            next = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dist[i, j] = (i == j) ? 0 : int.MaxValue;
                    next[i, j] = -1;
                }
            }

            foreach (var startVertexName in vertices.Keys)
            {
                var startVertex = vertices[startVertexName];
                int startIndex = vertexIndexMap[startVertexName];

                foreach (var endVertex in startVertex.Connections.Keys)
                {
                    int endIndex = vertexIndexMap[endVertex.Name];
                    int weight = startVertex.Connections[endVertex];
                    dist[startIndex, endIndex] = weight;
                    next[startIndex, endIndex] = endIndex;
                }
            }

            // Start the animation
            animationTimer.Start();
        }

        private void OnAnimationTick(object sender, EventArgs e)
        {
            if (currentK < n)
            {
                if (currentS < n)
                {
                    currVertexName = names[currentS];
                    for (; currentJ < n; currentJ++)
                    {
                        if (dist[currentS, currentK] >= 101 && dist[currentK,
                            currentJ] >= 101 && dist[currentS, currentJ] >
                            dist[currentS, currentK] + dist[currentK, currentJ])
                        {
                            dist[currentS, currentJ] = dist[currentS, currentK]
                                + dist[currentK, currentJ];
                            currMiddleNeighbourName = names[currentK];
                        }
                        else currMiddleNeighbourName = null;

                        endVertexName = names[currentJ];

                        // Visualize the current step
                        HighlightVertices(currVertexName, currMiddleNeighbourName, endVertexName);
                        scrollBarA.Value = currentK * n * n + currentS * n + currentJ;
                        return; // Wait for the next timer tick
                    }
                    currentJ = 0;
                    currentS++;
                }
                else
                {
                    currentS = 0;
                    currentK++;
                }
            }
            else
            {
                // Check if the animation should stop
                animationTimer.Stop();
            }
        }

        private void OnScrollBarValueChanged(object sender, EventArgs e)
        {
            int value = scrollBarA.Value;
            currentK = value / (n * n);
            value %= (n * n);
            currentS = value / n;
            currentJ = value % n;
        }

        private void HighlightVertices(string vertexName, string middleName, string endName)
        {
            g.Clear(scenePanel.BackColor); // Clear the panel
            Pen line = new Pen(Color.DeepPink, 4);
            Point start = new Point(0, 0);
            Point middle = new Point(0, 0);
            Point finish = new Point(0, 0);

            // Draw all vertices
            foreach (var kvp in vertexPositions)
            {
                Point pos = kvp.Value;
                g.FillEllipse(Brushes.Yellow, pos.X, pos.Y, 40, 40);
                g.DrawString(kvp.Key, new Font("Arial", 12, FontStyle.Bold,
                GraphicsUnit.Point), Brushes.Teal, start.X - 16, start.Y - 18);
            }
            // ( - )
            // Highlight the current vertex
            if (vertexName != null && vertexPositions.ContainsKey(vertexName))
            {
                start = vertexPositions[vertexName];
            }

            // Highlight the middle neighbor vertex
            if (middleName != null && vertexPositions.ContainsKey(middleName))
            {
                middle = vertexPositions[middleName];
            }

            // Highlight the end vertex
            if (endName != null && vertexPositions.ContainsKey(endName))
            {
                finish = vertexPositions[endName];
            }

            if (middleName != null)
            {
                g.DrawLine(line, start, middle);
                g.DrawLine(line, middle, finish);
                g.FillEllipse(Brushes.DeepPink, middle.X - 8, middle.Y - 8, 40, 40);
                g.DrawString(middleName, new Font("Arial", 12, FontStyle.Bold,
                GraphicsUnit.Point), Brushes.White, middle.X - 16, middle.Y - 18);
            }
            else g.DrawLine(line, start, finish);

            g.FillEllipse(Brushes.Teal, finish.X - 8, finish.Y - 8, 40, 40);
            g.FillEllipse(Brushes.Teal, start.X - 8, start.Y - 8, 40, 40);
            
            g.DrawString(vertexName, new Font("Arial", 12, FontStyle.Bold,
                GraphicsUnit.Point), Brushes.White, start.X - 16, start.Y - 18);
            g.DrawString(endName, new Font("Arial", 12, FontStyle.Bold,
                GraphicsUnit.Point), Brushes.White, finish.X - 16, finish.Y - 18);
        }
    }
}
