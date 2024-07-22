using Graph.Structure.Common;

namespace Graph.Structure;

// późno, ale przyznaję weight jako uint to głupi pomysł był
public class Builder {
    public GraphRepresentations.AdjacencyList ConsistentGraphAsList(int numberOfNodes, int numberOfEdges) {
        if (numberOfEdges < numberOfNodes/2) throw new Exception("<Placeholder message>");
        var graph = new GraphRepresentations.AdjacencyList(numberOfNodes);
        Generate(graph,numberOfEdges);
        return graph;
    }
    public GraphRepresentations.AdjacencyMatrix ConsistentGraphAsMatrix(int numberOfNodes, int numberOfEdges) {
        if (numberOfEdges < numberOfNodes/2) throw new Exception("<Placeholder message>");
        var graph = new GraphRepresentations.AdjacencyMatrix(numberOfNodes);
        Generate(graph,numberOfEdges);
        return graph;
    }
    private void Generate(IGraphs graph, int numberOfEdges) {
        var rand = new Random();
        var numberOfNodes = graph.GetNodeCount;
        for (int i = 0; i < numberOfNodes; i++)
        {
            graph.AddEdge(i,(i+1)%numberOfNodes,(uint)rand.Next(1,400));
        }
        for (int i= 0; i < numberOfEdges - numberOfNodes; i++) //źle, coś innego wymyślę
        {
            graph.AddEdge(i,rand.Next(0,numberOfNodes), (uint)rand.Next(1,400));
        }
    } 
}