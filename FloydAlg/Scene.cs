using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloydAlg // ili kak ghe ya zaebalas
{
    public partial class Scene : Form
    {
        // private int counter;
        private Dictionary<string, Point> vertexPositions;
        private string selectedStartVertex = null;

        private List<StateStep> steps;
        private Graph graph;

        int IndexOfCurrentAction = 0;

        InformationForm form;

        public Scene()
        {
            InitializeComponent();
            vertexPositions = new Dictionary<string, Point>();
            Connector.Enabled = false;
            // keep an eye on current graph
            graph = new Graph();
            steps = new List<StateStep>();
            // empty beginning
            steps.Add(new StateStep("> Obj of Graph created (start)", graph));
        }

        private void AddStateStep(string action)
        {
            Graph snapshot = graph.Clone();

            StateStep state = new StateStep(action, snapshot);
            steps.Add(state);

            stateBox.Items.Add(state); // adds to the listBox
            IndexOfCurrentAction++;
        }

        private bool moreThanOneVertex()
        {
            return graph.Vertices.Count > 1;
        }

        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            string vertexName = txtVertexName.Text.Trim();

            // Check if vertexName is empty ( !!! only proceed if startV and destinationV are filled)
            if (string.IsNullOrEmpty(vertexName))
            {

                string startVertexName = startV.Text.Trim();
                string destinationVertexName = destinationV.Text.Trim();

                if (string.IsNullOrEmpty(startVertexName) || string.IsNullOrEmpty(destinationVertexName))
                {
                    MessageBox.Show("Please select start and destination vertices.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if startV and destinationV contain valid vertex names
                if (graph.Vertices.ContainsKey(startVertexName) && graph.Vertices.ContainsKey(destinationVertexName))
                {
                    // Add the connection between existing vertices
                    int weight = (int)numConnectionWeight.Value;
                    graph.AddEdge(startVertexName, destinationVertexName, weight);

                    AddStateStep("> Connection between '" + startVertexName + "' & '" + destinationVertexName + "' created");
                    // ------------------------ [ STATUS UPDATE ]

                    // Redraw the graph
                    RedrawGraph();
                }

                else MessageBox.Show("One or more selected vertices do not exist in the graph.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (!string.IsNullOrEmpty(vertexName)) // Add a new vertex
            {
                if (graph.Vertices.ContainsKey(vertexName))
                {
                    MessageBox.Show("Vertex name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddVertexToGraph(vertexName);

                AddStateStep("> New vertex '" + vertexName + "' added"); // ------------------------ [ STATUS UPDATE ]

                // Enable groupBox if 2 already exist and I can connect them
                if (moreThanOneVertex()) Connector.Enabled = true;
            }
            else MessageBox.Show("Please enter a valid vertex name or select existing vertices.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            txtVertexName.Text = ""; // to not conflict with two other textBoxes
        }

        private void AddVertexToGraph(string vertexName)
        {
            // Add vertex to the graph
            graph.AddVertex(vertexName);

            // Generate random position for the vertex
            Random rnd = new Random();
            int x = rnd.Next(graphPanel.Width - 40) + 20;
            int y = rnd.Next(graphPanel.Height - 40) + 20;
            Point position = new Point(x, y);

            // Store vertex position
            vertexPositions[vertexName] = position;

            // Redraw the graph
            RedrawGraph();
        }

        private void RedrawGraph()
        {
            using (Graphics g = graphPanel.CreateGraphics())
            {
                g.Clear(Color.White);

                // Draw vertices
                foreach (var entry in vertexPositions)
                {
                    string vertexName = entry.Key;
                    Point center = entry.Value;
                    g.FillEllipse(Brushes.DeepPink, center.X - 20, center.Y - 20, 40, 40); // Color of circules
                    g.DrawString(vertexName, Font, Brushes.White, center.X - 12, center.Y - 18);
                }

                // Draw connections
                foreach (var vertex in graph.Vertices.Values)
                {
                    if (vertexPositions.ContainsKey(vertex.Name))
                    {
                        Point sourceCenter = vertexPositions[vertex.Name];

                        foreach (var neighbor in vertex.Connections)
                        {
                            if (vertexPositions.ContainsKey(neighbor.Key.Name))
                            {
                                Point destinationCenter = vertexPositions[neighbor.Key.Name];

                                // int x_weight = 0, y_weight = 0;

                                // [ EDIT ] --------------------- Arrows
                                if (sourceCenter.X > destinationCenter.X)
                                {
                                    destinationCenter.X += 5;
                                    sourceCenter.X -= 5;
                                }
                                else
                                {
                                    destinationCenter.X -= 6;
                                    sourceCenter.X += 6;
                                }

                                if (sourceCenter.Y > destinationCenter.Y)
                                {
                                    destinationCenter.Y += 8;
                                    sourceCenter.Y -= 8;
                                }
                                else
                                {
                                    destinationCenter.Y -= 10;
                                    sourceCenter.Y += 10;
                                }

                                DrawArrow(g, sourceCenter, destinationCenter);
                                g.DrawString(neighbor.Value.ToString(), Font, Brushes.Teal, 
                                    Math.Abs(destinationCenter.X - sourceCenter.X), 
                                    Math.Abs(destinationCenter.Y - sourceCenter.X));
                            }
                        }
                    }
                }
            }
        }

        private void DrawArrow(Graphics g, Point source, Point destination)
        {
            Pen line = new Pen(Color.Teal, 3);
            g.DrawLine(line, source, destination);

            // Calculate arrowhead points and angle of them ETC. --------------- [ EDIT ]
            double angle = Math.Atan2(destination.Y - source.Y, destination.X - source.X);

            Point arrowSide1 = new Point(
                (int)(destination.X - 25 * Math.Cos(angle - Math.PI / 9)),
                (int)(destination.Y - 25 * Math.Sin(angle - Math.PI / 9)));
            Point arrowSide2 = new Point(
                (int)(destination.X - 25 * Math.Cos(angle + Math.PI / 9)),
                (int)(destination.Y - 25 * Math.Sin(angle + Math.PI / 9)));

            // Draw arrowhead
            g.DrawLine(line, destination, arrowSide1);
            g.DrawLine(line, destination, arrowSide2);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedStartVertex = null;
            vertexPositions.Clear();
            graph.Clear(); // clear all verticies

            // Matrixpanel.Hide();
            int[,] empty = new int[0, 0];
            DrawMatrix(empty, 0, 0, 0);

            stateBox.Items.Clear();
            AddStateStep("> Everything was removed ");

            graphPanel.Refresh(); // Clear the graph panel
        }

        private void btnRunAlgorithm_Click(object sender, EventArgs e)
        {
            FloydWarshallAlg alg = new FloydWarshallAlg(graph);
            int[,] currentMatrix = alg.currentFill;
            int cnt = alg.elms;
            // represent in graphics
            //  ( Label[,] numbers = new Label[cnt, cnt]; )
            int lbW = 40;
            int lbH = 30;

            DrawMatrix(currentMatrix, cnt, lbW, lbH);

            alg.SearchPath(); // recounted with 101(infinity\max)
            currentMatrix = alg.currentFill;

            // DrawMatrix(currentMatrix, cnt, lbW, lbH);
        }

        private void DrawMatrix(int[,] mtx, int n, int w, int h)
        {
            Graphics g = Matrixpanel.CreateGraphics();

            if (mtx.Length == 0 && n == 0 && w == 0 && h == 0)
            {
                Matrixpanel.Controls.Clear();
                g.Clear(Color.Teal);
                return;
            }

            // space between, tiles bounds
            Padding padding = new Padding(10);
            // set names for vertexes
            int cw = 0;
            foreach (var corteg in vertexPositions)
            {
                g.DrawString(corteg.Key, Font, Brushes.White, cw += w + 5, 5);
            }

            int spaceForLetters = 40;

            for (int i = 0; i < n; i++)
            {
                g.DrawString(vertexPositions.ElementAt(i).Key, Font,
                    Brushes.White, padding.Left, i * (h + padding.Top) + spaceForLetters);

                for (int j = 0; j < n; j++)
                {
                    Label newLb = new Label();

                    if (mtx[i, j] > 100) newLb.Text = "~";
                    else newLb.Text = mtx[i, j].ToString();

                    newLb.ForeColor = Color.White;
                    newLb.Size = new Size(w, h);
                    newLb.Location = new Point(j * (w + padding.Left) + spaceForLetters,
                                               i * (h + padding.Top) + spaceForLetters);
                    // add to panel
                    Matrixpanel.Controls.Add(newLb);
                    // nums[i, j] = newLb;
                }
            }
        }

        private void txtStartVertex_TextChanged(object sender, EventArgs e)
        {
            selectedStartVertex = startV.Text.Trim();
        }

        private void txtDestinationVertex_TextChanged(object sender, EventArgs e)
        {
            // Ensure the destination vertex is not the same as the start vertex
            if (destinationV.Text.Trim() == selectedStartVertex)
            {
                destinationV.Text = ""; // Clear the destination vertex
                MessageBox.Show("Destination vertex cannot be the same as start vertex.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveVertex_Click(object sender, EventArgs e)
        {
            string vertexToDelete = txtVertexName.Text.Trim(); // Assuming txtVertexToDelete is a TextBox to enter the vertex name to delete

            if (graph.Vertices.ContainsKey(vertexToDelete))
            {
                // Remove the vertex from the graph
                graph.Vertices.Remove(vertexToDelete);

                // Remove the vertex position from the dictionary
                if (vertexPositions.ContainsKey(vertexToDelete))
                {
                    vertexPositions.Remove(vertexToDelete);
                }

                AddStateStep("> Vertex '" + vertexToDelete + "' was removed ");

                // Redraw the graph to reflect the changes
                RedrawGraph();

                // Update UI based on the graph state
                if (moreThanOneVertex()) Connector.Enabled = true;
            }

            else
            {
                MessageBox.Show("Vertex not found in the graph.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void prevState_Click(object sender, EventArgs e)
        {
            if (IndexOfCurrentAction > 0) graph = steps[--IndexOfCurrentAction].GraphSnapshot;
            RedrawGraph();
        }

        private void nextState_Click(object sender, EventArgs e)
        {
            if (IndexOfCurrentAction < steps.Count - 1) graph = steps[++IndexOfCurrentAction].GraphSnapshot;
            RedrawGraph();
        }

        private void InfButton_Click(object sender, EventArgs e)
        {
            form = new InformationForm();
            form.Show();
            // form.Activate();
            // if (form.ShowDialog() == DialogResult.Cancel) return;
        }
    }
}

