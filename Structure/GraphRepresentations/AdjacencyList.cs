using Graph.Structure.Common;
using System.Runtime.InteropServices;
using NodeTuple = (int indexX, int indexY, uint weight);
using Node = (int index, uint weight);

namespace Graph.Structure.GraphRepresentations;
public class AdjacencyList (int size): IGraphs {
    private readonly List<Node>[] _graphAdjacencyList = Enumerable.Range(0, size)
        .Select(x => new List<Node>())
        .ToArray();
    
    public void AddEdge(int fromNode, int toNode, uint weight = 1) {
        if (!HasEdge(fromNode,toNode)) _graphAdjacencyList[fromNode].Add(new Node(toNode, weight));
    }
    public void DeleteEdge(int fromNode, int toNode) => throw new NotImplementedException();
    
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
        var adjacent = CollectionsMarshal.AsSpan(_graphAdjacencyList[nodeIndex]);
        adjacent.Sort((x,y)=> x.weight.CompareTo(y.weight));
        return adjacent.ToArray();
    }
    public int GetNodeCount => _graphAdjacencyList.Length;

    public uint? GetEdgeWeight(int fromNode, int toNode) {
        var spanGraph = CollectionsMarshal.AsSpan(_graphAdjacencyList[fromNode]);
        foreach (var node in spanGraph) {
            if (node.index != toNode) continue;
            return node.weight;
        }
        return null;
    }
    public bool HasEdge(int indexX, int indexY) {
        return _graphAdjacencyList[indexX].Any(item => item.index == indexY);
    }

    public override string ToString()
    {
        var str = "";
        var index = 0;
        foreach (var connections in _graphAdjacencyList.Where(connections => connections.Count != 0))
        {
            var tuples = string.Join(", ", connections);
            str += $"{index}: {tuples} ";
            index++;
        }
        return str;
    }
}