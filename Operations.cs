using Graph.Structure.Common;
using Node = (int index, uint weight);

namespace Graph;

public class Operations (IGraphs graph) {
    public void BreadthSearch(int fromNode)
    {
        Queue<int> queue = new();
        var visitedNodes = new bool[graph.GetNodeCount];
    
        queue.Enqueue(fromNode);
        visitedNodes[fromNode] = true;
    
        while (queue.Count != 0)
        {
            fromNode = queue.Dequeue();
            Console.WriteLine($"{fromNode} = Visited");
            foreach (var tuple in graph.GetAdjacent(fromNode)) {
                if (!(graph.GetEdgeWeight(fromNode, tuple.index) > 0) || visitedNodes[tuple.index]) continue;
                queue.Enqueue(tuple.index);
                visitedNodes[tuple.index] = true;
            }
        }
    }
    public void DepthSearch(int fromNode)
    {
        Stack<int> queue = new();
        var visitedNodes = new bool[graph.GetNodeCount];
    
        queue.Push(fromNode);
        visitedNodes[fromNode] = true;
    
        while (queue.Count != 0)
        {
            fromNode = queue.Pop();
            Console.WriteLine($"{fromNode} = Visited");
            foreach (var tuple in graph.GetAdjacent(fromNode)) {
                if (!(graph.GetEdgeWeight(fromNode, tuple.index) > 0) || visitedNodes[tuple.index]) continue;
                queue.Push(tuple.index);
                visitedNodes[tuple.index] = true;
            }
        }
    }
    public uint Dijkstra(int fromNode, int toNode)
    {
        var distance = new uint [graph.GetNodeCount];
        Array.Fill(distance, (uint)1000);
        distance[fromNode] = 0;
        var queue = new PriorityQueue<Node, uint>();
        foreach (var x in graph.GetAdjacent(fromNode))
        {
            queue.Enqueue(x,x.weight);
        }
        while (queue.Count != 0)
        {
            var node = queue.Dequeue();
            if (node.weight <= 0 || distance[node.index] != 1000) continue;
            distance[node.index] = node.weight;
            foreach (var xTuple in graph.GetAdjacent(node.index))
            {
                queue.Enqueue((xTuple.index, (distance[node.index] + xTuple.weight)),(distance[node.index] + xTuple.weight));
            }
        }
        return distance[toNode];
    }
    public HashSet<(int IndexX,int weight)> MinTree()
    {
        List<int> nodes = [];
        List<int> edges = [];
        var minVal = graph.GetMin();
        nodes.Add(minVal.indexX);
        edges.Add(0);
        for (int i = 0; i < graph.GetNodeCount; i++)
        {
            var adjacent = graph.GetAdjacent(nodes.Last());
            if (adjacent.Length == 0 ) continue;
            edges.Add((int)adjacent[0].weight);
            nodes.Add(adjacent[0].index);
        }
        return nodes.Zip(edges).ToHashSet();
    }
}