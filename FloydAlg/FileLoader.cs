using FloydAlg;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

public class FileLoader
{
    private List<StateStep> states;
    private Dictionary<string, Point> lastSessionPositions = new Dictionary<string, Point>();
    // private int chosenIndex;
    private string filePath = "C:\\Users\\inna\\source\\repos\\FloydAlg\\FloydAlg\\Loaded states\\StatesOfGraphJson.json";
    private string binFile = "C:\\Users\\inna\\source\\repos\\FloydAlg\\FloydAlg\\Loaded states\\GraphData.bin";

    public Dictionary<string, Point> getPos()
    {
        return lastSessionPositions;
    }

    public void rememberCurrStates(List<StateStep> sts)
    {
        states = sts;
        SaveToFile();
    }

    public void WriteGraphToFile(Graph graph)
    {
        string fileN = "C:\\Users\\inna\\source\\repos\\FloydAlg\\FloydAlg\\Loaded states\\StatesOfGraphMyFormat.txt";

        // Use StreamWriter to append to the file
        using (StreamWriter sw = new StreamWriter(fileN, true))
        {
            // Start of graph notation
            sw.Write("\n{");

            foreach (var vertex in graph.Vertices)
            {
                sw.Write($"[{vertex.Key} : (");

                bool firstConnection = true;
                foreach (var connection in vertex.Value.Connections)
                {
                    if (!firstConnection)
                    {
                        sw.Write(", ");
                    }

                    sw.Write($"'{connection.Key.Name}' : {connection.Value}");
                    firstConnection = false;
                }

                sw.Write(")]");

                // between vertices, but not after the last one
                if (!vertex.Equals(graph.Vertices.Last()))
                {
                    sw.Write(" , ");
                }
            }

            // End of graph notation
            sw.Write(" }\n");
            sw.WriteLine(); // Newline for the next graph state
        }
    }

    //           > stateSteps.getSnapshot(), > algorithmImplementation.firstFill
    public void SaveDataBin(Graph graph, Dictionary<string, Point> positions)
    {

        if (File.Exists(binFile))
        {
            File.Delete(binFile);
        }

        using (BinaryWriter writer = new BinaryWriter(File.Open(binFile, FileMode.Append)))
        {
            // Write the number of vertices
            writer.Write(graph.Vertices.Count);

            // Write positions (x, y) for each vertex
            foreach (var pair in positions)
            {
                writer.Write(pair.Key);
                writer.Write(pair.Value.X);
                writer.Write(pair.Value.Y);
            }

            // Write vertex data
            foreach (var vertex in graph.Vertices)
            {
                writer.Write(vertex.Key);
                writer.Write(vertex.Value.Connections.Count);
                foreach (var connection in vertex.Value.Connections)
                {
                    writer.Write(connection.Key.Name);
                    writer.Write(connection.Value);
                }
            }

            // Write distance matrix
            /*
            int n = distances.GetLength(0);
            writer.Write(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    writer.Write(distances[i, j]);
                }
            }
            */
        }
    }

    public Graph LoadDataBin()
    {
        Dictionary<string, Vertex> vertices = new Dictionary<string, Vertex>();
        // Dictionary<string, Point> positions = new Dictionary<string, Point>();
        Graph readenGraph = new Graph();
        // int[,] distances;

        using (BinaryReader reader = new BinaryReader(File.Open(binFile, FileMode.Open)))
        {
            // Read the number of vertices
            int vertexCount = reader.ReadInt32();

            // Read positions from
            for (int i = 0; i < vertexCount; i++)
            {
                string vertexName = reader.ReadString();
                int x = reader.ReadInt32();
                int y = reader.ReadInt32();
                lastSessionPositions[vertexName] = new Point(x, y);
            }

            // Read vertex data
            for (int i = 0; i < vertexCount; i++)
            {
                string vertexName = reader.ReadString();
                Vertex vertex = new Vertex(vertexName);
                int connectionCount = reader.ReadInt32();
                for (int j = 0; j < connectionCount; j++)
                {
                    string connectionName = reader.ReadString();
                    int weight = reader.ReadInt32();
                    Vertex connectionVertex = new Vertex(connectionName);
                    vertex.Connections[connectionVertex] = weight;
                }
                vertices[vertexName] = vertex;
            }
        }

        readenGraph.setVertices(vertices);
        return readenGraph;
    }

    public bool SaveToFile()
    {
        try
        {
            string extension = Path.GetExtension(filePath).ToLower();
            if (extension == ".json")
            {
                // save to JSON
                string json = JsonSerializer.Serialize(states);
                File.WriteAllText(filePath, json);
            }
            else
            {
                // exception
                Console.WriteLine("Unsupported file extension");
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
            return false;
        }
    }

    public List<StateStep> LoadFromFile()
    {
        try
        {
            string extension = Path.GetExtension(filePath).ToLower();
            if (extension == ".json")
            {
                // from JSON
                string json = File.ReadAllText(filePath);
                states = JsonSerializer.Deserialize<List<StateStep>>(json);
                return states;
            }
            else
            {
                // unsupported [!]
                Console.WriteLine("Unsupported file extension");
                return states;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
            return null;
        }
    }
}
