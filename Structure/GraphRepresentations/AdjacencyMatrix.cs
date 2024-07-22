using System.Runtime.InteropServices;
using Graph.Structure.Common;
using NodeTuple = (int indexX, int indexY, uint weight);
using Node = (int index, uint weight);

namespace Graph.Structure.GraphRepresentations;


public class AdjacencyMatrix (int size): IGraphs {
    private readonly uint[,] _graphAdjacencyMatrix = new uint[size, size];

    public void AddEdge(int fromNode, int toNode, uint weight = 1) {
        if (!HasEdge(toNode,fromNode)) _graphAdjacencyMatrix[toNode, fromNode] = weight;
    }

    public void DeleteEdge(int fromNode, int toNode) => _graphAdjacencyMatrix[toNode, fromNode] = 0;

    public NodeTuple GetMin() {
        uint minValue = 1000;
        (int, int, uint) tuple = (0, 0, 0);
        for (int i = 0; i < GetNodeCount; i++)
        {
            var value = GetAdjacent(i);
            if (value.Length == 0) continue;
            if (value[0].weight >= minValue) continue;
            minValue = value[0].weight;
            tuple = (i, value[0].index, value[0].weight);
        }
        return tuple;
    }

    public Node[] GetAdjacent(int nodeIndex) {
        var adjacent = Enumerable.Range(0, _graphAdjacencyMatrix.GetLength(1))
            .Select(x => new Node (x, _graphAdjacencyMatrix[nodeIndex, x]))
            .Where(x => x.weight >= 1)
            .ToList();
        CollectionsMarshal.AsSpan(adjacent).Sort((x,y)=> x.weight.CompareTo(y.weight));
        return adjacent.ToArray();
    }
    public int GetNodeCount => _graphAdjacencyMatrix.GetLength(0);
    
    public uint? GetEdgeWeight(int fromNode, int toNode) {
        return _graphAdjacencyMatrix[toNode, fromNode];
    }
    public bool HasEdge(int indexX, int indexY) => _graphAdjacencyMatrix[indexX, indexY] != 0;
    public override string ToString()
    {
        var str = "";
        
        for (var i = 0; i < GetNodeCount; i++)
        {
            for (var j = 0; j < GetNodeCount; j++)
            {
                str += j < GetNodeCount -1 ? $"{_graphAdjacencyMatrix[i, j]},\t" : $"{_graphAdjacencyMatrix[i,j]}\t";
            }
            str += "\n";
        }
        return str;
    }
}

// List<Node> adjacent = [];
// for (int i = 0; i < GetNodeCount; i++) {
//     var weight = _graphMatrix[i, nodeIndex]; 
//     if (weight == 0) continue;
//     adjacent.Add((i,weight));
// }