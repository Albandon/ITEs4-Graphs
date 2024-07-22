// See https://aka.ms/new-console-template for more information

using Graph;
using Graph.Structure;
using Graph.Structure.GraphRepresentations;

Console.WriteLine("Hello, World!");
var macierz = new AdjacencyList(5);
macierz.AddEdge(1,1,20);
macierz.AddEdge(2,1,19);
macierz.AddEdge(3,4);
macierz.AddEdge(0,1);
var temp = macierz.GetAdjacent(1);
Console.WriteLine($"{string.Join("",temp)}");
//
var graph = new Builder().ConsistentGraphAsList(5, 10);
Console.WriteLine($"{graph}");
var ops = new Operations(graph);
ops.DepthSearch(1);
