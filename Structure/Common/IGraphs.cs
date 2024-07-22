namespace Graph.Structure.Common;
using NodeTuple = (int indexX, int indexY, uint weight);
using Node = (int index, uint weight);

public interface IGraphs
{
    /// <summary>
    /// Creates an edge between nodes 
    /// </summary>
    /// <param name="weight">optional weight > 1 </param>
    void AddEdge(int fromNode, int toNode, uint weight = 1);
    
    /// <summary>
    /// Deletes created edges
    /// </summary>
    void DeleteEdge(int fromNode, int toNode);
    
    /// <summary>
    /// Returns information about the node with the smallest weight
    /// </summary>
    /// <returns>(indexX, indexY, weight)</returns>
    NodeTuple GetMin();
    Node[] GetAdjacent(int nodeIndex);
    int GetNodeCount { get;}
    uint? GetEdgeWeight(int fromNode, int toNode);
    bool HasEdge(int indexX, int indexY);
    
    string ToString();
}