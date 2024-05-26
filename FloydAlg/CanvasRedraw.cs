using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydAlg
{
    public class CanvasRedraw
    {
        public void RedrawGraph(Panel graphPanel, Graph graph, Dictionary<String, Point> vertexPositions)
        {
            Graphics g = graphPanel.CreateGraphics();
            g.Clear(Color.White);

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

                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Center;
                            stringFormat.LineAlignment = StringAlignment.Center;

                            DrawArrow(g, sourceCenter, destinationCenter, 0);

                            // number : weight of the edge next to it (center of line)
                            g.DrawString(neighbor.Value.ToString(), new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point),
                                Brushes.Teal,
                                Math.Abs(destinationCenter.X + sourceCenter.X) / 2,
                                Math.Abs(destinationCenter.Y + sourceCenter.Y) / 2 - 20, stringFormat);
                        }
                    }
                }
            }

            // Draw vertices
            foreach (var entry in vertexPositions)
            {
                string vertexName = entry.Key;
                Point Vcenter = entry.Value;
                stringInEllipse(g, 0, vertexName, Vcenter);
            }
        }

        private void stringInEllipse(Graphics g, int color, String name, Point center)
        {
            // Color of circules - changes, depending on path purpose [!]
            if (color == 0)
            {
                g.FillEllipse(Brushes.DeepPink, center.X - 20, center.Y - 20, 40, 40);
                g.DrawString(name, new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point),
                Brushes.White, center.X - 16, center.Y - 18);
            }
            else
            {
                g.FillEllipse(Brushes.Yellow, center.X - 20, center.Y - 20, 40, 40);
                g.DrawString(name, new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point),
                Brushes.Teal, center.X - 16, center.Y - 18);
            }
        }

        private void DrawArrow(Graphics g, Point source, Point destination, int color)
        {
            Pen line = new Pen(Color.DeepPink, 4);
            if (color == 0)
            {
                line = new Pen(Color.Teal, 4);
            }

            // Draw arrowhead
            // line.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            line.CustomEndCap = new AdjustableArrowCap(3.0f, 8.0f);

            g.DrawLine(line, source, destination);
        }

        public void drawVertexPath(Panel gPanel, Dictionary<String, Point> vertexPositions, List<String> vertexNames)
        {
            Graphics g = gPanel.CreateGraphics();

            for (int i = 0; i < vertexNames.Count - 1; i++)
            {
                if (vertexPositions.ContainsKey(vertexNames[i]) && vertexPositions.ContainsKey(vertexNames[i + 1]))
                {
                    Point sourceCenter = vertexPositions[vertexNames[i]];
                    Point destinationCenter = vertexPositions[vertexNames[i + 1]];

                    DrawArrow(g, sourceCenter, destinationCenter, 1);

                    stringInEllipse(g, 1, vertexNames[i], sourceCenter);
                    stringInEllipse(g, 1, vertexNames[i + 1], destinationCenter);
                }
            }
        }

    }
}
