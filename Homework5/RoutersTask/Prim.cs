namespace RoutesTaskSpace;

using System.Linq;
using System.Text;

/// <summary>
/// Class that contains functions to get an optimal configuration
/// for routers topology given using Prim's algorithm.
/// </summary>
public class Prim
{
    private List<Edge> edge = new();
    
    /// <summary>
    /// A list that contains edges of the found max spanning tree.
    /// </summary>
    public List<Edge> OutputEdges { get; private set; } = new();
    private List<int> MarkedVertexes { get; set; } = new();  
    private int maxVertex = -1;
    public bool Connected { get; set; }

    private void SortEdgeList(List<Edge> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i; j < list.Count; j++)
            {
                if (list[j].Length >
                    list[i].Length)
                {
                    Edge temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
    }

    private void GetEdges(string FilePath)
    {
        using var inputFile = new StreamReader(FilePath);

        var newLine = String.Empty;

        while ((newLine = inputFile.ReadLine()) != null)
        {
            int beginning = Convert.ToInt32(newLine[0].ToString());
            
            maxVertex = Math.Max(maxVertex, beginning);
            
            newLine = newLine.Remove(0, 3);
            string[] ends = newLine.Split(',');
            
            foreach (string end in ends)
            {
                var stringEndToAdd = new StringBuilder();
                int i = 0;
                
                while (end[i] != '(')
                {
                    if ( end[i] == ' ')
                    {
                        i++;
                        continue;
                    }
                    stringEndToAdd.Append(end[i]);
                    i++;
                }
                var stringLengthToAdd = new StringBuilder();
                int j = i + 1;
                
                while (end[j] != ')')
                {
                    if (end[j] == ' ')
                    {
                        j++;
                        continue;
                    }
                    stringLengthToAdd.Append(end[j]);
                    j++;
                }
                
                int endInt = Convert.ToInt32(stringEndToAdd.ToString());
                
                maxVertex = Math.Max(maxVertex, endInt);
                
                edge.Add(new Edge(beginning,
                                   endInt,
                                   Convert.ToInt32(stringLengthToAdd.ToString())));
            }
        }
    }

    /// <summary>
    /// Function that builds a max spanning tree using Prim's algorithm.
    /// </summary>
    /// <param name="FilePath"></param>
    public void BuildMaxSpanningTree(string FilePath)
    {
        GetEdges(FilePath);
        SortEdgeList(edge);
        BuildMaxSpanningTreeRecursion(edge[0]);
    }

    private void BuildMaxSpanningTreeRecursion(Edge edge)
    {
        List<Edge> EdgesWithMarkedBeginnig = new List<Edge>();
        OutputEdges.Add(edge);
        this.edge.Remove(edge);
        EdgesWithMarkedBeginnig.Remove(edge);

        int addedEdgeBeginning = edge.Beginning;
        int addedEdgeEnd = edge.End;
        if (!MarkedVertexes.Contains(addedEdgeBeginning))
        {
            MarkedVertexes.Add(addedEdgeBeginning);
        }
        if (!MarkedVertexes.Contains(addedEdgeEnd))
        {
            MarkedVertexes.Add(addedEdgeEnd);
        }

        foreach (Edge remainingEdge in this.edge) 
        {
            if  (MarkedVertexes.Contains(remainingEdge.End) ^ MarkedVertexes.Contains(remainingEdge.Beginning))
            {
                if (!MarkedVertexes.Contains(remainingEdge.End) ||
                    !MarkedVertexes.Contains(remainingEdge.Beginning))
                {
                    EdgesWithMarkedBeginnig.Add(remainingEdge);
                }
            }
        }
        SortEdgeList(EdgesWithMarkedBeginnig);
        if (EdgesWithMarkedBeginnig.Count == 0)
        {
            return;
        }
        else
        {
            BuildMaxSpanningTreeRecursion(EdgesWithMarkedBeginnig[0]);
            return;
        }
    }

    /// <summary>
    /// A function that determines whether a graph is connect. 
    /// </summary>
    public void IsConnected()
    {
        foreach (Edge edge in edge)
        {
            if (!MarkedVertexes.Contains(edge.Beginning) ||
                !MarkedVertexes.Contains(edge.End))
            {
                return;
            }
        }
        Connected = true;
    }

    /// <summary>
    /// Function that provides with an optimal configuration of the
    /// given routers topology.
    /// </summary>
    /// <param name="inputPath">Path to a file that contains a routers topology</param>
    /// <param name="outputPath">Path to a file where you want to store
    /// an optimal configuration.</param>
    public void GetConfiguration(string inputPath, string outputPath)
    {
        BuildMaxSpanningTree(inputPath);
        if (!Connected) 
        {
            Console.Error.Write("The network is not connected.");
            Environment.FailFast( String.Format("The network is not connected."));
        }

        using StreamWriter output = new StreamWriter(outputPath);
        SortEdgeList(OutputEdges);
        
        for (int i = 1; i <= 7; i++)
        {
            var outputString = new StringBuilder($"{i}: ");
            bool atLeastOne = false;
            foreach (Edge edge in OutputEdges) 
            {
                if (edge.Beginning == i)
                {
                    atLeastOne = true;
                    outputString.Append(edge.ToString());
                    outputString.Append(", ");
                }
            }
            if (atLeastOne)
            {
                outputString.Length -= 2;
                output.Write(outputString.ToString());
                output.Write('\n');
            }
        }

    }
}
