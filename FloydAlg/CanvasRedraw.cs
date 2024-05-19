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
        public static void RedrawGraph(Panel graphPanel, Graph graph, Dictionary<String, Point> vertexPositions)
        {
            using (Graphics g = graphPanel.CreateGraphics())
            {
                g.Clear(Color.White);
                Font font = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);

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
                                /*
                                // [ EDIT ] ------------------------- [?]
                                if (sourceCenter.X > destinationCenter.X)
                                {
                                    destinationCenter.X += 2;
                                    sourceCenter.X -= 2;
                                }
                                else
                                {
                                    destinationCenter.X -= 2;
                                    sourceCenter.X += 2;
                                }

                                if (sourceCenter.Y > destinationCenter.Y)
                                {
                                    destinationCenter.Y += 2;
                                    sourceCenter.Y -= 2;
                                }
                                else
                                {
                                    destinationCenter.Y -= 2;
                                    sourceCenter.Y += 2;
                                }
                                */

                                StringFormat stringFormat = new StringFormat();
                                stringFormat.Alignment = StringAlignment.Center;
                                stringFormat.LineAlignment = StringAlignment.Center;

                                DrawArrow(g, sourceCenter, destinationCenter);

                                // number : weight of the edge next to it
                                g.DrawString(neighbor.Value.ToString(), font, Brushes.Teal,
                                    Math.Abs(destinationCenter.X - sourceCenter.X) / 2,
                                    Math.Abs(destinationCenter.Y - sourceCenter.Y) / 2, stringFormat);
                            }
                        }
                    }
                }

                // Draw vertices
                foreach (var entry in vertexPositions)
                {
                    string vertexName = entry.Key;
                    Point center = entry.Value;
                    g.FillEllipse(Brushes.DeepPink, center.X - 20, center.Y - 20, 40, 40); // Color of circules
                    g.DrawString(vertexName, font, Brushes.White, center.X - 16, center.Y - 18);
                }
            }
        }

        private static void DrawArrow(Graphics g, Point source, Point destination)
        {
            Pen line = new Pen(Color.Teal, 4);

            // Draw arrowhead
            // line.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            line.CustomEndCap = new AdjustableArrowCap(3.0f, 8.0f);

            g.DrawLine(line, source, destination);
        }

    }
}
