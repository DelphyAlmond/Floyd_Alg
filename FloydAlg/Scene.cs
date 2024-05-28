using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace FloydAlg
{
    public partial class Scene : Form
    {
        // private int counter;
        private Dictionary<string, Point> vertexPositions;
        private string selectedStartVertex = null;

        private List<StateStep> steps;
        private Graph graph;
        private FloydWarshallAlg algorithmImplementation;
        int[,] currentMatrix;

        private CanvasRedraw drawTool;

        int indexOfCurrentAction = 0;

        private InformationForm form;
        private GraphicImplementationForm scene;

        private FileLoader loader;

        public Scene()
        {
            InitializeComponent();
            vertexPositions = new Dictionary<string, Point>();
            Connector.Enabled = false;

            // unable resize
            FormBorderStyle = FormBorderStyle.Fixed3D;

            // keep an eye on current graph
            graph = new Graph();
            steps = new List<StateStep>();
            drawTool = new CanvasRedraw();
            // empty beginning
            steps.Add(new StateStep("> Obj of Graph created (start)", graph, vertexPositions));
        }

        private void AddStateStep(string action)
        {
            Graph snapshot = graph.Clone();

            StateStep state = new StateStep(action, snapshot, vertexPositions);
            steps.Add(state);

            stateBox.Items.Add(state); // adds to the listBox

            indexOfCurrentAction++;
        }

        private bool MoreThanOneVertex()
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
                    drawTool.RedrawGraph(graphPanel, graph, vertexPositions);
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

                // Redraw the graph
                drawTool.RedrawGraph(graphPanel, graph, vertexPositions);

                // Enable groupBox if 2 already exist and I can connect them
                if (MoreThanOneVertex()) Connector.Enabled = true;
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

            fileWritingDown(); // writing down to file
        }

        public void DeleteVertexFromGraph(string vertexName)
        {
            graph.RemoveVertex(vertexName);
            vertexPositions.Remove(vertexName);
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

            fileWritingDown(); // writing down to file
        }

        private void btnRunAlgorithm_Click(object sender, EventArgs e)
        {
            algorithmImplementation = new FloydWarshallAlg(graph);
            currentMatrix = algorithmImplementation.SearchPath(); // recounted with 101(infinity\max)
            // represent in graphics
            DrawMatrix(currentMatrix, algorithmImplementation.elms, 40, 30);
        }

        private void DrawMatrix(int[,] mtx, int n, int w, int h) // n is size of all 2DArr
        {
            Graphics g = Matrixpanel.CreateGraphics();
            g.Clear(Color.Teal);
            Matrixpanel.Controls.Clear();

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

                    if (mtx[i, j] > 100 || mtx[i, j] == -1) newLb.Text = "~";
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
            string vertexToDelete = txtVertexName.Text.Trim();
            // Assuming txtVertexToDelete is a TextBox to enter the vertex name to delete

            if (graph.Vertices.ContainsKey(vertexToDelete)
                && vertexPositions.ContainsKey(vertexToDelete))
            {
                // Remove the vertex from the graph
                // + vertex position from the dictionary
                // + [!] from vertex connections
                DeleteVertexFromGraph(vertexToDelete);

                AddStateStep("> Vertex '" + vertexToDelete + "' was removed "); // -------- [ STATUS UPDATE ]

                // Reflect the changes
                drawTool.RedrawGraph(graphPanel, graph, vertexPositions);

                if (MoreThanOneVertex()) Connector.Enabled = true;

                fileWritingDown(); // writing down to file
            }

            else MessageBox.Show("Vertex not found in the graph.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void fileWritingDown()
        {
            // state loader :
            loader.WriteGraphToFile(graph);
            loader.SaveDataBin(graph, vertexPositions);

            loader.rememberCurrStates(steps);
        }

        private void prevState_Click(object sender, EventArgs e)
        {
            if (indexOfCurrentAction > 0)
            {
                graph = steps[--indexOfCurrentAction].getSnapshot();
                vertexPositions = steps[--indexOfCurrentAction].getVPos();
            }

            drawTool.RedrawGraph(graphPanel, graph, vertexPositions);
        }

        private void nextState_Click(object sender, EventArgs e)
        {
            if (indexOfCurrentAction < steps.Count - 1)
            {
                graph = steps[++indexOfCurrentAction].getSnapshot();
                vertexPositions = steps[++indexOfCurrentAction].getVPos();
            }

            drawTool.RedrawGraph(graphPanel, graph, vertexPositions);
        }

        private void InfButton_Click(object sender, EventArgs e)
        {
            form = new InformationForm();
            form.Show();
        }

        private void btnShortestBetween_Click(object sender, EventArgs e) // [highlight added]
        {
            drawTool.RedrawGraph(graphPanel, graph, vertexPositions);
            // algorithmImplementation = new FloydWarshallAlg(graph);
            if ((VertexFromBox.Text != null && VertexToBox.Text != null) &&
                (VertexFromBox.Text != VertexToBox.Text) &&
                graph.Vertices.ContainsKey(VertexFromBox.Text) &&
                graph.Vertices.ContainsKey(VertexToBox.Text))
            {
                int shEdge = algorithmImplementation.GetShortestDistance(VertexFromBox.Text, VertexToBox.Text);
                ShortestEdgeLabel.Text = shEdge.ToString();

                List<String> pathBetween = algorithmImplementation.GetShortestPath(VertexFromBox.Text, VertexToBox.Text);
                drawTool.drawVertexPath(graphPanel, vertexPositions, pathBetween);
            }
            else MessageBox.Show("Check if textBoxes are filled with existing DIFFERENT vertecies.",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNextMtxStep_Click(object sender, EventArgs e)
        {
            scene = new GraphicImplementationForm(graph.Vertices, vertexPositions);
            // algorithmImplementation.firstFill
            scene.Show();
        }

        /* choosing in ListBox [?]
        private void stateBox_SelectedIndexChanged(object sender, EventArgs e)
        */

        private void btnPrevSLoadFromFile(object sender, EventArgs e)
        {
            graph = loader.LoadDataBin();
            vertexPositions = loader.getPos();
            steps = loader.LoadFromFile("Loaded states\\StatesOfGraphJson.json");

            foreach (var step in steps)
            {
                AddStateStep(step.Action);
            }

            drawTool.RedrawGraph(graphPanel, graph, vertexPositions);
        }
    }
}

