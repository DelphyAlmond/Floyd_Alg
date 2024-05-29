using Timer = System.Windows.Forms.Timer;

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
        private StringFormat stringFormat = new StringFormat();
        private Font font = new Font("Arial", 12,
            FontStyle.Bold, GraphicsUnit.Point);

        private int currentK = 0;
        private int currentS = 0;
        private int currentJ = 0;
        private int n;
        private string currVertexName;
        private string currMiddleNeighbourName;
        private string endVertexName;

        private Point start;
        private Point middle;
        private Point finish;

        private int withS = 0, withE = 0;
        private int SEWeight = 0;

        public GraphicImplementationForm(Dictionary<string, Vertex> v, Dictionary<string, Point> vP)
        {
            vertices = v;
            vertexPositions = vP;

            InitializeComponent();
            AddTimer();
            InitializeGraph(vertices);

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g = scenePanel.CreateGraphics();
        }

        private void AddTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 200; // ms
            animationTimer.Tick += OnAnimationTick;
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
                    dist[i, j] = (i == j) ? 0 : 101;
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
            // animationTimer.Start();
        }

        private void OnAnimationTick(object sender, EventArgs e)
        {
            if (currentS < n)
            {
                if (currentK < n)
                {
                    currVertexName = names[currentS];
                    for (; currentJ < n; currentJ++)
                    {
                        if (dist[currentS, currentK] >= 101 && dist[currentK,
                            currentJ] >= 101 && dist[currentS, currentJ] >
                            dist[currentS, currentK] + dist[currentK, currentJ])
                        {

                            withS = dist[currentS, currentK];
                            withE = dist[currentK, currentJ];

                            dist[currentS, currentJ] = withS + withE;

                            currMiddleNeighbourName = names[currentK];
                            SEWeight = 0;
                        }
                        else
                        {
                            currMiddleNeighbourName = null;
                            SEWeight = dist[currentS, currentJ];
                        }

                        endVertexName = names[currentJ];

                        // Visualize the current step
                        HighlightVertices(currVertexName, currMiddleNeighbourName, endVertexName);

                        // return; // Wait for the next timer tick
                    }
                    currentJ = 0;
                    currentK++;
                }
                else
                {
                    currentK = 0;
                    // currentS++; only for chosen S [!]

                    // Check if the animation should stop
                    animationTimer.Stop();
                }
            }
        }

        /*
        private void OnAnimationTick(object sender, EventArgs e)
        {
            if (currentK < n)
            { // differ ----------------------- [ EDIT ]
                for (; currentS < n; currentS++)
                {
                    if (currentS == currentK)
                    {
                        return;
                    }

                    currVertexName = names[currentS];

                    for (; currentJ < n; currentJ++)
                    {
                        if (currentJ == currentS)
                        {
                            return;
                        }

                        if (dist[currentS, currentK] >= 101 && dist[currentK,
                            currentJ] >= 101 && dist[currentS, currentJ] >
                            dist[currentS, currentK] + dist[currentK, currentJ])
                        {
                            dist[currentS, currentJ] = dist[currentS, currentK]
                                + dist[currentK, currentJ];
                            currMiddleNeighbourName = names[currentK];

                            withS = dist[currentS, currentK];
                            withE = dist[currentK, currentJ];
                            SEWeight = 0;
                        }
                        else
                        {
                            currMiddleNeighbourName = null;
                            SEWeight = dist[currentS, currentJ];
                        }

                        endVertexName = names[currentJ];

                        // Visualize the current step
                        HighlightVertices(currVertexName, currMiddleNeighbourName, endVertexName);
                        return; // Wait for the next timer tick
                    }
                }

                currentK++;
            }

            // Check if the animation should stop
            animationTimer.Stop();
        }
        */

        private void OnScrollBarValueChanged(object sender, EventArgs e)
        {
            int value = scrollBarA.Value;
            // currentK = value / (n * n);
            currentS = value;

            // start animating
            animationTimer.Start();
        }

        /*
        private void OnScrollBarValueChanged(object sender, EventArgs e)
        {
            // ---------------------------------------------- [ EDIT ] !
            currentK = 0;
            currentS = scrollBarA.Value - 1;
            currentJ = 0;
            // Start the animation
            animationTimer.Start();
        }
        */

        private void HighlightVertices(string vertexName, string middleName, string endName)
        {
            g.Clear(scenePanel.BackColor); // Clear the panel
            Pen line = new Pen(Color.DeepPink, 4);

            // Draw all vertices
            foreach (var kvp in vertexPositions)
            {
                Point pos = kvp.Value;
                g.FillEllipse(Brushes.Yellow, pos.X, pos.Y, 40, 40);
            }

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

            if (SEWeight == 0)
            {
                g.DrawLine(line, start, middle);
                g.DrawLine(line, middle, finish);

                g.DrawString(((withS < 101) ? withS.ToString() : "><"),
                    font, Brushes.DeepPink, Math.Abs(middle.X + start.X) / 2,
                    Math.Abs(middle.Y + start.Y) / 2 - 20, stringFormat);

                g.DrawString(((withE < 101) ? withE.ToString() : "><"),
                    font, Brushes.DeepPink, Math.Abs(finish.X + middle.X) / 2,
                    Math.Abs(finish.Y + middle.Y) / 2 - 20, stringFormat);

                g.FillEllipse(Brushes.DeepPink, middle.X - 8, middle.Y - 8, 40, 40);
                g.DrawString(middleName, font, Brushes.White, middle.X, middle.Y - 8);
            }
            else
            {
                g.DrawLine(line, start, finish);
                g.DrawString(((SEWeight < 101) ? SEWeight.ToString() : "><"),
                    font, Brushes.Teal, Math.Abs(finish.X + start.X) / 2,
                    Math.Abs(finish.Y + start.Y) / 2 - 20, stringFormat);
            }

            g.FillEllipse(Brushes.Teal, finish.X - 8, finish.Y - 8, 40, 40);
            g.FillEllipse(Brushes.Teal, start.X - 8, start.Y - 8, 40, 40);

            g.DrawString(vertexName, font, Brushes.White, start.X, start.Y - 8);
            g.DrawString(endName, font, Brushes.White, finish.X, finish.Y - 8);
        }
    }


}

/*
 * public partial class GraphicImplementationForm : Form
    {
        private Dictionary<string, Vertex> vertices;
        private Dictionary<string, Point> vertexPositions;
        private Graphics g;
        private Timer animationTimer;
        private int[,] dist;
        private int[,] next;
        private Dictionary<string, int> vertexIndexMap;
        private string[] names;

            <...>

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
 */